using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ChronosArena
{
    /// <summary>Mensaje de texto recibido por red: TIPO|DATOS.</summary>
    public class MensajeRed
    {
        public string Tipo { get; private set; }
        public string Datos { get; private set; }

        public MensajeRed(string tipo, string datos)
        {
            Tipo = tipo != null ? tipo : String.Empty;
            Datos = datos != null ? datos : String.Empty;
        }
    }

    public class ErrorRedEventArgs : EventArgs
    {
        public string Mensaje { get; private set; }

        public ErrorRedEventArgs(string mensaje)
        {
            Mensaje = mensaje != null ? mensaje : String.Empty;
        }
    }

    /// <summary>
    /// Conexión TCP entre dos jugadores (LAN). Un jugador es el anfitrión
    /// (TcpListener) y el otro el cliente (TcpClient).
    ///
    /// IMPORTANTE: los eventos se disparan en HILOS SECUNDARIOS. Quien los
    /// escuche debe pasar a la interfaz con Control.Invoke antes de tocar
    /// controles.
    ///
    /// Protocolo: una línea de texto por mensaje con el formato TIPO|DATOS.
    /// Los mensajes recibidos se guardan en una bandeja (TryLeer), de modo que
    /// no se pierden aunque todavía no haya ningún formulario escuchando.
    /// </summary>
    public class GestorRed : IDisposable
    {
        public const int PuertoPredeterminado = 5000;

        private const int TiempoEsperaConexionMs = 8000;
        private const char Separador = '|';

        private TcpListener servidor;
        private TcpClient conexion;
        private StreamReader lector;
        private StreamWriter escritor;

        private Thread hiloRed;        // acepta/conecta y luego lee
        private Thread hiloEscritura;  // vacía la cola de salida

        private readonly BlockingCollection<string> colaSalida =
            new BlockingCollection<string>();

        private readonly ConcurrentQueue<MensajeRed> bandeja =
            new ConcurrentQueue<MensajeRed>();

        private int iniciado;
        private int cerrado;
        private int finNotificado;
        private volatile bool conectado;

        public bool EsAnfitrion { get; private set; }

        public bool EstaConectado
        {
            get { return conectado && !EstaCerrado; }
        }

        private bool EstaCerrado
        {
            get { return Interlocked.CompareExchange(ref cerrado, 0, 0) == 1; }
        }

        /// <summary>La conexión quedó establecida (hilo secundario).</summary>
        public event EventHandler Conectado;

        /// <summary>Hay al menos un mensaje nuevo en la bandeja (hilo secundario).</summary>
        public event EventHandler MensajeDisponible;

        /// <summary>Fallo al abrir el puerto, conectar o leer/escribir (hilo secundario).</summary>
        public event EventHandler<ErrorRedEventArgs> ErrorOcurrido;

        /// <summary>El otro extremo cerró la conexión (hilo secundario).</summary>
        public event EventHandler Desconectado;

        // ------------------------------------------------------------
        // SERVIDOR (anfitrión)
        // ------------------------------------------------------------

        public void IniciarServidor(int puerto)
        {
            ComprobarNoIniciado();
            EsAnfitrion = true;

            try
            {
                servidor = new TcpListener(IPAddress.Any, puerto);
                servidor.Start(1);
            }
            catch (SocketException ex)
            {
                NotificarFin(true,
                    "No se pudo abrir el puerto " + puerto + ": " + ex.Message);
                return;
            }

            hiloRed = new Thread(EsperarCliente);
            hiloRed.IsBackground = true;
            hiloRed.Name = "GestorRed-Servidor";
            hiloRed.Start();
        }

        private void EsperarCliente()
        {
            try
            {
                TcpListener escucha = servidor;
                TcpClient cliente = escucha.AcceptTcpClient(); // bloquea (hilo secundario)

                // Solo se admite un oponente: se cierra el puerto de escucha.
                escucha.Stop();

                if (EstaCerrado)
                {
                    cliente.Close();
                    return;
                }

                PrepararConexion(cliente);
                OnConectado();
                BucleLectura();
            }
            catch (Exception ex)
            {
                if (!EstaCerrado)
                    NotificarFin(true, "Error en el servidor: " + ex.Message);
            }
        }

        // ------------------------------------------------------------
        // CLIENTE
        // ------------------------------------------------------------

        public void Conectar(string ip, int puerto)
        {
            ComprobarNoIniciado();
            EsAnfitrion = false;

            hiloRed = new Thread(delegate() { ConectarYLeer(ip, puerto); });
            hiloRed.IsBackground = true;
            hiloRed.Name = "GestorRed-Cliente";
            hiloRed.Start();
        }

        private void ConectarYLeer(string ip, int puerto)
        {
            try
            {
                TcpClient cliente = new TcpClient();
                conexion = cliente; // para que Cerrar() pueda cancelar el intento

                IAsyncResult intento = cliente.BeginConnect(ip, puerto, null, null);
                if (!intento.AsyncWaitHandle.WaitOne(TiempoEsperaConexionMs, false))
                {
                    cliente.Close();
                    throw new TimeoutException(
                        "El anfitrión no respondió. Revisa la IP y el firewall.");
                }

                cliente.EndConnect(intento);

                PrepararConexion(cliente);
                OnConectado();
                BucleLectura();
            }
            catch (Exception ex)
            {
                if (!EstaCerrado)
                    NotificarFin(true, "No se pudo conectar: " + ex.Message);
            }
        }

        // ------------------------------------------------------------
        // ENVÍO Y RECEPCIÓN
        // ------------------------------------------------------------

        /// <summary>
        /// Encola un mensaje para enviarlo desde un hilo secundario.
        /// Nunca bloquea la interfaz y conserva el orden de envío.
        /// </summary>
        public void Enviar(string tipo, string datos)
        {
            if (EstaCerrado)
                return;

            string linea = Limpiar(tipo) + Separador + Limpiar(datos);

            try
            {
                colaSalida.Add(linea);
            }
            catch (InvalidOperationException)
            {
                // La cola ya se cerró: la conexión terminó.
            }
        }

        public void Enviar(string tipo)
        {
            Enviar(tipo, String.Empty);
        }

        /// <summary>Saca el siguiente mensaje recibido (false si no hay ninguno).</summary>
        public bool TryLeer(out MensajeRed mensaje)
        {
            return bandeja.TryDequeue(out mensaje);
        }

        /// <summary>Mira el siguiente mensaje sin sacarlo de la bandeja.</summary>
        public bool TryPeek(out MensajeRed mensaje)
        {
            return bandeja.TryPeek(out mensaje);
        }

        private void BucleLectura()
        {
            try
            {
                string linea;
                while ((linea = lector.ReadLine()) != null)
                {
                    if (linea.Length == 0)
                        continue;

                    int posicion = linea.IndexOf(Separador);
                    string tipo = posicion < 0 ? linea : linea.Substring(0, posicion);
                    string datos = posicion < 0 ? String.Empty : linea.Substring(posicion + 1);

                    bandeja.Enqueue(new MensajeRed(tipo, datos));

                    EventHandler aviso = MensajeDisponible;
                    if (aviso != null)
                        aviso(this, EventArgs.Empty);
                }

                // ReadLine devolvió null: el otro extremo cerró el socket.
                if (!EstaCerrado)
                    NotificarFin(false, null);
            }
            catch (Exception ex)
            {
                if (!EstaCerrado)
                    NotificarFin(true, "Se perdió la conexión: " + ex.Message);
            }
        }

        private void BucleEscritura()
        {
            try
            {
                foreach (string linea in colaSalida.GetConsumingEnumerable())
                    escritor.WriteLine(linea); // AutoFlush = true
            }
            catch (Exception ex)
            {
                if (!EstaCerrado)
                    NotificarFin(true, "Error al enviar datos: " + ex.Message);
            }
        }

        // ------------------------------------------------------------
        // UTILIDADES
        // ------------------------------------------------------------

        private void PrepararConexion(TcpClient cliente)
        {
            conexion = cliente;
            cliente.NoDelay = true;
            cliente.Client.SetSocketOption(
                SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);

            try
            {
                // Windows: sondeo tras 5 s de silencio y cada 2 s
                // (por defecto serían 2 horas).
                byte[] k = new byte[12];
                BitConverter.GetBytes(1u).CopyTo(k, 0);
                BitConverter.GetBytes(5000u).CopyTo(k, 4);
                BitConverter.GetBytes(2000u).CopyTo(k, 8);
                cliente.Client.IOControl(IOControlCode.KeepAliveValues, k, null);
            }
            catch (Exception)
            {
            }

            NetworkStream flujo = cliente.GetStream();
            UTF8Encoding utf8 = new UTF8Encoding(false);

            lector = new StreamReader(flujo, utf8);
            escritor = new StreamWriter(flujo, utf8);
            escritor.AutoFlush = true;
            escritor.NewLine = "\n";

            hiloEscritura = new Thread(BucleEscritura);
            hiloEscritura.IsBackground = true;
            hiloEscritura.Name = "GestorRed-Escritura";
            hiloEscritura.Start();

            conectado = true;
        }

        private void OnConectado()
        {
            EventHandler manejador = Conectado;
            if (manejador != null)
                manejador(this, EventArgs.Empty);
        }

        // Garantiza que solo se avise UNA vez del fin de la conexión.
        private void NotificarFin(bool esError, string mensaje)
        {
            if (Interlocked.Exchange(ref finNotificado, 1) == 1)
                return;

            conectado = false;

            if (esError)
            {
                EventHandler<ErrorRedEventArgs> alError = ErrorOcurrido;
                if (alError != null)
                    alError(this, new ErrorRedEventArgs(mensaje));
            }
            else
            {
                EventHandler alDesconectar = Desconectado;
                if (alDesconectar != null)
                    alDesconectar(this, EventArgs.Empty);
            }
        }

        private void ComprobarNoIniciado()
        {
            if (Interlocked.Exchange(ref iniciado, 1) == 1)
                throw new InvalidOperationException(
                    "Este GestorRed ya se inició. Crea uno nuevo para otra partida.");
        }

        private static string Limpiar(string texto)
        {
            if (texto == null)
                return String.Empty;

            return texto.Replace('\r', ' ').Replace('\n', ' ');
        }

        /// <summary>IPs IPv4 de esta PC para mostrárselas al anfitrión.</summary>
        public static string ObtenerIpsLocales()
        {
            List<string> ips = new List<string>();

            try
            {
                foreach (IPAddress ip in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork &&
                        !IPAddress.IsLoopback(ip))
                        ips.Add(ip.ToString());
                }
            }
            catch (SocketException)
            {
            }

            return ips.Count == 0 ? "127.0.0.1" : String.Join(", ", ips.ToArray());
        }

        /// <summary>
        /// Cierra la conexión. Antes deja salir los mensajes pendientes
        /// (por ejemplo RENDIR) esperando como máximo medio segundo.
        /// </summary>
        public void Cerrar()
        {
            if (Interlocked.Exchange(ref cerrado, 1) == 1)
                return;

            conectado = false;
            colaSalida.CompleteAdding();

            if (hiloEscritura != null && hiloEscritura != Thread.CurrentThread)
                hiloEscritura.Join(500);

            try { if (servidor != null) servidor.Stop(); }
            catch (SocketException) { }

            try { if (conexion != null) conexion.Close(); }
            catch (SocketException) { }
        }

        public void Dispose()
        {
            Cerrar();
        }
    }
}
