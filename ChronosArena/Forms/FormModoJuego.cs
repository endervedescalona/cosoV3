
using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace ChronosArena
{
    public partial class FormModoJuego : Form
    {
        public FormModoJuego()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            PantallaCompleta.Instalar(this);
            EscaladorInterfaz.Instalar(this);

            // Evitar operaciones externas en el diseñador.
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            CargarFondo();
        }

        private void CargarFondo()
        {
            try
            {
                string url;
                if (GestorMazo.ObtenerUrls().TryGetValue(
                    "fondo:modo", out url) &&
                    !String.IsNullOrWhiteSpace(url))
                {
                    CargadorLocal.CargarImagen(picFondo, System.IO.Path.GetFileName(url));
                }
            }
            catch
            {
                picFondo.Image = null;
            }
        }

        // LOCAL (JUGADOR VS IA).
        private void BtnLocal_Click(object sender, EventArgs e)
        {
            PartidaConfig.IniciarVsIA();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnDosJugadores_Click(object sender, EventArgs e)
        {
            // 2 JUGADORES (MISMO PC).
            PartidaConfig.IniciarLocalPvP();
            DialogResult = DialogResult.OK;
            Close();
        }

        // EN LINEA: partida por red local (TCP/IP).
        private void BtnOnline_Click(object sender, EventArgs e)
        {
            DialogResult eleccion = MessageBox.Show(
                "¿Cómo quieres jugar en línea (red local)?\r\n\r\n" +
                "SÍ  =  Crear partida (serás el anfitrión)\r\n" +
                "NO  =  Unirse a una partida (serás el cliente)",
                "Chronos Arena - Modo en línea",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            if (eleccion == DialogResult.Yes)
                CrearPartida();
            else if (eleccion == DialogResult.No)
                UnirseAPartida();
        }

        // Anfitrión: abre el puerto TCP y espera al oponente.
        private void CrearPartida()
        {
            GestorRed red = new GestorRed();

            string mensaje =
                "Esperando a un oponente...\r\n\r\n" +
                "Tu IP: " + GestorRed.ObtenerIpsLocales() + "\r\n" +
                "Puerto: " + GestorRed.PuertoPredeterminado + "\r\n\r\n" +
                "Pásale tu IP al otro jugador.";

            EsperarConexion(red, mensaje, delegate
            {
                red.IniciarServidor(GestorRed.PuertoPredeterminado);
            });
        }

        // Cliente: pide la IP del anfitrión y se conecta.
        private void UnirseAPartida()
        {
            string texto = PedirTexto(
                "Unirse a una partida",
                "Escribe la dirección IP del anfitrión:",
                "192.168.");

            if (texto == null)
                return;

            IPAddress direccion;
            if (!IPAddress.TryParse(texto.Trim(), out direccion))
            {
                MessageBox.Show(
                    "La dirección IP no es válida. Ejemplo: 192.168.1.20",
                    "Chronos Arena",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            GestorRed red = new GestorRed();
            string ip = direccion.ToString();

            EsperarConexion(
                red,
                "Conectando con " + ip + ":" + GestorRed.PuertoPredeterminado + "...",
                delegate { red.Conectar(ip, GestorRed.PuertoPredeterminado); });
        }

        // Muestra una ventana de espera mientras el GestorRed trabaja en
        // segundo plano. Los eventos de red llegan en otros hilos, por eso
        // todo pasa por this.Invoke antes de tocar la interfaz.
        private void EsperarConexion(GestorRed red, string mensaje, Action iniciar)
        {
            bool conectado = false;
            string error = null;

            using (Form espera = CrearDialogoEspera(mensaje))
            {
                EventHandler alConectar = delegate
                {
                    InvocarEnInterfaz(delegate
                    {
                        conectado = true;
                        espera.DialogResult = DialogResult.OK;   // cierra la espera
                    });
                };

                EventHandler<ErrorRedEventArgs> alFallar =
                    delegate(object emisor, ErrorRedEventArgs ev)
                {
                    string motivo = ev.Mensaje;
                    InvocarEnInterfaz(delegate
                    {
                        error = motivo;
                        espera.DialogResult = DialogResult.Abort;
                    });
                };

                EventHandler alDesconectar = delegate
                {
                    InvocarEnInterfaz(delegate
                    {
                        if (!conectado)
                        {
                            error = "La conexión se cerró.";
                            espera.DialogResult = DialogResult.Abort;
                        }
                    });
                };

                red.Conectado += alConectar;
                red.ErrorOcurrido += alFallar;
                red.Desconectado += alDesconectar;

                // La conexión se inicia cuando la ventana ya está visible.
                espera.Shown += delegate { iniciar(); };

                try
                {
                    espera.ShowDialog(this);
                }
                finally
                {
                    red.Conectado -= alConectar;
                    red.ErrorOcurrido -= alFallar;
                    red.Desconectado -= alDesconectar;
                }
            }

            if (conectado)
            {
                // Conexión lista: se deja guardada y se cierra el menú.
                // MainForm continúa con la selección de equipo y FormBatalla.
                PartidaConfig.IniciarOnline(red);

                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            red.Dispose();

            if (error != null)
            {
                MessageBox.Show(
                    error,
                    "Chronos Arena",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        // this.Invoke con protección por si el formulario ya se cerró.
        private void InvocarEnInterfaz(MethodInvoker accion)
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

        private Form CrearDialogoEspera(string mensaje)
        {
            Form ventana = new Form();
            ventana.Text = "Chronos Arena - En línea";
            ventana.FormBorderStyle = FormBorderStyle.FixedDialog;
            ventana.StartPosition = FormStartPosition.CenterParent;
            ventana.MaximizeBox = false;
            ventana.MinimizeBox = false;
            ventana.ShowInTaskbar = false;
            ventana.ClientSize = new Size(440, 220);
            ventana.BackColor = Color.FromArgb(20, 24, 33);

            Label texto = new Label();
            texto.Text = mensaje;
            texto.ForeColor = Color.Gold;
            texto.Font = new Font("Courier New", 10F, FontStyle.Bold);
            texto.TextAlign = ContentAlignment.MiddleCenter;
            texto.Dock = DockStyle.Top;
            texto.Height = 160;
            ventana.Controls.Add(texto);

            Button cancelar = new Button();
            cancelar.Text = "CANCELAR";
            cancelar.DialogResult = DialogResult.Cancel;
            cancelar.Size = new Size(140, 34);
            cancelar.Location = new Point(150, 170);
            ventana.Controls.Add(cancelar);
            ventana.CancelButton = cancelar;

            return ventana;
        }

        // Pequeño "InputBox" sin referenciar Microsoft.VisualBasic.
        private static string PedirTexto(string titulo, string pregunta, string valorInicial)
        {
            using (Form ventana = new Form())
            {
                ventana.Text = titulo;
                ventana.FormBorderStyle = FormBorderStyle.FixedDialog;
                ventana.StartPosition = FormStartPosition.CenterParent;
                ventana.MaximizeBox = false;
                ventana.MinimizeBox = false;
                ventana.ShowInTaskbar = false;
                ventana.ClientSize = new Size(380, 130);

                Label etiqueta = new Label();
                etiqueta.Text = pregunta;
                etiqueta.AutoSize = true;
                etiqueta.Location = new Point(12, 15);
                ventana.Controls.Add(etiqueta);

                TextBox caja = new TextBox();
                caja.Text = valorInicial;
                caja.Location = new Point(15, 42);
                caja.Width = 350;
                ventana.Controls.Add(caja);

                Button aceptar = new Button();
                aceptar.Text = "Aceptar";
                aceptar.DialogResult = DialogResult.OK;
                aceptar.Location = new Point(205, 85);
                ventana.Controls.Add(aceptar);
                ventana.AcceptButton = aceptar;

                Button cancelar = new Button();
                cancelar.Text = "Cancelar";
                cancelar.DialogResult = DialogResult.Cancel;
                cancelar.Location = new Point(290, 85);
                ventana.Controls.Add(cancelar);
                ventana.CancelButton = cancelar;

                ventana.Shown += delegate
                {
                    caja.Focus();
                    caja.SelectionStart = caja.Text.Length;
                };

                if (ventana.ShowDialog() != DialogResult.OK)
                    return null;

                return caja.Text;
            }
        }

        private void BtnAtras_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
