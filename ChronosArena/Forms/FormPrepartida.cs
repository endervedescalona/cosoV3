using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChronosArena
{
    public partial class FormPrePartida : Form
    {
        // CREAMOS EL PICTUREBOX AQUÍ AFUERA PARA QUE EL DISEÑADOR NO FALLE
        private PictureBox picFondoPreparacion;

        private Timer temporizadorRed;
        private readonly Random azar = new Random();
        private GestorRed red;

        private bool nombreRivalRecibido;
        private bool datosDadosRecibidos;

        private string nombreRival;
        private int dado1;
        private int dado2;

        private string nombreEquipo1Preparado;
        private string nombreEquipo2Preparado;

        public string NombreJugador1
        {
            get
            {
                return String.IsNullOrWhiteSpace(nombreEquipo1Preparado)
                    ? LimpiarNombre(txtNombre1.Text)
                    : nombreEquipo1Preparado;
            }
        }

        public string NombreJugador2
        {
            get
            {
                if (!String.IsNullOrWhiteSpace(nombreEquipo2Preparado))
                    return nombreEquipo2Preparado;

                if (PartidaConfig.EsVsIA)
                    return "COMPUTADORA";

                if (PartidaConfig.EsOnline)
                    return "JUGADOR 2";

                return LimpiarNombre(txtNombre2.Text);
            }
        }

        public int EquipoComienza
        {
            get { return dado1 > dado2 ? 1 : 2; }
        }

        public FormPrePartida()
        {
            InitializeComponent();

            // CONFIGURACIÓN DEL FONDO EN CÓDIGO PARA SHARPDEVELOP 2016
            picFondoPreparacion = new PictureBox();
            picFondoPreparacion.Name = "picFondoPreparacion";
            picFondoPreparacion.Dock = DockStyle.Fill;
            picFondoPreparacion.Enabled = false;
            picFondoPreparacion.TabStop = false;
            picFondoPreparacion.SizeMode = PictureBoxSizeMode.Zoom;
            picFondoPreparacion.BackColor = Color.FromArgb(15, 31, 50);
            this.Controls.Add(picFondoPreparacion);
            picFondoPreparacion.SendToBack();

            Text = "CHRONOS ARENA - ANTES DE INICIAR";
            StartPosition = FormStartPosition.CenterParent;
            AutoScaleMode = AutoScaleMode.None;
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Normal;
            MaximizeBox = true;
            MinimizeBox = true;
            ClientSize = new Size(920, 520);
            MinimumSize = new Size(860, 500);
            BackColor = Color.FromArgb(15, 31, 50);
            ForeColor = Color.White;
            Font = new Font("Courier New", 9F);
            DoubleBuffered = true;

            PantallaCompleta.Instalar(this);
            EscaladorInterfaz.Instalar(this);

            CargadorLocal.CargarImagen(picFondoPreparacion, "GAME_MODE.jpg");

            bool esLocal = PartidaConfig.EsLocalPvP;
            lblNombre1.Text = PartidaConfig.EsOnline
                ? "NOMBRE DE TU EQUIPO"
                : "NOMBRE DEL JUGADOR 1";
            txtNombre1.Text = "Jugador 1";

            lblNombre2.Visible = esLocal;
            txtNombre2.Visible = esLocal;
            txtNombre2.Text = "Jugador 2";

            lblRival.Visible = !esLocal;
            lblRival.Text = PartidaConfig.EsOnline
                ? "OPONENTE: esperando nombre por LAN"
                : "OPONENTE: COMPUTADORA";

            bool anfitrionConectado =
                PartidaConfig.EsOnline &&
                PartidaConfig.Red != null &&
                PartidaConfig.Red.EsAnfitrion;

            btnLanzar.Text = PartidaConfig.EsOnline
                ? (anfitrionConectado
                    ? "ESPERANDO AL RIVAL"
                    : "ESPERANDO AL ANFITRION")
                : "LANZAR DADOS";
            btnLanzar.Enabled = !PartidaConfig.EsOnline;
            btnLanzar.Click += BtnLanzarDado_Click;

            lblEstado.Text = PartidaConfig.EsOnline
                ? "Enviando tu nombre y esperando al otro equipo de la red local."
                : "El resultado más alto decide quién comienza y elige la carta ambiente.";

            btnAtras.Click += SalirPreparacion;

            btnContinuar.Enabled = false;
            btnContinuar.Click += delegate
            {
                if (datosDadosRecibidos && dado1 != dado2)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            };

            if (PartidaConfig.EsOnline)
            {
                red = PartidaConfig.Red;

                Shown += FormPrePartida_Shown;

                temporizadorRed = new Timer();
                temporizadorRed.Interval = 200;
                temporizadorRed.Tick += ProcesarMensajesRed;

                FormClosed += delegate
                {
                    if (temporizadorRed != null)
                    {
                        temporizadorRed.Stop();
                        temporizadorRed.Dispose();
                        temporizadorRed = null;
                    }
                };
            }
        }

        private static string LimpiarNombre(string nombre)
        {
            string valor = (nombre != null ? nombre : String.Empty).Trim();

            valor = valor.Replace("|", " ")
                .Replace("#", " ")
                .Replace("\r", " ")
                .Replace("\n", " ");

            while (valor.Contains("  "))
                valor = valor.Replace("  ", " ");

            return String.IsNullOrWhiteSpace(valor)
                ? "JUGADOR"
                : valor;
        }

        private void SalirPreparacion(object sender, EventArgs e)
        {
            if (PartidaConfig.EsOnline && red != null && red.EstaConectado)
            {
                red.Enviar("PRE_CANCELAR", "El otro jugador canceló la preparación.");
            }

            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormPrePartida_Shown(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Normal)
                WindowState = FormWindowState.Normal;

            if (red == null || !red.EstaConectado)
            {
                lblEstado.Text = "No hay una conexión LAN activa.";
                btnLanzar.Enabled = false;
                return;
            }

            red.Enviar("PRE_NOMBRE", LimpiarNombre(txtNombre1.Text));
            temporizadorRed.Start();
        }

        private void BtnLanzarDado_Click(object sender, EventArgs e)
        {
            LanzarDado();
        }

        private void LanzarDado()
        {
            if (PartidaConfig.EsOnline)
            {
                if (red == null || !red.EstaConectado || !red.EsAnfitrion || !nombreRivalRecibido)
                    return;

                string miNombre = LimpiarNombre(txtNombre1.Text);
                dado1 = azar.Next(1, 7);
                dado2 = azar.Next(1, 7);

                red.Enviar("PRE_DADOS", dado1 + "," + dado2 + "#" + miNombre + "#" + nombreRival);

                AplicarDados(dado1, dado2, miNombre, nombreRival);
                return;
            }

            string n1 = LimpiarNombre(txtNombre1.Text);
            string n2 = PartidaConfig.EsLocalPvP ? LimpiarNombre(txtNombre2.Text) : "COMPUTADORA";

            dado1 = azar.Next(1, 7);
            dado2 = azar.Next(1, 7);

            AplicarDados(dado1, dado2, n1, n2);
        }

        private void AplicarDados(int d1, int d2, string n1, string n2)
        {
            dado1 = d1;
            dado2 = d2;

            lblDado1.Text = d1.ToString();
            lblDado2.Text = d2.ToString();

            datosDadosRecibidos = d1 != d2;

            if (d1 == d2)
            {
                lblEstado.Text = "EMPATE: vuelve a lanzar los dados.";
                btnContinuar.Enabled = false;

                if (PartidaConfig.EsOnline && red != null && red.EsAnfitrion)
                {
                    btnLanzar.Enabled = true;
                    btnLanzar.Text = "VOLVER A LANZAR";
                    lblEstado.Text += " El anfitrión puede lanzar otra vez.";
                }
            }
            else
            {
                int primero = d1 > d2 ? 1 : 2;
                lblEstado.Text = (primero == 1 ? n1 : n2) + " comienza y elige la carta ambiente.";
                btnContinuar.Enabled = true;
                btnLanzar.Enabled = false;
                btnLanzar.Text = "DADOS CONFIRMADOS";
            }

            nombreEquipo1Preparado = LimpiarNombre(n1);
            nombreEquipo2Preparado = LimpiarNombre(n2);

            if (PartidaConfig.EsOnline)
            {
                nombreRival = n2;
                if (red != null && red.EsAnfitrion)
                    nombreRivalRecibido = true;
            }
        }

        private void ProcesarMensajesRed(object sender, EventArgs e)
        {
            if (red == null) return;

            if (!red.EstaConectado)
            {
                lblEstado.Text = "Se perdió la conexión LAN con el rival.";
                btnLanzar.Enabled = false;
                btnContinuar.Enabled = false;
                return;
            }

            MensajeRed mensaje;

            while (red.TryPeek(out mensaje) && mensaje.Tipo.StartsWith("PRE_", StringComparison.Ordinal))
            {
                red.TryLeer(out mensaje);

                if (mensaje.Tipo == "PRE_CANCELAR")
                {
                    MessageBox.Show("El otro jugador canceló la preparación.", "Chronos Arena", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }
                else if (mensaje.Tipo == "PRE_NOMBRE")
                {
                    nombreRival = LimpiarNombre(mensaje.Datos);
                    nombreRivalRecibido = true;

                    if (lblRival != null)
                        lblRival.Text = "OPONENTE: " + nombreRival;

                    if (red.EsAnfitrion)
                    {
                        btnLanzar.Enabled = true;
                        btnLanzar.Text = "LANZAR DADOS";
                        lblEstado.Text = "Conectado con " + nombreRival + ". Pulsa LANZAR DADOS.";
                    }
                }
                else if (mensaje.Tipo == "PRE_DADOS")
                {
                    string[] partes = mensaje.Datos.Split('#');

                    if (partes.Length >= 3)
                    {
                        btnLanzar.Enabled = false;
                        btnLanzar.Text = "ESPERANDO AL ANFITRION";

                        string[] dados = partes[0].Split(',');
                        int a, b;

                        if (dados.Length == 2 && Int32.TryParse(dados[0], out a) && Int32.TryParse(dados[1], out b))
                        {
                            AplicarDados(a, b, LimpiarNombre(partes[1]), LimpiarNombre(partes[2]));
                        }
                    }
                }
            }
        }
    }
}