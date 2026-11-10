using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ChronosArena
{
    public partial class FormSeleccionAmbiente : Form
    {
        // CREAMOS LOS PICTUREBOX AQUÍ PARA QUE EL DISEÑADOR NO FALLE
        private PictureBox pbTsunami;
        private PictureBox pbHuracan;
        private PictureBox pbErupcion;
        private PictureBox pbDeslave;

        private readonly int equipoComienza;
        private readonly List<CartaAmbiente> ambientes;
        private readonly Dictionary<CartaAmbiente, Panel> paneles = new Dictionary<CartaAmbiente, Panel>();

        private CartaAmbiente seleccionada;
        private Timer temporizadorRed;
        private bool puedeElegir;
        private bool seleccionConfirmada;
        private bool completado;

        public CartaAmbiente AmbienteSeleccionado
        {
            get { return seleccionada; }
        }

        public string ElegidoPor { get; private set; }

        public FormSeleccionAmbiente(int equipoQueComienza)
        {
            InitializeComponent();

            // CREACIÓN Y CONFIGURACIÓN DE LAS IMÁGENES EN CÓDIGO
            pbTsunami = new PictureBox();
            pbTsunami.Location = new Point(3, 3);
            pbTsunami.Size = new Size(272, 412);
            pbTsunami.SizeMode = PictureBoxSizeMode.Zoom;
            pbTsunami.BackColor = Color.FromArgb(12, 18, 28);
            pbTsunami.Cursor = Cursors.Hand;
            pbTsunami.TabStop = false;
            pnlTsunami.Controls.Add(pbTsunami);

            pbHuracan = new PictureBox();
            pbHuracan.Location = new Point(3, 3);
            pbHuracan.Size = new Size(272, 412);
            pbHuracan.SizeMode = PictureBoxSizeMode.Zoom;
            pbHuracan.BackColor = Color.FromArgb(12, 18, 28);
            pbHuracan.Cursor = Cursors.Hand;
            pbHuracan.TabStop = false;
            pnlHuracan.Controls.Add(pbHuracan);

            pbErupcion = new PictureBox();
            pbErupcion.Location = new Point(3, 3);
            pbErupcion.Size = new Size(272, 412);
            pbErupcion.SizeMode = PictureBoxSizeMode.Zoom;
            pbErupcion.BackColor = Color.FromArgb(12, 18, 28);
            pbErupcion.Cursor = Cursors.Hand;
            pbErupcion.TabStop = false;
            pnlErupcion.Controls.Add(pbErupcion);

            pbDeslave = new PictureBox();
            pbDeslave.Location = new Point(3, 3);
            pbDeslave.Size = new Size(272, 412);
            pbDeslave.SizeMode = PictureBoxSizeMode.Zoom;
            pbDeslave.BackColor = Color.FromArgb(12, 18, 28);
            pbDeslave.Cursor = Cursors.Hand;
            pbDeslave.TabStop = false;
            pnlDeslave.Controls.Add(pbDeslave);

            this.equipoComienza = equipoQueComienza == 2 ? 2 : 1;
            ambientes = CartaAmbiente.ObtenerAmbientesPredefinidos();

            StartPosition = FormStartPosition.CenterParent;
            WindowState = FormWindowState.Normal;
            FormBorderStyle = FormBorderStyle.Sizable;
            DoubleBuffered = true;

            PantallaCompleta.Instalar(this);
            EscaladorInterfaz.Instalar(this);

            CargadorLocal.CargarImagen(this, "GAME_MODE.jpg");

            bool eligeIA = PartidaConfig.EsVsIA && this.equipoComienza == 2;

            if (PartidaConfig.EsOnline)
            {
                int miEquipo = PartidaConfig.Red != null && PartidaConfig.Red.EsAnfitrion ? 1 : 2;
                puedeElegir = miEquipo == this.equipoComienza;
                lblEstado.Text = puedeElegir
                    ? "TE CORRESPONDE ELEGIR EL AMBIENTE."
                    : "ESPERANDO LA ELECCION DEL JUGADOR " + this.equipoComienza + " POR LAN...";
            }
            else if (eligeIA)
            {
                puedeElegir = false;
                lblEstado.Text = "LA COMPUTADORA ESTA ELIGIENDO EL AMBIENTE...";
            }
            else
            {
                puedeElegir = true;
                lblEstado.Text = "ELIGE: " + NombreEquipo(this.equipoComienza) + ".";
            }

            Panel[] panelesDesigner = new Panel[] { pnlTsunami, pnlHuracan, pnlErupcion, pnlDeslave };
            PictureBox[] imagenesDesigner = new PictureBox[] { pbTsunami, pbHuracan, pbErupcion, pbDeslave };

            for (int i = 0; i < ambientes.Count && i < panelesDesigner.Length; i++)
            {
                ConfigurarCarta(ambientes[i], panelesDesigner[i], imagenesDesigner[i]);
            }

            btnAtras.Click += SalirSeleccionAmbiente;
            btnConfirmar.Click += ConfirmarAmbiente;
            btnContinuar.Click += ContinuarBatalla;

            if (eligeIA)
            {
                seleccionada = ambientes[new Random().Next(ambientes.Count)];
                ElegidoPor = "COMPUTADORA";
                MostrarSeleccion(seleccionada);
                seleccionConfirmada = true;
                BloquearSeleccion();
                btnContinuar.Enabled = true;
                lblEstado.Text = "LA COMPUTADORA ELIGIO " + seleccionada.Nombre.ToUpperInvariant() + ".";
            }

            Shown += delegate
            {
                lblTitulo.BringToFront();
                lblSubtitulo.BringToFront();
                lblEstado.BringToFront();

                foreach (Panel cartaPanel in paneles.Values)
                {
                    cartaPanel.BringToFront();
                }

                lblResumen.BringToFront();
                btnAtras.BringToFront();
                btnConfirmar.BringToFront();
                btnContinuar.BringToFront();
            };

            FormClosed += delegate
            {
                if (BackgroundImage != null)
                {
                    Image fondo = BackgroundImage;
                    BackgroundImage = null;
                    fondo.Dispose();
                }
            };

            if (PartidaConfig.EsOnline)
            {
                temporizadorRed = new Timer();
                temporizadorRed.Interval = 200;
                temporizadorRed.Tick += ProcesarAmbienteRemoto;
                Shown += delegate { temporizadorRed.Start(); };

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

        private void ConfigurarCarta(CartaAmbiente carta, Panel panel, PictureBox imagen)
        {
            if (carta == null || panel == null || imagen == null) return;

            panel.Tag = carta;
            panel.Cursor = puedeElegir ? Cursors.Hand : Cursors.Default;
            imagen.Tag = carta;
            imagen.Cursor = panel.Cursor;

            CargadorLocal.CargarImagen(imagen, carta.ImagenUrl);

            panel.Click += SeleccionarCarta;
            imagen.Click += SeleccionarCarta;
            panel.MouseEnter += MostrarResumenCarta;
            imagen.MouseEnter += MostrarResumenCarta;

            panel.Enabled = true;
            imagen.Enabled = true;

            paneles[carta] = panel;
        }

        private string NombreEquipo(int equipo)
        {
            if (PartidaConfig.EsVsIA && equipo == 2) return "COMPUTADORA";

            return equipo == 1 ? PartidaConfig.NombreJugador1 : PartidaConfig.NombreJugador2;
        }

        private void MostrarResumenCarta(object sender, EventArgs e)
        {
            Control control = sender as Control;

            while (control != null && !(control.Tag is CartaAmbiente))
            {
                control = control.Parent;
            }

            if (control == null) return;

            CartaAmbiente carta = (CartaAmbiente)control.Tag;
            lblResumen.Text = carta.Nombre.ToUpperInvariant() + ": " + carta.Resumen;
        }

        private void SeleccionarCarta(object sender, EventArgs e)
        {
            if (!puedeElegir || seleccionConfirmada || completado) return;

            Control control = sender as Control;

            while (control != null && !(control.Tag is CartaAmbiente))
            {
                control = control.Parent;
            }

            if (control == null) return;

            seleccionada = (CartaAmbiente)control.Tag;
            ElegidoPor = NombreEquipo(equipoComienza);

            MostrarSeleccion(seleccionada);
            btnConfirmar.Enabled = true;
        }

        private void MostrarSeleccion(CartaAmbiente carta)
        {
            foreach (KeyValuePair<CartaAmbiente, Panel> par in paneles)
            {
                bool activa = par.Key.Clave == carta.Clave;
                par.Value.BackColor = activa ? Color.Gold : Color.FromArgb(40, 50, 68);
                par.Value.Padding = activa ? new Padding(5) : new Padding(3);
            }

            lblResumen.Text = carta.Nombre.ToUpperInvariant() + ": " + carta.Resumen;
            lblEstado.Text = "SELECCIONADA: " + carta.Nombre.ToUpperInvariant() + " | ELEGIDA POR: " + ElegidoPor;
        }

        private void SalirSeleccionAmbiente(object sender, EventArgs e)
        {
            if (completado) return;

            if (PartidaConfig.EsOnline)
            {
                if (seleccionConfirmada) return;

                if (PartidaConfig.Red != null && PartidaConfig.Red.EstaConectado)
                {
                    PartidaConfig.Red.Enviar("PRE_CANCELAR", "El otro jugador canceló la selección del ambiente.");
                }
            }

            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ConfirmarAmbiente(object sender, EventArgs e)
        {
            if (seleccionada == null || seleccionConfirmada || completado) return;

            if (PartidaConfig.EsOnline && PartidaConfig.Red != null)
            {
                PartidaConfig.Red.Enviar("PRE_AMBIENTE", seleccionada.Clave);
            }

            seleccionConfirmada = true;
            BloquearSeleccion();
            btnContinuar.Enabled = true;

            lblEstado.Text = "CARTA CONFIRMADA: " + seleccionada.Nombre.ToUpperInvariant() + " | ELEGIDA POR: " + ElegidoPor;
        }

        private void BloquearSeleccion()
        {
            puedeElegir = false;

            foreach (Panel panel in paneles.Values)
            {
                panel.Cursor = Cursors.Default;
                foreach (Control hijo in panel.Controls)
                {
                    hijo.Cursor = Cursors.Default;
                }
            }

            btnConfirmar.Enabled = false;
            btnConfirmar.Text = "CARTA CONFIRMADA";
        }

        private void ProcesarAmbienteRemoto(object sender, EventArgs e)
        {
            if (completado || !PartidaConfig.EsOnline || seleccionConfirmada) return;

            GestorRed red = PartidaConfig.Red;

            if (red == null || !red.EstaConectado)
            {
                lblEstado.Text = "SE PERDIO LA CONEXION LAN. REGRESA AL MENU.";
                return;
            }

            MensajeRed mensaje;

            while (red.TryPeek(out mensaje) && mensaje.Tipo.StartsWith("PRE_", StringComparison.Ordinal))
            {
                red.TryLeer(out mensaje);

                if (mensaje.Tipo == "PRE_CANCELAR")
                {
                    MessageBox.Show("El otro jugador canceló la selección del ambiente.", "Chronos Arena", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                if (mensaje.Tipo == "PRE_AMBIENTE")
                {
                    CartaAmbiente carta = CartaAmbiente.ObtenerPorNombre(mensaje.Datos);
                    if (carta == null) return;

                    seleccionada = carta;
                    ElegidoPor = NombreEquipo(equipoComienza);

                    MostrarSeleccion(carta);
                    seleccionConfirmada = true;
                    BloquearSeleccion();
                    btnContinuar.Enabled = true;

                    lblEstado.Text = "AMBIENTE RECIBIDO: " + carta.Nombre.ToUpperInvariant() + " | ELEGIDO POR: " + ElegidoPor;
                    return;
                }
            }
        }

        private void ContinuarBatalla(object sender, EventArgs e)
        {
            if (!seleccionConfirmada || seleccionada == null || completado) return;

            completado = true;

            PartidaConfig.GuardarPreparacion(
                seleccionada,
                equipoComienza,
                PartidaConfig.NombreJugador1,
                PartidaConfig.NombreJugador2,
                ElegidoPor);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}