using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ChronosArena
{
    /// <summary>
    /// Parte "en línea" de FormBatalla (TCP/IP).
    ///
    /// Modelo: lockstep. Las reglas del juego son deterministas (sin azar), así
    /// que en cada PC se ejecuta la misma acción sobre los mismos equipos:
    ///  - Equipo 1 = mazo del anfitrión, Equipo 2 = mazo del cliente.
    ///  - Solo el jugador al que le toca el turno puede actuar; al hacerlo, envía
    ///    el nombre de la acción (ATAQUE, ESPECIAL, DEFENSA, RELEVAR, TIEMPO).
    ///  - El rival recibe el mensaje y ejecuta exactamente la misma acción.
    /// </summary>
    public partial class FormBatalla
    {
        private GestorRed red;
        // El modo sale de PartidaConfig, así el constructor base ya lo ve bien.
        private bool esOnline
        {
            get { return PartidaConfig.EsOnline; }
        }
        private int miEquipo = 1;          // 1 = anfitrión, 2 = cliente
        private bool aplicandoRemoto;      // true mientras se reproduce la acción del rival

        // En el modo local siempre es "mi turno"; en línea solo si turnoActual == miEquipo.
        private bool EsMiTurno
        {
            get { return !esOnline || turnoActual == miEquipo; }
        }

        // Equipo 1 debe ser SIEMPRE el del anfitrión, en las dos PCs.
        public FormBatalla(
            List<Personaje> equipo1,
            List<Personaje> equipo2,
            GestorRed gestorRed) : this(equipo1, equipo2)
        {
            if (gestorRed == null)
                throw new ArgumentNullException("gestorRed");

            red = gestorRed;
            miEquipo = red.EsAnfitrion ? 1 : 2;
            // El constructor base aún no conocía si esta PC era el jugador 2.
            // Arranca el reloj aquí cuando el dado dio el primer turno al cliente.
            if (turnoActual == miEquipo)
                IniciarTemporizadorTurno();
            else
                lblTemporizador.Text = "ESPERANDO TURNO";

            AgregarRegistro("Partida en línea: eres el Jugador " + miEquipo + ".");
            ActualizarInterfaz();

            // Se engancha al mostrarse el formulario: ya existe el handle
            // y se procesan los mensajes que llegaron mientras se construía.
            Shown += delegate
            {
                red.MensajeDisponible += Red_MensajeDisponible;
                red.ErrorOcurrido += Red_ErrorOcurrido;
                red.Desconectado += Red_Desconectado;

                if (!red.EstaConectado)
                {
                    ConexionPerdida("Se perdió la conexión con el oponente.");
                    return;
                }

                ProcesarBandeja();
            };

            FormClosed += delegate
            {
                red.MensajeDisponible -= Red_MensajeDisponible;
                red.ErrorOcurrido -= Red_ErrorOcurrido;
                red.Desconectado -= Red_Desconectado;
            };
        }

        // ---------- Eventos de red (llegan en hilos secundarios) ----------

        private void Red_MensajeDisponible(object sender, EventArgs e)
        {
            EjecutarEnInterfaz(ProcesarBandeja);
        }

        private void Red_ErrorOcurrido(object sender, ErrorRedEventArgs e)
        {
            string motivo = "Error de red: " + e.Mensaje;
            EjecutarEnInterfaz(delegate { ConexionPerdida(motivo); });
        }

        private void Red_Desconectado(object sender, EventArgs e)
        {
            EjecutarEnInterfaz(delegate
            {
                ConexionPerdida("Tu oponente se desconectó.");
            });
        }

        // Pasa al hilo de la interfaz de forma segura.
        private void EjecutarEnInterfaz(MethodInvoker accion)
        {
            if (IsDisposed || !IsHandleCreated)
                return;

            try
            {
                Invoke(accion);
            }
            catch (ObjectDisposedException)
            {
            }
            catch (InvalidOperationException)
            {
            }
        }

        // ---------- Procesamiento de mensajes (hilo de la interfaz) ----------

        private void ProcesarBandeja()
        {
            MensajeRed mensaje;
            while (!batallaTerminada && red.TryLeer(out mensaje))
                ProcesarMensajeRed(mensaje);
        }

        private void ProcesarMensajeRed(MensajeRed mensaje)
        {
            switch (mensaje.Tipo)
            {
                case "ATAQUE":
                case "ESPECIAL":
                case "DEFENSA":
                case "RELEVAR":
                case "PASAR":
                case "TIEMPO":
                    // Solo se acepta si realmente es el turno del rival.
                    if (!EsMiTurno)
                    {
                        // El rival manda el checksum de su estado ANTES de actuar.
                        if (mensaje.Datos != ChecksumEstado())
                        {
                            ConexionPerdida("Las dos partidas se desincronizaron.");
                            return;
                        }

                        AplicarAccionRival(mensaje.Tipo);
                    }
                    break;

                case "RENDIR":
                    RivalSeRindio();
                    break;
            }
        }

        // Reproduce aquí la acción que el rival ya ejecutó en su PC.
        private void AplicarAccionRival(string accion)
        {
            aplicandoRemoto = true;
            try
            {
                switch (accion)
                {
                    case "ATAQUE":
                        BtnAtaque_Click(this, EventArgs.Empty);
                        break;

                    case "ESPECIAL":
                        BtnEspecial_Click(this, EventArgs.Empty);
                        break;

                    case "DEFENSA":
                        BtnDefensa_Click(this, EventArgs.Empty);
                        break;

                    case "RELEVAR":
                        BtnRelevar_Click(this, EventArgs.Empty);
                        break;

                    case "PASAR":
                        BtnPasarTurno_Click(this, EventArgs.Empty);
                        break;

                    case "TIEMPO":
                        temporizadorTurno.Stop();
                        AgregarRegistro(
                            "Se agotó el tiempo. " + NombreEquipo(turnoActual) +
                            " pierde su turno.");
                        ResolverAccionPvP();
                        break;
                }
            }
            finally
            {
                aplicandoRemoto = false;
            }
        }

        // Los manejadores de botones llaman a esto justo antes de aplicar su
        // efecto. Si la acción es local, se avisa al rival; si es remota, no.
        private void EnviarAccionRed(string accion)
        {
            if (!esOnline || aplicandoRemoto)
                return;

            red.Enviar(accion, ChecksumEstado());
        }

        // Resumen del estado de la batalla: si difiere entre las dos PCs,
        // las partidas se desincronizaron.
        private string ChecksumEstado()
        {
            unchecked
            {
                int h = 17;
                h = h * 31 + turnoActual;
                h = h * 31 + indiceJugador;
                h = h * 31 + indiceIA;

                foreach (Personaje p in equipoJugador)
                    h = (((((h * 31 + p.Vida) * 31 + p.VidaMax) * 31 + p.Energia) * 31 + p.Mana) * 31 + p.Defensa) * 31 + p.CargasEspecial;

                foreach (Personaje p in equipoIA)
                    h = (((((h * 31 + p.Vida) * 31 + p.VidaMax) * 31 + p.Energia) * 31 + p.Mana) * 31 + p.Defensa) * 31 + p.CargasEspecial;

                return h.ToString();
            }
        }

        private void RivalSeRindio()
        {
            if (batallaTerminada)
                return;

            batallaTerminada = true;
            temporizadorTurno.Stop();

            AgregarRegistro(
                "El Jugador " + (miEquipo == 1 ? 2 : 1) +
                " se ha rendido. Gana el Jugador " + miEquipo + ".");

            gestor.GuardarHistorial("Jugador " + miEquipo, equipoJugador, equipoIA);

            MessageBox.Show(
                "Tu oponente se ha rendido. ¡Has ganado la partida!",
                "Chronos Arena",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void ConexionPerdida(string motivo)
        {
            if (batallaTerminada)
                return;

            batallaTerminada = true;
            temporizadorTurno.Stop();

            AgregarRegistro(motivo + " Partida interrumpida.");
            gestor.GuardarHistorial("Interrumpida", equipoJugador, equipoIA);

            MessageBox.Show(
                motivo + "\r\nLa partida se cerrará.",
                "Chronos Arena",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
