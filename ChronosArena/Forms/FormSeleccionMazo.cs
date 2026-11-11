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
        private List<Personaje> mazoJugador1 = new List<Personaje>();
        private List<Personaje> mazoJugador2 = new List<Personaje>();
        private GestorBatalla gestor = new GestorBatalla();
        private Random random = new Random();

        private int faseJugador = 1;
        private Personaje cartaPendiente;

        private bool yoListo;
        private bool yoComienzo;
        private bool rivalComienzo;
        private List<Personaje> mazoRivalPendiente;
        private bool cerrando;

        private string urlReverso;
        private string urlVistaPreviaActual;
        private ListBox listaSeleccionadaParaRetirar;

        public List<Personaje> MazoJugador
        {
            get { return mazoJugador1; }
        }

        public List<Personaje> MazoIA
        {
            get { return mazoJugador2; }
        }

        private List<Personaje> MazoDeFase()
        {
            if (PartidaConfig.EsLocalPvP && faseJugador == 2)
                return mazoJugador2;

            return mazoJugador1;
        }

        private string NombreSelector()
        {
            if (PartidaConfig.EsLocalPvP)
                return "El Jugador " + faseJugador;

            return "El jugador";
        }

        public FormSeleccionMazo()
        {
            InitializeComponent();

            DoubleBuffered = true;
            PantallaCompleta.Instalar(this);
            EscaladorInterfaz.Instalar(this);

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            catalogo = GestorMazo.ObtenerMazoCompleto();

            if (catalogo == null)
                catalogo = new List<Personaje>();

            Dictionary<string, string> recursos =
                GestorMazo.ObtenerUrls();

            if (recursos != null)
            {
                recursos.TryGetValue("reverso:carta", out urlReverso);

                if (!String.IsNullOrWhiteSpace(urlReverso))
                    CargarReversoOriginal();
            }

            cmbFiltro.Items.Clear();
            cmbFiltro.Items.Add("Todos los personajes");
            cmbFiltro.Items.Add("Clase: Tanque");
            cmbFiltro.Items.Add("Clase: Mago");
            cmbFiltro.Items.Add("Clase: Guerrero");
            cmbFiltro.Items.Add("Facción: Homura");
            cmbFiltro.Items.Add("Facción: Mizushiro");
            cmbFiltro.Items.Add("Facción: Kazekiri");
            cmbFiltro.Items.Add("Facción: Daichi");
            cmbFiltro.SelectedIndex = 0;
            CargarEquiposGuardadosEnCombo();

            btnElegir.Enabled = false;
            btnRetirar.Enabled = false;
            btnComenzar.Enabled = false;

            lstMazoJugador.SelectedIndexChanged +=
                new EventHandler(ListaMazo_SelectedIndexChanged);

            ActualizarListas();
            DibujarCatalogo();

            if (PartidaConfig.EsLocalPvP)
            {
                ActualizarRotulosPvP();
                lblEstado.Text = "JUGADOR 1: elige tus 5 cartas.";
            }

            if (PartidaConfig.EsOnline)
            {
                btnComenzar.Text = "LISTO";
                lblEstado.Text =
                    "Elige tus 5 cartas. Tu rival elige las suyas en su PC.";
            }
        }

        private void CargarEquiposGuardadosEnCombo()
        {
            cmbEquiposGuardados.BeginUpdate();
            try
            {
                cmbEquiposGuardados.Items.Clear();
                cmbEquiposGuardados.Items.Add("Cargar equipo guardado...");

                Dictionary<string, List<string>> equipos =
                    GestorMazo.ObtenerEquiposGuardados();

                foreach (string nombre in equipos.Keys.OrderBy(x => x))
                    cmbEquiposGuardados.Items.Add(nombre);

                if (equipos.Count == 0)
                    cmbEquiposGuardados.Items.Add("(No hay equipos guardados)");

                cmbEquiposGuardados.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                cmbEquiposGuardados.Items.Clear();
                cmbEquiposGuardados.Items.Add("Error al leer equipos guardados");
                cmbEquiposGuardados.SelectedIndex = 0;
                MessageBox.Show(
                    "No se pudieron cargar los equipos guardados.\r\n\r\n" +
                    ex.Message,
                    "Chronos Arena", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmbEquiposGuardados.EndUpdate();
            }
        }

        private void CmbEquiposGuardados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEquiposGuardados.SelectedIndex <= 0 ||
                !PartidaConfig.EsVsIA ||
                cmbEquiposGuardados.SelectedItem == null ||
                cmbEquiposGuardados.SelectedItem.ToString().StartsWith("("))
                return;
            string nombre = cmbEquiposGuardados.SelectedItem.ToString();
            Dictionary<string, List<string>> equipos = GestorMazo.ObtenerEquiposGuardados();
            List<string> nombres;
            if (!equipos.TryGetValue(nombre, out nombres)) return;
            List<Personaje> recuperados = new List<Personaje>();
            foreach (string nombreCarta in nombres)
            {
                Personaje encontrado = catalogo.FirstOrDefault(x => String.Equals(x.Nombre, nombreCarta, StringComparison.OrdinalIgnoreCase));
                if (encontrado == null) { MessageBox.Show("No se encontró la carta guardada: " + nombreCarta); return; }
                recuperados.Add(encontrado.Clonar());
            }
            mazoJugador1.Clear();
            mazoJugador2.Clear();
            foreach (Personaje carta in recuperados) mazoJugador1.Add(carta);
            foreach (Personaje carta in recuperados) ElegirIA(carta);
            DibujarCatalogo();
            ActualizarListas();
            lblEstado.Text = "Equipo de " + nombre + " cargado. Puedes modificarlo o comenzar la partida.";
            btnComenzar.Enabled = mazoJugador1.Count == 5 && mazoJugador2.Count == 5;
        }

        private void ActualizarRotulosPvP()
        {
            lblTitulo.Text = "SELECCIÓN - JUGADOR " + faseJugador;
        }

        private void CargarReversoOriginal()
        {
            urlVistaPreviaActual = null;

            if (String.IsNullOrWhiteSpace(urlReverso))
                return;

            try
            {
                CargadorLocal.CargarImagen(
                    picReverso,
                    System.IO.Path.GetFileName(urlReverso));
            }
            catch
            {
                // La vista previa no debe impedir la selección.
            }
        }

        private void MostrarVistaPrevia(string url)
        {
            if (String.IsNullOrWhiteSpace(url) ||
                url == urlVistaPreviaActual)
                return;

            try
            {
                CargadorLocal.CargarImagen(
                    picReverso,
                    System.IO.Path.GetFileName(url));

                urlVistaPreviaActual = url;
            }
            catch
            {
                urlVistaPreviaActual = null;
            }
        }

        private void RestaurarVistaPrevia()
        {
            if (urlVistaPreviaActual != null)
                CargarReversoOriginal();
        }

        private void CmbFiltro_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            DibujarCatalogo();
        }

        private void DibujarCatalogo()
        {
            while (panelCatalogo.Controls.Count > 0)
            {
                Control anterior = panelCatalogo.Controls[0];
                panelCatalogo.Controls.RemoveAt(0);
                anterior.Dispose();
            }

            // Solo se excluyen los personajes que ya tiene el jugador
            // que está seleccionando en este momento.
            // Nunca se excluyen por pertenecer al mazo del rival.
            List<Personaje> mazoActual = MazoDeFase();

            IEnumerable<Personaje> lista = catalogo.Where(p =>
                !mazoActual.Any(x => String.Equals(
                    x.Nombre,
                    p.Nombre,
                    StringComparison.OrdinalIgnoreCase)));

            string filtro = cmbFiltro.SelectedItem == null
                ? "Todos los personajes"
                : cmbFiltro.SelectedItem.ToString();

            if (filtro.StartsWith("Clase: "))
            {
                string clase = filtro.Substring(7);
                lista = lista.Where(p => p.Clase == clase);
            }
            else if (filtro.StartsWith("Facción: "))
            {
                string faccion = filtro.Substring(9);
                lista = lista.Where(p => p.Faccion == faccion);
            }

            List<Personaje> cartasVisibles = lista.ToList();

            foreach (Personaje personaje in cartasVisibles)
                panelCatalogo.Controls.Add(CrearCarta(personaje));

            if (cartasVisibles.Count == 0)
            {
                Label vacio = new Label();
                vacio.AutoSize = false;
                vacio.Text =
                    "YA ELEGISTE TODOS LOS PERSONAJES DE ESTE FILTRO.\r\n" +
                    "RETIRA UNO PARA VOLVER A SELECCIONARLO.";
                vacio.ForeColor = Color.White;
                vacio.BackColor = Color.FromArgb(25, 35, 50);
                vacio.Font = new Font(
                    "Courier New", 8.5F, FontStyle.Bold);
                vacio.Size = new Size(260, 60);
                panelCatalogo.Controls.Add(vacio);
            }
        }

        private Panel CrearCarta(Personaje p)
        {
            Panel tarjeta = new Panel();
            tarjeta.Size = new Size(260, 120);
            tarjeta.Margin = new Padding(6);
            tarjeta.BackColor = Color.FromArgb(39, 48, 66);
            tarjeta.BorderStyle = BorderStyle.FixedSingle;
            tarjeta.Cursor = Cursors.Hand;

            Label nombre = new Label();
            nombre.AutoSize = false;
            nombre.Text = p.Nombre;
            nombre.Font = new Font(
                "Courier New", 11, FontStyle.Bold);
            nombre.ForeColor = Color.Gold;
            nombre.Location = new Point(8, 5);
            nombre.Size = new Size(175, 20);

            Label estadisticas = new Label();
            estadisticas.AutoSize = false;
            estadisticas.Text =
                p.Faccion + " - " + p.Elemento +
                "\r\nClase: " + p.Clase + "  Vida: " + p.VidaMax +
                "\r\nAtaque: " + p.Ataque + "  Defensa: " + p.Defensa +
                "\r\nManá: " + p.Mana + "  Energía: " + p.Energia +
                "\r\nEmpatía: " + p.Empatia +
                "\r\nHabilidad: " + p.HabilidadEspecial;
            estadisticas.Font = new Font("Courier New", 7.4F);
            estadisticas.ForeColor = Color.WhiteSmoke;
            estadisticas.Location = new Point(8, 27);
            estadisticas.Size = new Size(185, 80);

            PictureBox foto = new PictureBox();
            foto.Location = new Point(202, 5);
            foto.Size = new Size(50, 90);
            foto.SizeMode = PictureBoxSizeMode.Zoom;
            foto.BackColor = Color.FromArgb(25, 30, 42);

            if (!String.IsNullOrEmpty(p.ImagenUrl))
            {
                try
                {
                    CargadorLocal.CargarImagen(
                        foto,
                        System.IO.Path.GetFileName(p.ImagenUrl));
                }
                catch
                {
                    // La carta se puede elegir aunque falte la imagen.
                }
            }

            Label elegir = new Label();
            elegir.AutoSize = false;
            elegir.Text = "CLIC PARA SELECCIONAR";
            elegir.Font = new Font(
                "Courier New", 8, FontStyle.Bold);
            elegir.ForeColor = Color.LightSkyBlue;
            elegir.Location = new Point(8, 101);
            elegir.Size = new Size(180, 15);

            EventHandler seleccionar = delegate(
                object sender, EventArgs e)
            {
                List<Personaje> mazoActual = MazoDeFase();

                if (mazoActual.Count >= PartidaConfig.TamanoMazo)
                {
                    lblEstado.Text = "Tu mazo ya tiene cinco cartas.";
                    btnElegir.Enabled = false;
                    return;
                }

                bool yaLaTiene = mazoActual.Any(x =>
                    String.Equals(
                        x.Nombre,
                        p.Nombre,
                        StringComparison.OrdinalIgnoreCase));

                if (yaLaTiene)
                {
                    lblEstado.Text =
                        "Ya tienes a " + p.Nombre +
                        ". No puedes repetirlo dentro de tu mazo.";
                    btnElegir.Enabled = false;
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

            EventHandler mostrar = delegate(
                object sender, EventArgs e)
            {
                MostrarVistaPrevia(p.ImagenUrl);
            };

            EventHandler salir = delegate(
                object sender, EventArgs e)
            {
                Rectangle limites = tarjeta.RectangleToScreen(
                    tarjeta.ClientRectangle);

                if (!limites.Contains(Cursor.Position))
                    RestaurarVistaPrevia();
            };

            Control[] controles = new Control[]
            {
                tarjeta, nombre, estadisticas, foto, elegir
            };

            foreach (Control control in controles)
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
            if (mazoJugador2.Count >= PartidaConfig.TamanoMazo ||
                catalogo == null ||
                catalogo.Count == 0 ||
                referencia == null)
                return;

            // La IA evita repetir únicamente las cartas de SU mazo.
            // Puede elegir cualquier carta que tenga el jugador humano.
            List<Personaje> opcionesIA = catalogo
                .Where(p => !mazoJugador2.Any(x => String.Equals(
                    x.Nombre,
                    p.Nombre,
                    StringComparison.OrdinalIgnoreCase)))
                .OrderBy(p => Math.Abs(
                    CalcularPoder(p) - CalcularPoder(referencia)))
                .Take(Math.Min(3, catalogo.Count))
                .ToList();

            if (opcionesIA.Count == 0)
                return;

            Personaje elegido =
                opcionesIA[random.Next(opcionesIA.Count)];

            mazoJugador2.Add(elegido.Clonar());

            gestor.Registrar(
                "La IA seleccionó " + elegido.Nombre +
                " (carta de nivel similar a " + referencia.Nombre + ").");
        }

        private int CalcularPoder(Personaje personaje)
        {
            return personaje.VidaMax +
                (personaje.Ataque * 3) +
                (personaje.Defensa * 2) +
                personaje.Energia +
                personaje.Mana;
        }

        private void SeleccionarPersonaje(Personaje p)
        {
            if (p == null || catalogo == null ||
                !catalogo.Any(x => String.Equals(
                    x.Nombre,
                    p.Nombre,
                    StringComparison.OrdinalIgnoreCase)))
                return;

            List<Personaje> mazoActual = MazoDeFase();

            if (mazoActual.Count >= PartidaConfig.TamanoMazo)
                return;

            // Impide repetir dentro del mismo mazo, pero NO compara contra
            // el mazo contrario.
            if (mazoActual.Any(x => String.Equals(
                x.Nombre,
                p.Nombre,
                StringComparison.OrdinalIgnoreCase)))
            {
                lblEstado.Text =
                    "Ya tienes a " + p.Nombre +
                    ". No puedes repetirlo dentro de tu mazo.";
                return;
            }

            mazoActual.Add(p.Clonar());

            gestor.Registrar(
                NombreSelector() + " seleccionó " + p.Nombre + ".");

            cartaPendiente = null;
            btnElegir.Enabled = false;

            if (PartidaConfig.EsVsIA)
            {
                // La IA conserva cinco cartas distintas en su propio mazo.
                // Si el jugador retira una, se retira la carta IA emparejada.
                while (mazoJugador2.Count < mazoJugador1.Count)
                {
                    int cantidadAnterior = mazoJugador2.Count;
                    ElegirIA(p);

                    if (mazoJugador2.Count == cantidadAnterior)
                        break;
                }
            }

            DibujarCatalogo();
            ActualizarListas();
            SeleccionarUltimaCartaEnFase();

            if (PartidaConfig.EsOnline)
            {
                lblEstado.Text =
                    mazoJugador1.Count == PartidaConfig.TamanoMazo
                    ? "Mazo completo. Pulsa LISTO para enviarlo; puedes retirar una carta antes."
                    : "Carta añadida (" + mazoJugador1.Count +
                      "/5). Puedes retirarla inmediatamente si te equivocaste.";
                return;
            }

            if (PartidaConfig.EsLocalPvP)
            {
                AvanzarFasePvP();
                return;
            }

            if (mazoJugador1.Count == PartidaConfig.TamanoMazo &&
                mazoJugador2.Count == PartidaConfig.TamanoMazo)
            {
                btnComenzar.Enabled = true;
                lblEstado.Text =
                    "¡Mazos completos! Puedes retirar una carta o comenzar la batalla.";
            }
            else
            {
                lblEstado.Text =
                    "Carta añadida. La IA eligió una carta. Selecciona la siguiente.";
            }
        }

        private void SeleccionarUltimaCartaEnFase()
        {
            ListBox lista =
                (PartidaConfig.EsLocalPvP && faseJugador == 2)
                ? lstMazoIA
                : lstMazoJugador;

            if (lista.Items.Count > 0)
            {
                lista.SelectedIndex = lista.Items.Count - 1;
                listaSeleccionadaParaRetirar = lista;
            }
        }

        private void AvanzarFasePvP()
        {
            if (mazoJugador1.Count == 5 && mazoJugador2.Count == 5)
            {
                lblTitulo.Text = "SELECCIÓN DE PERSONAJES";
                lblEstado.Text =
                    "¡Ambos mazos completos! Cualquiera puede reemplazar " +
                    "una carta o pueden comenzar la batalla.";
                return;
            }

            if (faseJugador == 1 && mazoJugador1.Count == 5)
            {
                faseJugador = 2;

                ActualizarRotulosPvP();
                ActualizarListas();
                DibujarCatalogo();

                lblEstado.Text =
                    "JUGADOR 2: elige tus 5 cartas. Puedes escoger personajes " +
                    "del mazo del Jugador 1, pero no repetir dentro del tuyo.";

                MessageBox.Show(
                    "El Jugador 1 completó su mazo.\r\n\r\n" +
                    "Ahora el Jugador 2 elegirá sus 5 cartas. Puede elegir " +
                    "personajes que ya tenga el Jugador 1, pero no repetir " +
                    "dentro de su propio mazo.",
                    "Cambio de turno",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            lblEstado.Text =
                "JUGADOR " + faseJugador +
                ": carta añadida (" + MazoDeFase().Count +
                "/5). Selecciona la siguiente.";
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

            SeleccionarPersonaje(cartaPendiente);
        }

        private void BtnRetirar_Click(object sender, EventArgs e)
        {
            ListBox lista = null;

            if (PartidaConfig.EsLocalPvP)
            {
                if (listaSeleccionadaParaRetirar != null &&
                    listaSeleccionadaParaRetirar.SelectedIndex >= 0)
                    lista = listaSeleccionadaParaRetirar;
                else if (lstMazoJugador.SelectedIndex >= 0)
                    lista = lstMazoJugador;
                else if (lstMazoIA.SelectedIndex >= 0)
                    lista = lstMazoIA;
            }
            else
            {
                // VS IA y LAN: el usuario solo modifica su mazo propio.
                lista = lstMazoJugador;
            }

            if (lista == null || lista.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Selecciona una carta de tu mazo para retirarla. " +
                    "Puedes hacerlo desde la primera carta.",
                    "Retirar carta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (PartidaConfig.EsOnline && yoListo)
            {
                MessageBox.Show(
                    "Ya enviaste tu mazo al rival. No puedes modificarlo mientras esperas.",
                    "Mazo enviado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            List<Personaje> mazoActual;

            if (lista == lstMazoIA)
            {
                mazoActual = mazoJugador2;
                faseJugador = 2;
            }
            else
            {
                mazoActual = mazoJugador1;
                faseJugador = 1;
            }

            int indice = lista.SelectedIndex;

            if (indice < 0 || indice >= mazoActual.Count)
                return;

            Personaje retirado = mazoActual[indice];
            mazoActual.RemoveAt(indice);

            // VS IA: retirar una carta del jugador retira la carta de IA
            // que correspondía a esa elección. La IA escogerá otra al reponer.
            if (PartidaConfig.EsVsIA &&
                !PartidaConfig.EsOnline &&
                lista == lstMazoJugador &&
                indice < mazoJugador2.Count)
            {
                mazoJugador2.RemoveAt(indice);
            }

            cartaPendiente = null;
            btnElegir.Enabled = false;
            listaSeleccionadaParaRetirar = null;

            DibujarCatalogo();
            ActualizarListas();

            ListBox listaActualizada =
                (PartidaConfig.EsLocalPvP && faseJugador == 2)
                ? lstMazoIA
                : lstMazoJugador;

            if (listaActualizada.Items.Count > 0)
            {
                int nuevoIndice = Math.Min(
                    indice,
                    listaActualizada.Items.Count - 1);

                listaActualizada.SelectedIndex = nuevoIndice;
                listaSeleccionadaParaRetirar = listaActualizada;
            }

            lblEstado.Text =
                (PartidaConfig.EsLocalPvP
                    ? "El Jugador " + faseJugador + " retiró "
                    : "Retiraste ") +
                retirado.Nombre +
                ". Ahora puedes elegir otra carta del catálogo.";
        }

        private void ListaMazo_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            ListBox lista = sender as ListBox;

            if (lista != null && lista.SelectedIndex >= 0)
                listaSeleccionadaParaRetirar = lista;
        }

        private void BtnComenzar_Click(object sender, EventArgs e)
        {
            if (PartidaConfig.EsOnline)
            {
                if (!yoListo)
                {
                    EnviarMiMazo();
                    return;
                }

                if (mazoJugador2.Count != PartidaConfig.TamanoMazo ||
                    yoComienzo)
                    return;

                yoComienzo = true;
                btnComenzar.Enabled = false;
                lblEstado.Text = "Esperando a que el rival comience...";

                PartidaConfig.Red.Enviar("INICIO");
                CerrarSiAmbosComienzan();
                return;
            }

            if (mazoJugador1.Count != 5 || mazoJugador2.Count != 5)
            {
                MessageBox.Show("Cada equipo debe tener cinco cartas.");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnVolverModo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ActualizarListas()
        {
            listaSeleccionadaParaRetirar = null;

            lstMazoJugador.Items.Clear();

            foreach (Personaje p in mazoJugador1)
                lstMazoJugador.Items.Add(
                    p.Nombre + " - " + p.Clase + " - " + p.Elemento);

            lstMazoIA.Items.Clear();

            foreach (Personaje p in mazoJugador2)
                lstMazoIA.Items.Add(
                    p.Nombre + " - " + p.Clase + " - " + p.Elemento);

            if (PartidaConfig.EsLocalPvP)
            {
                lblJugador.Text =
                    "JUGADOR 1 (" + mazoJugador1.Count + "/5)";
                lblIA.Text =
                    "JUGADOR 2 (" + mazoJugador2.Count + "/5)";
            }
            else
            {
                lblJugador.Text =
                    PartidaConfig.EtiquetaMazoPropio(mazoJugador1.Count);
                lblIA.Text =
                    PartidaConfig.EtiquetaMazoOponente(mazoJugador2.Count);
            }

            bool completo = MazosCompletos();

            // Retirar se habilita desde la primera carta.
            if (PartidaConfig.EsOnline)
                btnRetirar.Enabled = !yoListo && mazoJugador1.Count > 0;
            else if (PartidaConfig.EsLocalPvP)
                btnRetirar.Enabled =
                    mazoJugador1.Count > 0 || mazoJugador2.Count > 0;
            else
                btnRetirar.Enabled = mazoJugador1.Count > 0;

            btnComenzar.Enabled =
                completo ||
                (PartidaConfig.EsOnline &&
                 yoListo &&
                 !yoComienzo &&
                 mazoJugador2.Count == PartidaConfig.TamanoMazo);
        }

        private bool MazosCompletos()
        {
            if (PartidaConfig.EsOnline)
                return mazoJugador1.Count == PartidaConfig.TamanoMazo &&
                    !yoListo;

            return mazoJugador1.Count == PartidaConfig.TamanoMazo &&
                mazoJugador2.Count == PartidaConfig.TamanoMazo;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (!PartidaConfig.EsOnline)
                return;

            GestorRed red = PartidaConfig.Red;

            if (red == null)
            {
                Abortar("No existe una conexión LAN activa.");
                return;
            }

            red.MensajeDisponible += Red_MensajeDisponible;
            red.ErrorOcurrido += Red_ErrorOcurrido;
            red.Desconectado += Red_Desconectado;

            if (!red.EstaConectado)
            {
                Abortar("Se perdió la conexión con el oponente.");
                return;
            }

            ProcesarBandejaSeleccion();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            GestorRed red = PartidaConfig.Red;

            if (red != null)
            {
                red.MensajeDisponible -= Red_MensajeDisponible;
                red.ErrorOcurrido -= Red_ErrorOcurrido;
                red.Desconectado -= Red_Desconectado;
            }

            base.OnFormClosed(e);
        }

        private void Red_MensajeDisponible(object sender, EventArgs e)
        {
            EnInterfaz(ProcesarBandejaSeleccion);
        }

        private void Red_ErrorOcurrido(
            object sender, ErrorRedEventArgs e)
        {
            string motivo = "Error de red: " + e.Mensaje;
            EnInterfaz(delegate { Abortar(motivo); });
        }

        private void Red_Desconectado(object sender, EventArgs e)
        {
            EnInterfaz(delegate { Abortar("Tu oponente se desconectó."); });
        }

        private void EnInterfaz(MethodInvoker accion)
        {
            if (IsDisposed || !IsHandleCreated)
                return;

            try
            {
                BeginInvoke(accion);
            }
            catch (ObjectDisposedException)
            {
            }
            catch (InvalidOperationException)
            {
            }
        }

        private void ProcesarBandejaSeleccion()
        {
            GestorRed red = PartidaConfig.Red;
            MensajeRed m;

            while (!cerrando && red != null && red.TryPeek(out m))
            {
                if (m.Tipo != ProtocoloMazo.TipoMensaje &&
                    m.Tipo != "INICIO")
                    break;

                red.TryLeer(out m);

                if (m.Tipo == "INICIO")
                {
                    rivalComienzo = true;
                }
                else
                {
                    List<Personaje> rival;
                    string error;

                    if (!ProtocoloMazo.TryDeserializar(
                        m.Datos, out rival, out error))
                    {
                        Abortar(error);
                        return;
                    }

                    mazoRivalPendiente = rival;
                }
            }

            RevelarRival();
            CerrarSiAmbosComienzan();
        }

        private void EnviarMiMazo()
        {
            if (mazoJugador1.Count != PartidaConfig.TamanoMazo ||
                yoListo)
                return;

            GestorRed red = PartidaConfig.Red;

            if (red == null || !red.EstaConectado)
            {
                Abortar("No hay conexión con el rival para enviar el mazo.");
                return;
            }

            yoListo = true;
            btnElegir.Enabled = false;
            btnRetirar.Enabled = false;
            btnComenzar.Enabled = false;

            red.Enviar(
                ProtocoloMazo.TipoMensaje,
                ProtocoloMazo.Serializar(mazoJugador1));

            lblEstado.Text = "Mazo enviado. Esperando al rival...";
            RevelarRival();
        }

        private void RevelarRival()
        {
            if (!yoListo ||
                mazoRivalPendiente == null ||
                mazoJugador2.Count > 0)
                return;

            mazoJugador2.Clear();
            mazoJugador2.AddRange(mazoRivalPendiente);

            ActualizarListas();

            btnComenzar.Text = "COMENZAR BATALLA";
            btnComenzar.Enabled = true;
            lblEstado.Text =
                "¡Mazo rival recibido! Pulsa COMENZAR BATALLA.";
        }

        private void CerrarSiAmbosComienzan()
        {
            if (cerrando || !yoComienzo || !rivalComienzo)
                return;

            cerrando = true;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Abortar(string motivo)
        {
            if (cerrando)
                return;

            cerrando = true;

            MessageBox.Show(
                motivo,
                "Chronos Arena",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ActualizarEstado()
        {
            lblEstado.Text =
                "Mazos completos. Puedes comenzar la batalla.";
        }

        private void LstMazoIASelectedIndexChanged(
            object sender, EventArgs e)
        {
            ListBox lista = sender as ListBox;

            if (lista != null && lista.SelectedIndex >= 0)
                listaSeleccionadaParaRetirar = lista;
        }
    }
}