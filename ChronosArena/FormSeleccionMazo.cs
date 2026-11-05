
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ChronosArena
{
    public partial class FormSeleccionMazo : Form
    {
        private List<Personaje> catalogo;
        private List<Personaje> disponibles;

        private List<Personaje> mazoJugador =
            new List<Personaje>();

        private List<Personaje> mazoIA =
            new List<Personaje>();

        private GestorBatalla gestor = new GestorBatalla();
        private Random random = new Random();

        private bool rondaActiva;
        private bool jugadorEligePrimero;
        private bool reemplazo;

        private int dadoJugador;
        private int dadoIA;

        private Personaje cartaPendiente;

        public List<Personaje> MazoJugador
        {
            get { return mazoJugador; }
        }

        public List<Personaje> MazoIA
        {
            get { return mazoIA; }
        }

        public FormSeleccionMazo()
        {
            InitializeComponent();

            catalogo = GestorMazo.ObtenerMazoCompleto();
            disponibles = new List<Personaje>(catalogo);

            cmbFiltro.Items.Add("Todos los personajes");
            cmbFiltro.Items.Add("Clase: Tanque");
            cmbFiltro.Items.Add("Clase: Mago");
            cmbFiltro.Items.Add("Clase: Guerrero");
            cmbFiltro.Items.Add("Facción: Homura");
            cmbFiltro.Items.Add("Facción: Mizushiro");
            cmbFiltro.Items.Add("Facción: Kazekiri");
            cmbFiltro.Items.Add("Facción: Daichi");

            cmbFiltro.SelectedIndex = 0;

            CargarFondoSeleccion();
            ActualizarListas();
            DibujarCatalogo();

            btnElegir.Enabled = false;
            btnRetirar.Enabled = false;
            btnComenzar.Enabled = false;
        }

        private void CargarFondoSeleccion()
        {
            Dictionary<string, string> urls =
                GestorMazo.ObtenerUrls();

            string url;

            if (urls.TryGetValue("fondo:seleccion", out url) &&
                !String.IsNullOrWhiteSpace(url))
            {
                PictureBox fondo = new PictureBox();

                fondo.Dock = DockStyle.Fill;
                fondo.SizeMode = PictureBoxSizeMode.StretchImage;
                fondo.Enabled = false;

                fondo.LoadCompleted += delegate(
                    object sender,
                    System.ComponentModel.AsyncCompletedEventArgs e)
                {
                    if (e.Error != null)
                        fondo.Visible = false;
                };

                try
                {
                    fondo.LoadAsync(url);
                    Controls.Add(fondo);
                    fondo.SendToBack();
                }
                catch
                {
                    fondo.Dispose();
                }
            }
        }

        private void CmbFiltro_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            DibujarCatalogo();
        }

        private void BtnUrls_Click(object sender, EventArgs e)
        {
            using (FormImagenes formulario = new FormImagenes())
            {
                if (formulario.ShowDialog(this) == DialogResult.OK)
                {
                    catalogo = GestorMazo.ObtenerMazoCompleto();

                    List<string> nombresDisponibles =
                        disponibles.Select(p => p.Nombre).ToList();

                    disponibles = catalogo
                        .Where(p => nombresDisponibles.Contains(p.Nombre))
                        .ToList();

                    DibujarCatalogo();
                }
            }
        }

        private void DibujarCatalogo()
        {
            panelCatalogo.Controls.Clear();

            IEnumerable<Personaje> lista = disponibles;

            string filtro = cmbFiltro.SelectedItem == null
                ? "Todos los personajes"
                : cmbFiltro.SelectedItem.ToString();

            if (filtro.StartsWith("Clase: "))
            {
                string clase = filtro.Substring(7);

                lista = lista.Where(
                    p => p.Clase == clase);
            }
            else if (filtro.StartsWith("Facción: "))
            {
                string faccion = filtro.Substring(9);

                lista = lista.Where(
                    p => p.Faccion == faccion);
            }

            foreach (Personaje personaje in lista)
            {
                panelCatalogo.Controls.Add(
                    CrearCarta(personaje));
            }
        }

        private Panel CrearCarta(Personaje p)
        {
            Panel tarjeta = new Panel();

            tarjeta.Size = new Size(200, 155);
            tarjeta.Margin = new Padding(6);
            tarjeta.BackColor = Color.FromArgb(39, 48, 66);
            tarjeta.BorderStyle = BorderStyle.FixedSingle;
            tarjeta.Cursor = Cursors.Hand;

            Label nombre = new Label();

            nombre.Text = p.Nombre;
            nombre.Font = new Font(
                "Arial", 11, FontStyle.Bold);
            nombre.ForeColor = Color.Gold;
            nombre.Location = new Point(8, 6);
            nombre.Size = new Size(180, 22);

            Label estadisticas = new Label();

            estadisticas.Text =
                p.Faccion + " - " + p.Elemento +
                "\r\nClase: " + p.Clase +
                "\r\nVida: " + p.VidaMax +
                "  Ataque: " + p.Ataque +
                "\r\nDefensa: " + p.Defensa +
                "  Maná: " + p.Mana +
                "\r\nEnergía: " + p.Energia +
                "  Empatía: " + p.Empatia +
                "\r\nHabilidad: " + p.HabilidadEspecial;

            estadisticas.Font = new Font("Arial", 8.5F);
            estadisticas.ForeColor = Color.WhiteSmoke;
            estadisticas.Location = new Point(8, 32);
            estadisticas.Size = new Size(184, 98);

            PictureBox foto = new PictureBox();

            foto.Location = new Point(150, 4);
            foto.Size = new Size(42, 42);
            foto.SizeMode = PictureBoxSizeMode.Zoom;
            foto.BackColor = Color.FromArgb(25, 30, 42);

            if (!String.IsNullOrEmpty(p.ImagenUrl))
            {
                try
                {
                    foto.LoadAsync(p.ImagenUrl);
                }
                catch
                {
                    // Si la imagen no carga, la carta sigue funcionando.
                }
            }

            Label elegir = new Label();

            elegir.Text = "CLIC PARA SELECCIONAR";
            elegir.Font = new Font(
                "Arial", 8, FontStyle.Bold);
            elegir.ForeColor = Color.LightSkyBlue;
            elegir.Location = new Point(8, 133);
            elegir.Size = new Size(180, 18);

            EventHandler seleccionar = delegate(
                object sender, EventArgs e)
            {
                if (!rondaActiva && !reemplazo)
                {
                    MessageBox.Show(
                        "Primero lanza los dados para iniciar la ronda.",
                        "Chronos Arena",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                cartaPendiente = p;

                lblEstado.Text =
                    "Carta seleccionada: " + p.Nombre +
                    ". Pulsa Confirmar carta.";

                btnElegir.Enabled = true;
            };

            tarjeta.Click += seleccionar;
            nombre.Click += seleccionar;
            estadisticas.Click += seleccionar;
            foto.Click += seleccionar;
            elegir.Click += seleccionar;

            tarjeta.Controls.Add(nombre);
            tarjeta.Controls.Add(estadisticas);
            tarjeta.Controls.Add(foto);
            tarjeta.Controls.Add(elegir);

            return tarjeta;
        }

        private void BtnDado_Click(object sender, EventArgs e)
        {
            if (reemplazo)
            {
                MessageBox.Show(
                    "Primero selecciona una carta para reemplazar la retirada.");

                return;
            }

            if (mazoJugador.Count >= 5 && mazoIA.Count >= 5)
            {
                ActualizarEstado();
                return;
            }

            if (rondaActiva)
            {
                MessageBox.Show(
                    "Termina la selección de esta ronda antes de volver a lanzar.");

                return;
            }

            if (disponibles.Count < 2)
            {
                MessageBox.Show(
                    "No quedan suficientes personajes disponibles.");

                return;
            }

            // Los dados se utilizan exclusivamente en la selección.
            dadoJugador = gestor.LanzarDado();
            dadoIA = gestor.LanzarDado();

            while (dadoJugador == dadoIA)
            {
                dadoIA = gestor.LanzarDado();
            }

            jugadorEligePrimero = dadoJugador > dadoIA;
            rondaActiva = true;

            if (!jugadorEligePrimero)
            {
                ElegirIA();
            }

            lblEstado.Text =
                "Ronda " + (Math.Max(
                    mazoJugador.Count, mazoIA.Count) + 1) +
                ": Tú " + dadoJugador +
                " | IA " + dadoIA + ". " +
                (jugadorEligePrimero
                    ? "Ganaste: elige primero."
                    : "La IA ganó y eligió primero. Ahora te toca.");

            btnDado.Enabled = false;
            btnElegir.Enabled = false;
            cartaPendiente = null;

            DibujarCatalogo();
            ActualizarListas();
        }

        private void ElegirIA()
        {
            if (mazoIA.Count >= 5 || disponibles.Count == 0)
                return;

            Personaje elegido = disponibles
                .OrderByDescending(p =>
                    p.VidaMax * 0.25 +
                    p.Ataque * 1.2 +
                    p.Defensa * 0.45 +
                    random.Next(0, 20))
                .First();

            mazoIA.Add(elegido);
            disponibles.Remove(elegido);

            gestor.Registrar(
                "La IA seleccionó " + elegido.Nombre + ".");
        }

        private void SeleccionarPersonaje(Personaje p)
        {
            if (p == null || !disponibles.Contains(p))
                return;

            if (!reemplazo && !rondaActiva)
                return;

            mazoJugador.Add(p);
            disponibles.Remove(p);

            gestor.Registrar(
                "El jugador seleccionó " + p.Nombre + ".");

            if (reemplazo)
            {
                reemplazo = false;
            }
            else if (jugadorEligePrimero)
            {
                ElegirIA();
            }

            rondaActiva = false;
            cartaPendiente = null;

            btnElegir.Enabled = false;
            btnDado.Enabled =
                mazoJugador.Count < 5 || mazoIA.Count < 5;

            DibujarCatalogo();
            ActualizarListas();

            if (mazoJugador.Count == 5 && mazoIA.Count == 5)
            {
                btnDado.Enabled = false;
                btnRetirar.Enabled = true;
                btnComenzar.Enabled = true;

                lblEstado.Text =
                    "¡Mazos completos! Puedes reemplazar una carta " +
                    "o comenzar la batalla.";
            }
            else
            {
                lblEstado.Text =
                    "Carta añadida. Lanza los dados para la siguiente ronda.";
            }
        }

        private void BtnElegir_Click(object sender, EventArgs e)
        {
            if (cartaPendiente == null)
            {
                MessageBox.Show(
                    "Haz clic primero en una carta del catálogo.",
                    "Elegir carta");

                return;
            }

            Personaje elegida = cartaPendiente;
            SeleccionarPersonaje(elegida);
        }

        private void BtnRetirar_Click(object sender, EventArgs e)
        {
            if (mazoJugador.Count != 5 || mazoIA.Count != 5)
                return;

            if (lstMazoJugador.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Selecciona primero la carta de tu mazo que deseas retirar.");

                return;
            }

            int indice = lstMazoJugador.SelectedIndex;

            Personaje retirado = mazoJugador[indice];

            mazoJugador.RemoveAt(indice);
            disponibles.Add(retirado);

            reemplazo = true;
            rondaActiva = false;
            cartaPendiente = null;

            btnComenzar.Enabled = false;
            btnDado.Enabled = false;
            btnElegir.Enabled = false;
            btnRetirar.Enabled = false;

            lblEstado.Text =
                "Retiraste " + retirado.Nombre +
                ". Selecciona una carta disponible para reemplazarla.";

            DibujarCatalogo();
            ActualizarListas();
        }

        private void BtnComenzar_Click(object sender, EventArgs e)
        {
            if (mazoJugador.Count != 5 || mazoIA.Count != 5)
            {
                MessageBox.Show(
                    "Cada equipo debe tener cinco cartas.");

                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void ActualizarListas()
        {
            lstMazoJugador.Items.Clear();

            foreach (Personaje p in mazoJugador)
            {
                lstMazoJugador.Items.Add(
                    p.Nombre + " - " + p.Clase +
                    " - " + p.Elemento);
            }

            lstMazoIA.Items.Clear();

            foreach (Personaje p in mazoIA)
            {
                lstMazoIA.Items.Add(
                    p.Nombre + " - " + p.Clase +
                    " - " + p.Elemento);
            }

            lblJugador.Text =
                "TU MAZO (" + mazoJugador.Count + "/5)";

            lblIA.Text =
                "MAZO IA (" + mazoIA.Count + "/5)";

            btnRetirar.Enabled =
                mazoJugador.Count == 5 &&
                mazoIA.Count == 5 &&
                !reemplazo;

            btnComenzar.Enabled =
                mazoJugador.Count == 5 &&
                mazoIA.Count == 5 &&
                !reemplazo;
        }

        private void ActualizarEstado()
        {
            lblEstado.Text =
                "Mazos completos. Puedes comenzar la batalla.";
        }
    }
}
