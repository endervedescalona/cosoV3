using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        private GestorBatalla gestor =
            new GestorBatalla();

        private Random random =
            new Random();

        private bool reemplazo;

        private Personaje cartaPendiente;

        // Dirección de la imagen original del reverso.
        private string urlReverso;

        // Dirección de la imagen mostrada actualmente como vista previa.
        private string urlVistaPreviaActual;

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
            PantallaCompleta.Instalar(this);
            EscaladorInterfaz.Instalar(this);

            // El diseñador muestra el layout base sin ejecutar carga de datos ni imágenes remotas.
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            catalogo = GestorMazo.ObtenerMazoCompleto();

            Dictionary<string, string> recursos =
                GestorMazo.ObtenerUrls();

            // Cargar el reverso de la carta.
            if (recursos.TryGetValue(
                "reverso:carta", out urlReverso))
            {
                CargarReversoOriginal();
            }

            disponibles = new List<Personaje>(catalogo);

            // Filtros.
            cmbFiltro.Items.Add("Todos los personajes");

            cmbFiltro.Items.Add("Clase: Tanque");

            cmbFiltro.Items.Add("Clase: Mago");

            cmbFiltro.Items.Add("Clase: Guerrero");

            cmbFiltro.Items.Add("Facción: Homura");

            cmbFiltro.Items.Add("Facción: Mizushiro");

            cmbFiltro.Items.Add("Facción: Kazekiri");

            cmbFiltro.Items.Add("Facción: Daichi");

            cmbFiltro.SelectedIndex = 0;

            ActualizarListas();

            DibujarCatalogo();

            btnElegir.Enabled = false;

            btnRetirar.Enabled = false;

            btnComenzar.Enabled = false;
        }

        // Cargar el reverso original.
        private void CargarReversoOriginal()
        {
            urlVistaPreviaActual = null;

            if (String.IsNullOrWhiteSpace(urlReverso))
                return;

            try
            {
                CargadorLocal.CargarImagen(picReverso, System.IO.Path.GetFileName(urlReverso));
            }
            catch
            {
                // Se conserva la imagen que estuviera cargada.
            }
        }

        // Mostrar la imagen del personaje al pasar el cursor.
        private void MostrarVistaPrevia(string url)
        {
            if (String.IsNullOrWhiteSpace(url))
                return;

            if (url == urlVistaPreviaActual)
                return;

            try
            {
                CargadorLocal.CargarImagen(picReverso, System.IO.Path.GetFileName(url));

                urlVistaPreviaActual = url;
            }
            catch
            {
                urlVistaPreviaActual = null;
            }
        }

        // Restaurar el reverso cuando el cursor abandona una carta.
        private void RestaurarVistaPrevia()
        {
            if (urlVistaPreviaActual == null)
                return;

            CargarReversoOriginal();
        }

        private void CmbFiltro_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            DibujarCatalogo();
        }

        private void DibujarCatalogo()
        {
            // Liberar tarjetas anteriores para evitar acumular controles e imágenes.
            while (panelCatalogo.Controls.Count > 0)
            {
                Control anterior = panelCatalogo.Controls[0];
                panelCatalogo.Controls.RemoveAt(0);
                anterior.Dispose();
            }

            IEnumerable<Personaje> lista = disponibles;

            string filtro =
                cmbFiltro.SelectedItem == null
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

            tarjeta.Size = new Size(260, 120);

            tarjeta.Margin = new Padding(6);

            tarjeta.BackColor =
                Color.FromArgb(39, 48, 66);

            tarjeta.BorderStyle =
                BorderStyle.FixedSingle;

            tarjeta.Cursor = Cursors.Hand;

            // Nombre del personaje.
            Label nombre = new Label();

            nombre.AutoSize = false;
            nombre.Text = p.Nombre;

            nombre.Font = new Font(
                "Courier New", 11, FontStyle.Bold);

            nombre.ForeColor = Color.Gold;

            nombre.Location = new Point(8, 5);

            nombre.Size = new Size(175, 20);

            // Estadísticas.
            Label estadisticas = new Label();

            estadisticas.AutoSize = false;
            estadisticas.Text =
                p.Faccion + " - " + p.Elemento +
                "\r\nClase: " + p.Clase + "  Vida: " + p.VidaMax +
                "\r\nAtaque: " + p.Ataque + "  Defensa: " + p.Defensa +
                "\r\nManá: " + p.Mana + "  Energía: " + p.Energia +
                "\r\nEmpatía: " + p.Empatia +
                "\r\nHabilidad: " + p.HabilidadEspecial;

            estadisticas.Font =
                new Font("Courier New", 7.4F);

            estadisticas.ForeColor =
                Color.WhiteSmoke;

            estadisticas.Location =
                new Point(8, 27);

            estadisticas.Size =
                new Size(185, 80);

            // Imagen pequeña de la carta.
            PictureBox foto = new PictureBox();

            foto.Location = new Point(202, 5);

            foto.Size = new Size(50, 90);

            foto.SizeMode =
                PictureBoxSizeMode.Zoom;

            foto.BackColor =
                Color.FromArgb(25, 30, 42);

            if (!String.IsNullOrEmpty(p.ImagenUrl))
            {
                try
                {
                    CargadorLocal.CargarImagen(foto, System.IO.Path.GetFileName(p.ImagenUrl));
                }
                catch
                {
                    // La carta sigue funcionando aunque no cargue la imagen.
                }
            }

            // Texto inferior.
            Label elegir = new Label();

            elegir.AutoSize = false;
            elegir.Text = "CLIC PARA SELECCIONAR";

            elegir.Font = new Font(
                "Courier New", 8, FontStyle.Bold);

            elegir.ForeColor = Color.LightSkyBlue;

            elegir.Location = new Point(8, 101);

            elegir.Size = new Size(180, 15);

            // Selección de la carta.
            // Pasar el cursor no modifica cartaPendiente.
            EventHandler seleccionar = delegate(
                object sender, EventArgs e)
            {
                if (mazoJugador.Count >= 5 && !reemplazo)
                    return;

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

            // Vista previa al entrar con el mouse.
            EventHandler mostrar = delegate(
                object sender, EventArgs e)
            {
                MostrarVistaPrevia(p.ImagenUrl);
            };

            // Al salir de un control, comprobamos que el cursor
            // haya abandonado realmente toda la tarjeta.
            EventHandler salir = delegate(
                object sender, EventArgs e)
            {
                Rectangle limites =
                    tarjeta.RectangleToScreen(
                        tarjeta.ClientRectangle);

                if (!limites.Contains(Cursor.Position))
                {
                    RestaurarVistaPrevia();
                }
            };

            Control[] controlesVistaPrevia =
                new Control[]
                {
                    tarjeta,
                    nombre,
                    estadisticas,
                    foto,
                    elegir
                };

            foreach (Control control in controlesVistaPrevia)
            {
                control.MouseEnter += mostrar;

                control.MouseLeave += salir;
            }

            tarjeta.Controls.Add(nombre);

            tarjeta.Controls.Add(estadisticas);

            tarjeta.Controls.Add(foto);

            tarjeta.Controls.Add(elegir);

            return tarjeta;
        }

        private void ElegirIA(Personaje referencia)
        {
            if (mazoIA.Count >= 5 || disponibles.Count == 0 || referencia == null)
                return;

            // La IA toma una carta del grupo que aún no eligió ninguno de los
            // dos equipos. Busca personajes de potencia parecida a la carta
            // seleccionada por el jugador para que la partida sea más justa.
            List<Personaje> opcionesIA = disponibles
                .Where(p => p.Nombre != referencia.Nombre &&
                    !mazoIA.Any(x => x.Nombre == p.Nombre))
                .OrderBy(p => Math.Abs(CalcularPoder(p) - CalcularPoder(referencia)))
                .Take(3)
                .ToList();

            if (opcionesIA.Count == 0)
                return;

            // Hay una pequeña variación entre las tres cartas más cercanas;
            // la IA no escoge siempre exactamente la misma combinación.
            Personaje elegido = opcionesIA[random.Next(opcionesIA.Count)];

            mazoIA.Add(elegido.Clonar());
            disponibles.Remove(elegido);

            gestor.Registrar(
                "La IA seleccionó " + elegido.Nombre +
                " (carta de nivel similar a " + referencia.Nombre + ").");
        }

        private int CalcularPoder(Personaje personaje)
        {
            // Pesos sencillos: vida, ataque, defensa y recursos cuentan
            // para comparar la fuerza general de dos personajes.
            return personaje.VidaMax +
                (personaje.Ataque * 3) +
                (personaje.Defensa * 2) +
                personaje.Energia +
                personaje.Mana;
        }

        private void SeleccionarPersonaje(Personaje p)
        {
            if (p == null || !disponibles.Contains(p))
                return;

            if (!reemplazo && mazoJugador.Count >= 5)
                return;

            mazoJugador.Add(p);

            disponibles.Remove(p);

            gestor.Registrar(
                "El jugador seleccionó " + p.Nombre + ".");

            if (reemplazo)
            {
                reemplazo = false;
            }
            else
            {
                ElegirIA(p);
            }

            cartaPendiente = null;

            btnElegir.Enabled = false;

            DibujarCatalogo();

            ActualizarListas();

            if (mazoJugador.Count == 5 &&
                mazoIA.Count == 5)
            {
                btnRetirar.Enabled = true;

                btnComenzar.Enabled = true;

                lblEstado.Text =
                    "¡Mazos completos! Puedes reemplazar una carta " +
                    "o comenzar la batalla.";
            }
            else
            {
                lblEstado.Text =
                    "Carta añadida. La IA eligió una carta de nivel parecido. " +
                    "Selecciona la siguiente.";
            }
        }

        private void BtnElegir_Click(
            object sender, EventArgs e)
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

        private void BtnRetirar_Click(
            object sender, EventArgs e)
        {
            if (mazoJugador.Count != 5 ||
                mazoIA.Count != 5)
                return;

            if (lstMazoJugador.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Selecciona primero la carta de tu mazo que deseas retirar.");

                return;
            }

            int indice =
                lstMazoJugador.SelectedIndex;

            Personaje retirado =
                mazoJugador[indice];

            mazoJugador.RemoveAt(indice);

            disponibles.Add(retirado);

            reemplazo = true;

            cartaPendiente = null;

            btnComenzar.Enabled = false;

            btnElegir.Enabled = false;

            btnRetirar.Enabled = false;

            lblEstado.Text =
                "Retiraste " + retirado.Nombre +
                ". Selecciona una carta disponible para reemplazarla.";

            DibujarCatalogo();

            ActualizarListas();
        }

        private void BtnComenzar_Click(
            object sender, EventArgs e)
        {
            if (mazoJugador.Count != 5 ||
                mazoIA.Count != 5)
            {
                MessageBox.Show(
                    "Cada equipo debe tener cinco cartas.");

                return;
            }

            DialogResult = DialogResult.OK;

            Close();
        }

        // Volver al menú de modo de juego.
        private void BtnVolverModo_Click(
            object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

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