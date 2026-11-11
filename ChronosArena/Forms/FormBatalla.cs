using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ChronosArena
{
    public partial class FormBatalla : Form
    {
        private List<Personaje> equipoJugador;
        private List<Personaje> equipoIA;

        private int indiceJugador;
        private int indiceIA;

        private GestorBatalla gestor;
        private NucleoBatalla nucleo;

        private Timer temporizadorTurno;
        private int segundosRestantes;

        private bool batallaTerminada;
        private bool turnoIAEnProceso;
        private Random random = new Random();

        // Evento global: una sola activación posible por partida.
        private bool terremotoOcurrido;
        private int probabilidadTerremoto;
        private DecisorIA decisorIA;
        private Timer temporizadorIA;

        // ----- Modo PvP local -----
        private bool modoPvP;
        private int turnoActual = 1; // 1 = Jugador 1 (izquierda), 2 = Jugador 2 / IA (derecha)
        private Color colorPnlJugadorOriginal;
        private Color colorPnlIAOriginal;
        private Color colorPnlAccionesOriginal;
        private Color colorAnuncioOriginal;

        private static readonly Color ColorTurnoJ1 = Color.FromArgb(25, 75, 150);
        private static readonly Color ColorTurnoJ2 = Color.FromArgb(150, 30, 40);
        private CartaAmbiente ambienteActivo;
        private Panel pnlAmbienteActivo;
        private PictureBox pbCartaAmbiente;
        private Label lblNombreAmbiente;
        private Label lblQuienEligioAmbiente;
        private RichTextBox rtbDescAmbiente;
        private Panel pnlMazoProximo;
        private Button btnPasarTurno;
        private ProgressBar pbCargas;
        private Label lblCargas;
        private Label lblReaccionTimer;
        private Label lblBannerTurno;
        private ToolTip ayudaControles;

        private Personaje JugadorActivo
        {
            get
            {
                if (indiceJugador >= 0 &&
                    indiceJugador < equipoJugador.Count)
                    return equipoJugador[indiceJugador];

                return null;
            }
        }

        private Personaje IAActiva
        {
            get
            {
                if (indiceIA >= 0 &&
                    indiceIA < equipoIA.Count)
                    return equipoIA[indiceIA];

                return null;
            }
        }


        // Personaje que ejecuta la acción en este turno.
        private Personaje Actor
        {
            get
            {
                return (modoPvP && turnoActual == 2) ? IAActiva : JugadorActivo;
            }
        }

        // Personaje que recibe la acción en este turno.
        private Personaje Objetivo
        {
            get
            {
                return (modoPvP && turnoActual == 2) ? JugadorActivo : IAActiva;
            }
        }

        private Personaje ActivoDeEquipo(int equipo)
        {
            return equipo == 1 ? JugadorActivo : IAActiva;
        }

        private void AvanzarIndice(int equipo)
        {
            if (equipo == 1)
                indiceJugador++;
            else
                indiceIA++;
        }

        private bool PuedeRelevarActual()
        {
            if (modoPvP && turnoActual == 2)
                return indiceIA < equipoIA.Count - 1;

            return indiceJugador < equipoJugador.Count - 1;
        }

        private string NombreEquipo(int equipo)
        {
            if (PartidaConfig.EsVsIA)
                return equipo == 1 ? PartidaConfig.NombreJugador1 : "La computadora";
            return equipo == 1 ? PartidaConfig.NombreJugador1 : PartidaConfig.NombreJugador2;
        }

        // El núcleo devuelve "Jugador" / "IA" / "Empate"; en PvP se traduce.
        private string NombreGanadorHistorial(string ganador)
        {
            if (!modoPvP)
                return ganador;

            if (ganador == "Jugador") return "Jugador 1";
            if (ganador == "IA") return "Jugador 2";
            return ganador;
        }

        public FormBatalla()
        {
            InitializeComponent();
            DoubleBuffered = true;
            PantallaCompleta.Instalar(this);
            EscaladorInterfaz.Instalar(this);
        }

        public FormBatalla(
            List<Personaje> jugador,
            List<Personaje> ia) : this()
        {
            if (jugador == null || ia == null)
                throw new ArgumentNullException("Los dos equipos deben existir.");

            equipoJugador = jugador.Where(p => p != null)
                .Select(p => p.Clonar()).ToList();
            equipoIA = ia.Where(p => p != null)
                .Select(p => p.Clonar()).ToList();

            if (equipoJugador.Count == 0 || equipoIA.Count == 0)
                throw new ArgumentException("Cada equipo debe contener al menos un personaje.");

            gestor = new GestorBatalla();
            nucleo = new NucleoBatalla();
            random = new Random();

            decisorIA = new DecisorIA(random);
            temporizadorIA = new Timer();
            temporizadorIA.Interval = 900; // la IA "piensa" 0,9 s sin congelar la ventana
            temporizadorIA.Tick += TemporizadorIA_Tick;

            modoPvP = PartidaConfig.EsModoPvP;
            turnoActual = PartidaConfig.EquipoInicial;
            ambienteActivo = PartidaConfig.AmbienteActivo;
            nucleo.AmbienteActivo = ambienteActivo;
            if (ambienteActivo != null)
            {
                foreach (Personaje personaje in equipoJugador) ambienteActivo.AplicarEfectosPasivos(personaje);
                foreach (Personaje personaje in equipoIA) ambienteActivo.AplicarEfectosPasivos(personaje);
            }
            if (PartidaConfig.EsOnline && PartidaConfig.Red != null)
                miEquipo = PartidaConfig.Red.EsAnfitrion ? 1 : 2;
            gestor.ModoPvP = modoPvP;

            colorPnlJugadorOriginal = pnlJugador.BackColor;
            colorPnlIAOriginal = pnlIA.BackColor;
            colorPnlAccionesOriginal = pnlAcciones.BackColor;
            colorAnuncioOriginal = lblAnuncio.BackColor;

            indiceJugador = 0;
            indiceIA = 0;
            batallaTerminada = false;
            turnoIAEnProceso = false;

            temporizadorTurno = new Timer();
            temporizadorTurno.Interval = 1000;
            temporizadorTurno.Tick += TemporizadorTurno_Tick;

            CargarFondoArena();
            CrearControlesAmbienteYReserva();
            ActualizarInterfaz();

            AgregarRegistro("La batalla de Chronos Arena ha comenzado.");
            if (ambienteActivo != null)
                AgregarRegistro("Ambiente activo: " + ambienteActivo.Nombre + ". Elegido por " + PartidaConfig.AmbienteElegidoPor + ".");
            if (modoPvP)
                AgregarRegistro("Turno inicial: " + NombreEquipo(turnoActual) + ". Tiene 30 segundos para realizar su acción.");
            else
                AgregarRegistro("Tienes 30 segundos para realizar tu acción.");

            if (!modoPvP && PartidaConfig.EquipoInicial == 2)
                EjecutarTurnoIA();
            else if (!PartidaConfig.EsOnline)
                IniciarTemporizadorTurno();

            FormClosing += FormBatalla_FormClosing;
            FormClosed += delegate
            {
                if (temporizadorTurno != null)
                    temporizadorTurno.Dispose();
                if (temporizadorIA != null)
                    temporizadorIA.Dispose();
                if (ayudaControles != null) ayudaControles.Dispose();
                if (pbCartaAmbiente != null && pbCartaAmbiente.Image != null) pbCartaAmbiente.Image.Dispose();
            };
        }

        private void CargarFondoArena()
        {
            string url;
            Dictionary<string, string> urls = GestorMazo.ObtenerUrls();
            if (!urls.TryGetValue("fondo:batalla", out url) ||
                String.IsNullOrWhiteSpace(url))
            {
                url = String.Empty;
            }

            picFondo.BackColor = Color.FromArgb(18, 23, 35);
            // Todas las imagenes se leen desde ./Imagenes. No se usa
            // LoadAsync ni se realiza una solicitud HTTP durante la partida.
            try
            {
                if (!String.IsNullOrWhiteSpace(url))
                    CargadorLocal.CargarImagen(picFondo, System.IO.Path.GetFileName(url));
            }
            catch (Exception)
            {
                picFondo.Image = null;
            }
        }

        private void AgregarRegistro(string mensaje)
        {
            txtRegistro.AppendText(
                DateTime.Now.ToString("HH:mm:ss") +
                "  " + mensaje +
                Environment.NewLine);

            txtRegistro.SelectionStart =
                txtRegistro.Text.Length;

            txtRegistro.ScrollToCaret();

            gestor.Registrar(mensaje);
        }

        // La probabilidad aumenta 5 puntos porcentuales por cada turno
        // completado. El evento solo puede ocurrir una vez en la partida.
        private void ProcesarTurnoTerremoto()
        {
            if (terremotoOcurrido || batallaTerminada)
                return;

            probabilidadTerremoto = Math.Min(100, probabilidadTerremoto + 5);

            // En LAN el anfitrión realiza el sorteo y comunica el resultado,
            // evitando que cada computadora obtenga un resultado diferente.
            if (esOnline && (red == null || !red.EsAnfitrion))
                return;

            int sorteo = random.Next(1, 101);
            if (sorteo <= probabilidadTerremoto)
            {
                AplicarTerremoto();

                if (esOnline && red != null)
                    red.Enviar("TERREMOTO");
            }
        }

        private void AplicarTerremoto()
        {
            if (terremotoOcurrido)
                return;

            terremotoOcurrido = true;
            AgregarRegistro(
                "¡¡TERREMOTO!! El evento global ha afectado a ambos equipos: -5 de vida y -3 de defensa para cada personaje.");

            foreach (Personaje personaje in equipoJugador)
            {
                if (personaje == null) continue;
                int vidaAntes = personaje.Vida;
                int defensaAntes = personaje.Defensa;
                personaje.RecibirTerremoto(5, 3);
                AgregarRegistro(
                    personaje.Nombre + " (Jugador): Vida " + vidaAntes +
                    " -> " + personaje.Vida + ", Defensa " + defensaAntes +
                    " -> " + personaje.Defensa + ".");
            }

            foreach (Personaje personaje in equipoIA)
            {
                if (personaje == null) continue;
                int vidaAntes = personaje.Vida;
                int defensaAntes = personaje.Defensa;
                personaje.RecibirTerremoto(5, 3);
                AgregarRegistro(
                    personaje.Nombre + " (Rival/IA): Vida " + vidaAntes +
                    " -> " + personaje.Vida + ", Defensa " + defensaAntes +
                    " -> " + personaje.Defensa + ".");
            }
        }

        private void ActualizarInterfaz()
        {
            Personaje jugador = JugadorActivo;
            Personaje ia = IAActiva;

            if (jugador == null || ia == null)
            {
                FinalizarBatalla();
                return;
            }

            int ataqueJugador = ambienteActivo == null ? jugador.Ataque : ambienteActivo.CalcularAtaqueConAmbiente(jugador.Ataque, jugador.Faccion);
            int ataqueOponente = ambienteActivo == null ? ia.Ataque : ambienteActivo.CalcularAtaqueConAmbiente(ia.Ataque, ia.Faccion);
            lblJugador.Text =
                (modoPvP ? PartidaConfig.NombreJugador1 : PartidaConfig.NombreJugador1) + ": " + jugador.Nombre + " (" + jugador.Clase + ")" +
                "\r\nFaccion: " + jugador.Faccion + " | Elemento: " + jugador.Elemento +
                "\r\nATK: " + ataqueJugador + " | DEF: " + jugador.Defensa;

            lblIA.Text =
                (modoPvP ? PartidaConfig.NombreJugador2 : "COMPUTADORA") + ": " + ia.Nombre + " (" + ia.Clase + ")" +
                "\r\nFaccion: " + ia.Faccion + " | Elemento: " + ia.Elemento +
                "\r\nATK: " + ataqueOponente + " | DEF: " + ia.Defensa;

            barraVidaJugador.Maximum =
                Math.Max(1, jugador.VidaMax);

            barraVidaJugador.Value =
                Math.Max(0, Math.Min(
                    jugador.Vida,
                    barraVidaJugador.Maximum));

            barraVidaIA.Maximum =
                Math.Max(1, ia.VidaMax);

            barraVidaIA.Value =
                Math.Max(0, Math.Min(
                    ia.Vida,
                    barraVidaIA.Maximum));

            lblVidaJugador.Text =
                jugador.Vida + " / " +
                jugador.VidaMax + " HP";

            lblVidaIA.Text =
                ia.Vida + " / " +
                ia.VidaMax + " HP";

            barraEnergiaJugador.Value = Math.Max(0, Math.Min(100, jugador.Energia));
            barraManaJugador.Value = Math.Max(0, Math.Min(100, jugador.Mana));
            barraEnergiaIA.Value = Math.Max(0, Math.Min(100, ia.Energia));
            barraManaIA.Value = Math.Max(0, Math.Min(100, ia.Mana));

            lblEnergiaJugador.Text = "ENERGÍA: " + jugador.Energia + " / 100";
            lblManaJugador.Text = "MANÁ: " + jugador.Mana + " / 100";
            lblEnergiaIA.Text = "ENERGÍA: " + ia.Energia + " / 100";
            lblManaIA.Text = "MANÁ: " + ia.Mana + " / 100";
            lblEspecialJugador.Text = "ESPECIAL: " + jugador.CargasEspecial + "/2";
            lblEspecialIA.Text = "ESPECIAL: " + ia.CargasEspecial + "/2";
            barraEspecialJugador.Value = Math.Max(0, Math.Min(2, jugador.CargasEspecial));
            barraEspecialIA.Value = Math.Max(0, Math.Min(2, ia.CargasEspecial));
            lblEmpatiaJugador.Text = "EMPATIA: " + jugador.Empatia + "/10";
            lblEmpatiaIA.Text = "EMPATIA: " + ia.Empatia + "/10";

            CargarImagen(picJugador, jugador.ImagenUrl);
            CargarImagen(picIA, ia.ImagenUrl);

            if (modoPvP)
            {
                lblAnuncio.Text =
                    "ES TURNO DE: " + NombreEquipo(turnoActual).ToUpperInvariant() +
                    (esOnline && !EsMiTurno ? " (ESPERANDO AL RIVAL)" : String.Empty) +
                    "  |  EQUIPOS: " + (equipoJugador.Count - indiceJugador) +
                    " vs " + (equipoIA.Count - indiceIA);

                AplicarIndicadorTurnoPvP();
            }
            else
            {
                lblAnuncio.Text =
                    "ES TURNO DE: " +
                    (turnoIAEnProceso ? "COMPUTADORA" : PartidaConfig.NombreJugador1).ToUpperInvariant() +
                    "  |  EQUIPOS: " + (equipoJugador.Count - indiceJugador) +
                    " vs " + (equipoIA.Count - indiceIA);
            }

            bool habilitado =
                !batallaTerminada && !turnoIAEnProceso && EsMiTurno;

            btnAtaque.Enabled = habilitado && Actor != null && Actor.Energia >= 10;
            btnEspecial.Enabled = habilitado && Actor != null && Actor.PuedeUsarEspecial() && Actor.Mana >= 20;
            btnDefensa.Enabled = habilitado;

            btnRelevar.Enabled = habilitado && PuedeRelevarActual();
            if (btnPasarTurno != null) btnPasarTurno.Enabled = habilitado;
            int cargasActuales = Actor == null ? 0 : Actor.CargasEspecial;
            btnEspecial.Text = "ESPECIAL";
            if (pbCargas != null) pbCargas.Value = Math.Max(0, Math.Min(2, cargasActuales));
            if (lblCargas != null) lblCargas.Text = "CARGAS DE ESPECIAL: " + cargasActuales + "/2";
            if (lblTemporizador != null && segundosRestantes > 0)
                lblTemporizador.Text = "TIMER: " + segundosRestantes + " s";
            ActualizarPanelAmbiente();
            ActualizarMazoProximo();
        }

        // Resalta el panel del jugador en turno y tiñe la barra de acciones
        // con su color, para que quede claro quién debe jugar.
        private void AplicarIndicadorTurnoPvP()
        {
            bool turnoJ1 = (turnoActual == 1);

            pnlJugador.BackColor = turnoJ1 ? ColorTurnoJ1 : colorPnlJugadorOriginal;
            pnlIA.BackColor = turnoJ1 ? colorPnlIAOriginal : ColorTurnoJ2;
            pnlAcciones.BackColor = turnoJ1 ? ColorTurnoJ1 : ColorTurnoJ2;
            lblAnuncio.BackColor = turnoJ1 ? ColorTurnoJ1 : ColorTurnoJ2;
        }

        private void CrearControlesAmbienteYReserva()
{
    lblBannerTurno = lblAnuncio;
    lblBannerTurno.Name = "lblBannerTurno";

    pnlAmbienteActivo = new Panel();
    pnlAmbienteActivo.Name = "pnlAmbienteActivo";
    pnlAmbienteActivo.Location = new Point(305, 335);
    pnlAmbienteActivo.Size = new Size(670, 140);
    pnlAmbienteActivo.BackColor = Color.FromArgb(225, 18, 27, 42);
    pnlAmbienteActivo.BorderStyle = BorderStyle.FixedSingle;

    pbCartaAmbiente = new PictureBox();
    pbCartaAmbiente.Name = "pbCartaAmbiente";
    pbCartaAmbiente.Location = new Point(8, 8);
    pbCartaAmbiente.Size = new Size(120, 122);
    pbCartaAmbiente.SizeMode = PictureBoxSizeMode.Zoom;
    pbCartaAmbiente.BackColor = Color.FromArgb(10, 15, 24);
    pbCartaAmbiente.BorderStyle = BorderStyle.FixedSingle;
    pnlAmbienteActivo.Controls.Add(pbCartaAmbiente);

    lblNombreAmbiente = new Label();
    lblNombreAmbiente.Name = "lblNombreAmbiente";
    lblNombreAmbiente.Location = new Point(140, 7);
    lblNombreAmbiente.Size = new Size(510, 27);
    lblNombreAmbiente.Font =
        new Font("Courier New", 12F, FontStyle.Bold);
    lblNombreAmbiente.ForeColor = Color.Gold;
    pnlAmbienteActivo.Controls.Add(lblNombreAmbiente);

    lblQuienEligioAmbiente = new Label();
    lblQuienEligioAmbiente.Name = "lblQuienEligioAmbiente";
    lblQuienEligioAmbiente.Location = new Point(140, 34);
    lblQuienEligioAmbiente.Size = new Size(510, 22);
    lblQuienEligioAmbiente.Font =
        new Font("Courier New", 8F, FontStyle.Bold);
    lblQuienEligioAmbiente.ForeColor = Color.LightSkyBlue;
    pnlAmbienteActivo.Controls.Add(lblQuienEligioAmbiente);

    rtbDescAmbiente = new RichTextBox();
    rtbDescAmbiente.Name = "rtbDescAmbiente";
    rtbDescAmbiente.Location = new Point(140, 60);
    rtbDescAmbiente.Size = new Size(510, 70);
    rtbDescAmbiente.ReadOnly = true;
    rtbDescAmbiente.BorderStyle = BorderStyle.None;

    // IMPORTANTE: color sólido, sin transparencia.
    rtbDescAmbiente.BackColor = Color.FromArgb(18, 27, 42);

    rtbDescAmbiente.ForeColor = Color.White;
    rtbDescAmbiente.Font = new Font("Courier New", 7.5F);
    pnlAmbienteActivo.Controls.Add(rtbDescAmbiente);

    Controls.Add(pnlAmbienteActivo);

    pnlMazoProximo = new Panel();
    pnlMazoProximo.Name = "pnlMazoProximo";
    pnlMazoProximo.Location = new Point(535, 485);
    pnlMazoProximo.Size = new Size(440, 230);
    pnlMazoProximo.BackColor = Color.FromArgb(225, 18, 27, 42);
    pnlMazoProximo.BorderStyle = BorderStyle.FixedSingle;

    Label tituloReservas = new Label();
    tituloReservas.Text = "PROXIMAS CARTAS";
    tituloReservas.Location = new Point(10, 8);
    tituloReservas.Size = new Size(410, 22);
    tituloReservas.ForeColor = Color.Gold;
    tituloReservas.Font =
        new Font("Courier New", 9F, FontStyle.Bold);

    pnlMazoProximo.Controls.Add(tituloReservas);
    Controls.Add(pnlMazoProximo);

    pnlAcciones.Location = new Point(305, 485);
    pnlAcciones.Size = new Size(220, 230);

    btnAtaque.Location = new Point(10, 8);
    btnAtaque.Size = new Size(196, 30);
    btnAtaque.Font =
        new Font("Courier New", 9F, FontStyle.Bold);

    btnEspecial.Location = new Point(10, 42);
    btnEspecial.Size = new Size(196, 30);
    btnEspecial.Font =
        new Font("Courier New", 9F, FontStyle.Bold);

    btnDefensa.Location = new Point(10, 105);
    btnDefensa.Size = new Size(196, 30);
    btnDefensa.Font =
        new Font("Courier New", 8.2F, FontStyle.Bold);

    btnRelevar.Location = new Point(10, 139);
    btnRelevar.Size = new Size(196, 30);
    btnRelevar.Text = "RELEVAR CARTA";
    btnRelevar.Font =
        new Font("Courier New", 9F, FontStyle.Bold);

    lblCargas = new Label();
    lblCargas.Name = "lblCargas";
    lblCargas.Text = "CARGAS DE ESPECIAL: 0/2";
    lblCargas.Location = new Point(12, 75);
    lblCargas.Size = new Size(196, 14);
    lblCargas.ForeColor = Color.White;
    lblCargas.Font =
        new Font("Courier New", 7.5F, FontStyle.Bold);
    pnlAcciones.Controls.Add(lblCargas);

    pbCargas = new ProgressBar();
    pbCargas.Name = "pbCargas";
    pbCargas.Location = new Point(12, 90);
    pbCargas.Size = new Size(196, 9);
    pbCargas.Minimum = 0;
    pbCargas.Maximum = 2;
    pbCargas.Value = 0;
    pbCargas.Style = ProgressBarStyle.Continuous;
    pnlAcciones.Controls.Add(pbCargas);

    btnPasarTurno = new Button();
    btnPasarTurno.Name = "btnPasarTurno";
    btnPasarTurno.Text = "PASAR TURNO";
    btnPasarTurno.Location = new Point(10, 181);
    btnPasarTurno.Size = new Size(196, 30);
    btnPasarTurno.BackColor = Color.FromArgb(72, 83, 103);
    btnPasarTurno.ForeColor = Color.White;
    btnPasarTurno.FlatStyle = FlatStyle.Flat;
    btnPasarTurno.Font =
        new Font("Courier New", 8.5F, FontStyle.Bold);
    btnPasarTurno.Click += BtnPasarTurno_Click;
    pnlAcciones.Controls.Add(btnPasarTurno);

    btnVolver.Text = "MENU";
    btnVolver.Location = new Point(535, 720);
    btnVolver.Size = new Size(440, 30);
    btnVolver.BackColor = Color.FromArgb(115, 218, 240);
    btnVolver.ForeColor = Color.Black;
    btnVolver.Font =
        new Font("Courier New", 10F, FontStyle.Bold);

    lblTemporizador.Location = new Point(990, 70);
    lblTemporizador.Size = new Size(270, 28);
    lblTemporizador.BackColor = Color.FromArgb(242, 198, 139);
    lblTemporizador.ForeColor = Color.Black;
    lblTemporizador.Font =
        new Font("Georgia", 14F, FontStyle.Bold);
    lblTemporizador.TextAlign = ContentAlignment.MiddleCenter;

    lblReaccionTimer = new Label();
    lblReaccionTimer.Name = "lblReaccionTimer";
    lblReaccionTimer.Text = "TIENES 30 S PARA REACCIONAR";
    lblReaccionTimer.Location = new Point(990, 100);
    lblReaccionTimer.Size = new Size(270, 32);
    lblReaccionTimer.BackColor = Color.FromArgb(242, 198, 139);
    lblReaccionTimer.ForeColor = Color.Black;
    lblReaccionTimer.Font =
        new Font("Courier New", 8F, FontStyle.Bold);
    lblReaccionTimer.TextAlign = ContentAlignment.MiddleCenter;
    Controls.Add(lblReaccionTimer);

    btnAtaque.BackColor = Color.FromArgb(246, 193, 169);
    btnEspecial.BackColor = Color.FromArgb(135, 216, 241);
    btnDefensa.BackColor = Color.FromArgb(224, 157, 218);
    btnRelevar.BackColor = Color.FromArgb(255, 190, 0);

    btnAtaque.ForeColor = Color.Black;
    btnEspecial.ForeColor = Color.Black;
    btnDefensa.ForeColor = Color.Black;
    btnRelevar.ForeColor = Color.Black;

    btnAtaque.FlatAppearance.BorderColor = Color.White;
    btnEspecial.FlatAppearance.BorderColor = Color.White;
    btnDefensa.FlatAppearance.BorderColor = Color.White;
    btnRelevar.FlatAppearance.BorderColor = Color.White;

    btnAtaque.FlatAppearance.BorderSize = 2;
    btnEspecial.FlatAppearance.BorderSize = 2;
    btnDefensa.FlatAppearance.BorderSize = 2;
    btnRelevar.FlatAppearance.BorderSize = 2;

    ayudaControles = new ToolTip();

    ayudaControles.SetToolTip(
        btnEspecial,
        "La habilidad especial requiere 2 cargas y 20 puntos de mana. " +
        "El indicador muestra tu progreso: 0/2, 1/2 o 2/2.");

    ayudaControles.SetToolTip(
        btnPasarTurno,
        "Termina tu turno sin atacar y obtiene una carga de especial.");
}
        private void ActualizarPanelAmbiente()
        {
            if (ambienteActivo == null || pnlAmbienteActivo == null) return;
            lblNombreAmbiente.Text = "AMBIENTE ACTIVO: " + ambienteActivo.Nombre.ToUpperInvariant();
            lblQuienEligioAmbiente.Text = "ELEGIDO POR: " + PartidaConfig.AmbienteElegidoPor;
            rtbDescAmbiente.Text = ambienteActivo.Resumen + "\r\n" + ambienteActivo.Descripcion;
            if (pbCartaAmbiente.Image == null)
                CargadorLocal.CargarImagen(pbCartaAmbiente, ambienteActivo.ImagenUrl);
        }

        private void ActualizarMazoProximo()
        {
            if (pnlMazoProximo == null || equipoJugador == null || equipoIA == null) return;
            List<Personaje> mazoActivo = (modoPvP && turnoActual == 2) ? equipoIA : equipoJugador;
            int indiceActivo = (modoPvP && turnoActual == 2) ? indiceIA : indiceJugador;
            while (pnlMazoProximo.Controls.Count > 1)
            {
                Control anterior = pnlMazoProximo.Controls[1];
                pnlMazoProximo.Controls.RemoveAt(1);
                anterior.Dispose();
            }

            int x = 9;
            int mostradas = 0;
            for (int i = indiceActivo + 1; i < mazoActivo.Count && mostradas < 4; i++, mostradas++)
            {
                Panel carta = new Panel();
                carta.Location = new Point(x, 35);
                carta.Size = new Size(100, 180);
                carta.BackColor = Color.FromArgb(43, 55, 75);
                carta.BorderStyle = BorderStyle.FixedSingle;
                PictureBox imagen = new PictureBox();
                imagen.Location = new Point(5, 4);
                imagen.Size = new Size(88, 132);
                imagen.SizeMode = PictureBoxSizeMode.Zoom;
                imagen.BackColor = Color.FromArgb(10, 15, 24);
                CargadorLocal.CargarImagen(imagen, System.IO.Path.GetFileName(mazoActivo[i].ImagenUrl));
                carta.Controls.Add(imagen);
                Label nombre = new Label();
                nombre.Text = mazoActivo[i].Nombre;
                nombre.Location = new Point(3, 139);
                nombre.Size = new Size(94, 36);
                nombre.TextAlign = ContentAlignment.MiddleCenter;
                nombre.ForeColor = Color.White;
                nombre.Font = new Font("Courier New", 6.8F, FontStyle.Bold);
                carta.Controls.Add(nombre);
                pnlMazoProximo.Controls.Add(carta);
                x += 105;
            }
            if (mostradas == 0)
            {
                Label vacio = new Label();
                vacio.Text = "SIN CARTAS DE RESERVA";
                vacio.Location = new Point(15, 70);
                vacio.Size = new Size(410, 35);
                vacio.ForeColor = Color.LightGray;
                vacio.TextAlign = ContentAlignment.MiddleCenter;
                pnlMazoProximo.Controls.Add(vacio);
            }
        }

        private void BtnPasarTurno_Click(object sender, EventArgs e)
        {
            if (!PuedeActuar()) return;
            EnviarAccionRed("PASAR");
            AgregarRegistro(NombreEquipo(turnoActual) + " pasa el turno y carga su especial.");
            ResolverAccionJugador();
        }

        private void CargarImagen(
            PictureBox cuadro,
            string url)
        {
            if (cuadro == null)
                return;

            if (String.IsNullOrEmpty(url))
            {
                cuadro.Image = null;
                return;
            }

            try
            {
                CargadorLocal.CargarImagen(cuadro, System.IO.Path.GetFileName(url));
            }
            catch
            {
                cuadro.Image = null;
            }
        }

        // ATAQUE NORMAL
        private void BtnAtaque_Click(
            object sender,
            EventArgs e)
        {
            if (!PuedeActuar())
                return;

            if (!nucleo.PuedeUsarEnergia(Actor, 10))
            {
                MessageBox.Show(
                    "No tienes suficiente energía para atacar. Usa DEFENSA / RECUPERAR para restaurar energía y maná.",
                    "Chronos Arena",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                IniciarTemporizadorTurno();
                return;
            }

            EnviarAccionRed("ATAQUE");

            int dano = nucleo.EjecutarAtaque(
                Actor,
                Objetivo);

            AgregarRegistro(
                Actor.Nombre +
                " ataca a " + Objetivo.Nombre +
                " e inflige " + dano + " de daño.");

            ResolverAccionJugador();
        }

        // HABILIDAD ESPECIAL
        private void BtnEspecial_Click(
            object sender,
            EventArgs e)
        {
            if (!PuedeActuar())
                return;

            if (!Actor.PuedeUsarEspecial())
            {
                MessageBox.Show("Necesitas 2 cargas para activar la habilidad especial. Pasa turnos o completa acciones.", "Chronos Arena");
                IniciarTemporizadorTurno();
                return;
            }
            if (!nucleo.PuedeUsarMana(Actor, 20))
            {
                MessageBox.Show(
                    "No tienes suficiente maná para usar la habilidad especial.",
                    "Chronos Arena",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                IniciarTemporizadorTurno();
                return;
            }

            EnviarAccionRed("ESPECIAL");

            string resultado =
                nucleo.EjecutarHabilidad(
                    Actor,
                    Objetivo);

            Actor.ConsumirCargaEspecial();
            AgregarRegistro(resultado);

            ResolverAccionJugador();
        }

        // DEFENSA
        private void BtnDefensa_Click(
            object sender,
            EventArgs e)
        {
            if (!PuedeActuar())
                return;

            Personaje defensor = Actor;
            int energiaAnterior = defensor.Energia;
            int manaAnterior = defensor.Mana;
            int defensaAnterior = defensor.Defensa;

            EnviarAccionRed("DEFENSA");

            nucleo.EjecutarDefensa(defensor);

            AgregarRegistro(
                defensor.Nombre + " se defiende: +" +
                (defensor.Energia - energiaAnterior) + " energía, +" +
                (defensor.Mana - manaAnterior) + " maná y +" +
                (defensor.Defensa - defensaAnterior) + " defensa.");

            ResolverAccionJugador();
        }

        // RELEVAR PERSONAJE
        private void BtnRelevar_Click(
            object sender,
            EventArgs e)
        {
            if (!PuedeActuar())
                return;

            if (!PuedeRelevarActual())
            {
                MessageBox.Show(
                    "No tienes más personajes disponibles para relevar.",
                    "Chronos Arena");
                IniciarTemporizadorTurno();
                return;
            }

            EnviarAccionRed("RELEVAR");

            Personaje personajeQueActuo = Actor;
            int equipo = (modoPvP && turnoActual == 2) ? 2 : 1;

            AvanzarIndice(equipo);

            AgregarRegistro(
                NombreEquipo(equipo) +
                " releva a su personaje. Entra " +
                ActivoDeEquipo(equipo).Nombre + ".");

            if (modoPvP)
            {
                ResolverAccionPvP(personajeQueActuo);
                return;
            }

            if (personajeQueActuo != null) personajeQueActuo.CargarEspecial();
            ProcesarTurnoTerremoto();
            if (ResolverJugadorDerrotadoPorEvento())
                return;
            ActualizarInterfaz();

            EjecutarTurnoIA();
        }

        private bool PuedeActuar()
        {
            if (batallaTerminada || turnoIAEnProceso)
                return false;

            // En línea solo actúa quien tiene el turno (salvo que se esté
            // reproduciendo la acción del rival).
            if (esOnline && !aplicandoRemoto && turnoActual != miEquipo)
                return false;

            if (Actor == null || Objetivo == null)
            {
                FinalizarBatalla();
                return false;
            }

            temporizadorTurno.Stop();

            return true;
        }

        // ---------- MODO PvP LOCAL ----------

        // Cierra el turno del jugador actual: resuelve derrotas,
        // pasa el control al otro jugador y reinicia el reloj.
        private void ResolverAccionPvP()
        {
            ResolverAccionPvP(Actor);
        }

        private void ResolverAccionPvP(Personaje personajeQueActuo)
        {
            if (personajeQueActuo != null) personajeQueActuo.CargarEspecial();
            ProcesarTurnoTerremoto();
            ResolverDerrotasPvP();

            if (batallaTerminada)
                return;

            turnoActual = (turnoActual == 1) ? 2 : 1;

            AgregarRegistro(
                "Turno del " + NombreEquipo(turnoActual) + ".");

            ActualizarInterfaz();

            // En LAN, solo la computadora cuyo jugador tiene el turno debe
            // contar los 30 segundos. La otra muestra que está esperando.
            if (!esOnline || EsMiTurno)
            {
                IniciarTemporizadorTurno();
            }
            else
            {
                temporizadorTurno.Stop();
                segundosRestantes = nucleo.DuracionTurnoSegundos;
                lblTemporizador.Text = "ESPERANDO TURNO";
            }
        }

        private void ResolverDerrotasPvP()
        {
            for (int equipo = 1; equipo <= 2; equipo++)
            {
                Personaje activo = ActivoDeEquipo(equipo);

                if (activo != null && activo.Vida <= 0)
                {
                    AgregarRegistro(
                        activo.Nombre + " ha sido derrotado.");

                    AvanzarIndice(equipo);

                    Personaje nuevo = ActivoDeEquipo(equipo);

                    if (nuevo == null)
                    {
                        FinalizarBatalla();
                        return;
                    }

                    AgregarRegistro(
                        NombreEquipo(equipo) + " envía a " +
                        nuevo.Nombre + ".");
                }
            }
        }

        private void ResolverAccionJugador()
        {
            if (modoPvP)
            {
                ResolverAccionPvP();
                return;
            }

            if (JugadorActivo != null) JugadorActivo.CargarEspecial();
            ProcesarTurnoTerremoto();

            // El terremoto también puede derrotar al personaje activo del jugador.
            if (ResolverJugadorDerrotadoPorEvento())
                return;

            if (IAActiva != null && IAActiva.Vida <= 0)
            {
                AgregarRegistro(
                    IAActiva.Nombre + " ha sido derrotado.");

                indiceIA++;

                if (IAActiva == null)
                {
                    FinalizarBatalla();
                    return;
                }

                AgregarRegistro(
                    "La computadora envía a " +
                    IAActiva.Nombre + ".");
            }

            ActualizarInterfaz();

            EjecutarTurnoIA();
        }

        private bool ResolverJugadorDerrotadoPorEvento()
        {
            if (JugadorActivo == null || JugadorActivo.Vida > 0)
                return batallaTerminada;

            AgregarRegistro(JugadorActivo.Nombre + " ha sido derrotado por el terremoto.");
            indiceJugador++;

            if (JugadorActivo == null)
            {
                FinalizarBatalla();
                return true;
            }

            AgregarRegistro("Entra " + JugadorActivo.Nombre + " al combate.");
            return false;
        }

        // TURNO DE LA COMPUTADORA
        private void EjecutarTurnoIA()
        {
            if (batallaTerminada)
                return;

            temporizadorTurno.Stop();

            if (JugadorActivo == null || IAActiva == null)
            {
                FinalizarBatalla();
                return;
            }

            turnoIAEnProceso = true;
            ActualizarInterfaz();     // "TURNO DE LA IA" con los botones bloqueados
            temporizadorIA.Start();   // Timer de WinForms: la ventana sigue respondiendo
        }

        private void TemporizadorIA_Tick(object sender, EventArgs e)
        {
            temporizadorIA.Stop();

            if (batallaTerminada)
                return;

            if (IAActiva != null && IAActiva.Vida <= 0)
                indiceIA++;

            Personaje ia = IAActiva;
            Personaje jugador = JugadorActivo;

            if (ia == null || jugador == null)
            {
                turnoIAEnProceso = false;
                FinalizarBatalla();
                return;
            }

            bool puedeRelevar = indiceIA < equipoIA.Count - 1;

            switch (decisorIA.Decidir(ia, jugador, puedeRelevar))
            {
                case AccionIA.Atacar:
                    {
                        int dano = nucleo.EjecutarAtaque(ia, jugador);
                        AgregarRegistro(
                            "La computadora ataca con " + ia.Nombre +
                            " e inflige " + dano + " de daño.");
                        break;
                    }
                case AccionIA.Especial:
                    {
                        AgregarRegistro(
                            "La computadora usa su especial: " +
                            nucleo.EjecutarHabilidad(ia, jugador));
                        ia.ConsumirCargaEspecial();
                        break;
                    }
                case AccionIA.Curar:
                    {
                        int curado = nucleo.EjecutarCuracion(ia);
                        AgregarRegistro(
                            ia.Nombre + " recupera " + curado +
                            " puntos de vida.");
                        break;
                    }
                case AccionIA.Relevar:
                    {
                        indiceIA++;
                        AgregarRegistro(
                            "La computadora releva a su personaje. Entra " +
                            IAActiva.Nombre + ".");
                        break;
                    }
                default: // Defender
                    {
                        int energiaAnterior = ia.Energia;
                        int manaAnterior = ia.Mana;
                        int defensaAnterior = ia.Defensa;
                        nucleo.EjecutarDefensa(ia);
                        AgregarRegistro(
                            ia.Nombre + " se defiende: +" +
                            (ia.Energia - energiaAnterior) + " energía, +" +
                            (ia.Mana - manaAnterior) + " maná y +" +
                            (ia.Defensa - defensaAnterior) + " defensa.");
                        break;
                    }
            }

            ia.CargarEspecial();
            turnoIAEnProceso = false;

            ResolverDerrotasDespuesDeIA();
        }

        private void ResolverDerrotasDespuesDeIA()
        {
            ProcesarTurnoTerremoto();

            if (JugadorActivo != null &&
                JugadorActivo.Vida <= 0)
            {
                AgregarRegistro(
                    JugadorActivo.Nombre +
                    " ha sido derrotado.");

                indiceJugador++;

                if (JugadorActivo == null)
                {
                    FinalizarBatalla();
                    return;
                }

                AgregarRegistro(
                    "Entra " + JugadorActivo.Nombre +
                    " al combate.");
            }

            if (IAActiva != null &&
                IAActiva.Vida <= 0)
            {
                AgregarRegistro(
                    IAActiva.Nombre +
                    " ha sido derrotado.");

                indiceIA++;

                if (IAActiva == null)
                {
                    FinalizarBatalla();
                    return;
                }

                AgregarRegistro(
                    "La computadora envía a " +
                    IAActiva.Nombre + ".");
            }

            ActualizarInterfaz();

            IniciarTemporizadorTurno();
        }

        // TEMPORIZADOR
        private void IniciarTemporizadorTurno()
        {
            if (batallaTerminada)
                return;

            segundosRestantes =
                nucleo.DuracionTurnoSegundos;

            lblTemporizador.Text =
                "TIMER: " + segundosRestantes + " s";

            temporizadorTurno.Start();
        }

        private void TemporizadorTurno_Tick(
            object sender,
            EventArgs e)
        {
            if (batallaTerminada)
            {
                temporizadorTurno.Stop();
                return;
            }

            segundosRestantes--;

            lblTemporizador.Text =
                "TIMER: " + segundosRestantes + " s";

            if (segundosRestantes <= 0)
            {
                temporizadorTurno.Stop();

                // En línea solo el jugador en turno decide el fin del tiempo
                // y avisa al rival; el otro espera el mensaje TIEMPO.
                if (esOnline)
                {
                    if (!EsMiTurno)
                        return;

                    EnviarAccionRed("TIEMPO");
                }

                AgregarRegistro(
                    "Se agotó el tiempo. " + NombreEquipo(turnoActual) +
                    " pierde su turno.");

                if (modoPvP)
                {
                    ResolverAccionPvP();
                    return;
                }

                if (JugadorActivo != null) JugadorActivo.CargarEspecial();
                ProcesarTurnoTerremoto();
                if (ResolverJugadorDerrotadoPorEvento())
                    return;
                EjecutarTurnoIA();
            }
        }

        // RENDICIÓN Y REGRESO AL MENÚ
        private void BtnVolver_Click(
            object sender,
            EventArgs e)
        {
            if (batallaTerminada)
            {
                Close();
                return;
            }

            int rindeEquipo = esOnline ? miEquipo : turnoActual;
            int ganaEquipo = (rindeEquipo == 1) ? 2 : 1;

            DialogResult respuesta = MessageBox.Show(
                modoPvP
                    ? "Si vuelves al menú, el Jugador " + rindeEquipo +
                      " se rendirá y el Jugador " + ganaEquipo +
                      " ganará la partida.\r\n\r\n¿Deseas continuar?"
                    : "Si vuelves al menú, te rendirás y la computadora ganará la partida.\r\n\r\n¿Deseas continuar?",
                "Confirmar rendición",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (respuesta != DialogResult.Yes)
                return;

            if (esOnline)
                red.Enviar("RENDIR");

            batallaTerminada = true;
            temporizadorTurno.Stop();

            string ganadorTexto;
            string mensajeFinal;

            if (modoPvP)
            {
                ganadorTexto = "Jugador " + ganaEquipo;
                AgregarRegistro(
                    "El Jugador " + rindeEquipo +
                    " se ha rendido. Gana el Jugador " + ganaEquipo + ".");
                mensajeFinal = "El Jugador " + ganaEquipo + " ha ganado la partida.";
            }
            else
            {
                ganadorTexto = "IA";
                AgregarRegistro(
                    "El jugador se ha rendido. La computadora gana.");
                mensajeFinal = "La computadora ha ganado la partida.";
            }

            if (!gestor.GuardarHistorial(
                ganadorTexto,
                equipoJugador,
                equipoIA))
            {
                MessageBox.Show(
                    "La partida terminó, pero no se pudo guardar el historial: " + gestor.UltimoError,
                    "Chronos Arena",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            MessageBox.Show(
                mensajeFinal,
                "Chronos Arena",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            DialogResult = DialogResult.Cancel;
            Close();
        }

        // Si se cierra la ventana con la X, no se pierde el registro.
        // Las partidas ya finalizadas o guardadas por rendición no se duplican.
        private void FormBatalla_FormClosing(
            object sender,
            FormClosingEventArgs e)
        {
            if (batallaTerminada || gestor == null)
                return;

            // Cerrar la ventana en línea equivale a rendirse.
            if (esOnline)
                red.Enviar("RENDIR");

            batallaTerminada = true;
            if (temporizadorTurno != null)
                temporizadorTurno.Stop();

            gestor.Registrar("La ventana se cerró antes de finalizar. Partida interrumpida.");
            if (!gestor.GuardarHistorial(
                "Interrumpida",
                equipoJugador,
                equipoIA))
            {
                MessageBox.Show(
                    "No se pudo guardar el historial de la partida: " + gestor.UltimoError,
                    "Chronos Arena",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        // FIN DE LA PARTIDA
        private void FinalizarBatalla()
        {
            if (batallaTerminada)
                return;

            batallaTerminada = true;
            temporizadorTurno.Stop();

            string ganador = nucleo.ObtenerGanador(
                equipoJugador,
                equipoIA);

            if (String.IsNullOrEmpty(ganador))
                ganador = "Empate";

            if (!gestor.GuardarHistorial(
                NombreGanadorHistorial(ganador),
                equipoJugador,
                equipoIA))
            {
                MessageBox.Show(
                    "No se pudo guardar el historial de la partida: " + gestor.UltimoError,
                    "Chronos Arena",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            btnAtaque.Enabled = false;
            btnEspecial.Enabled = false;
            btnDefensa.Enabled = false;
            btnRelevar.Enabled = false;

            lblAnuncio.Text =
                "PARTIDA FINALIZADA";

            MessageBox.Show(
                modoPvP
                    ? (ganador == "Jugador"
                        ? "¡Victoria del Jugador 1!"
                        : ganador == "IA"
                            ? "¡Victoria del Jugador 2!"
                            : "La partida terminó en empate.")
                : ganador == "Jugador"
                    ? "¡Victoria! Has derrotado a la computadora."
                    : ganador == "IA"
                        ? "La computadora ha ganado la partida."
                        : "La partida terminó en empate.",
                "Chronos Arena",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
