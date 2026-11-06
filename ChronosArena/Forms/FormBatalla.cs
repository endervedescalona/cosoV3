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


        public FormBatalla()
        {
            InitializeComponent();
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

            indiceJugador = 0;
            indiceIA = 0;
            batallaTerminada = false;
            turnoIAEnProceso = false;

            temporizadorTurno = new Timer();
            temporizadorTurno.Interval = 1000;
            temporizadorTurno.Tick += TemporizadorTurno_Tick;

            CargarFondoArena();
            ActualizarInterfaz();

            AgregarRegistro("La batalla de Chronos Arena ha comenzado.");
            AgregarRegistro("Tienes 30 segundos para realizar tu acción.");
            IniciarTemporizadorTurno();

            FormClosing += FormBatalla_FormClosing;
            FormClosed += delegate
            {
                if (temporizadorTurno != null)
                    temporizadorTurno.Dispose();
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
            picFondo.LoadCompleted += delegate(
                object sender,
                System.ComponentModel.AsyncCompletedEventArgs e)
            {
                if (e.Error != null || e.Cancelled)
                {
                    picFondo.Image = null;
                    picFondo.BackColor = Color.FromArgb(18, 23, 35);
                }
            };

            try
            {
                if (!String.IsNullOrWhiteSpace(url))
                    picFondo.LoadAsync(url);
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

        private void ActualizarInterfaz()
        {
            Personaje jugador = JugadorActivo;
            Personaje ia = IAActiva;

            if (jugador == null || ia == null)
            {
                FinalizarBatalla();
                return;
            }

            lblJugador.Text =
                "JUGADOR: " + jugador.Nombre + " (" + jugador.Clase + ")" +
                "\r\nFacción: " + jugador.Faccion + " | Elemento: " + jugador.Elemento +
                "\r\nAtaque: " + jugador.Ataque + " | Defensa: " + jugador.Defensa;

            lblIA.Text =
                "COMPUTADORA: " + ia.Nombre + " (" + ia.Clase + ")" +
                "\r\nFacción: " + ia.Faccion + " | Elemento: " + ia.Elemento +
                "\r\nAtaque: " + ia.Ataque + " | Defensa: " + ia.Defensa;

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

            CargarImagen(picJugador, jugador.ImagenUrl);
            CargarImagen(picIA, ia.ImagenUrl);

            lblAnuncio.Text =
                (turnoIAEnProceso ? "TURNO DE LA IA" : "TU TURNO") +
                "  |  EQUIPOS: " + (equipoJugador.Count - indiceJugador) +
                " vs " + (equipoIA.Count - indiceIA);

            bool habilitado =
                !batallaTerminada && !turnoIAEnProceso;

            btnAtaque.Enabled = habilitado;
            btnEspecial.Enabled = habilitado;
            btnDefensa.Enabled = habilitado;

            btnRelevar.Enabled =
                habilitado &&
                indiceJugador < equipoJugador.Count - 1;
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
                cuadro.LoadAsync(url);
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

            if (!nucleo.PuedeUsarEnergia(JugadorActivo, 10))
            {
                MessageBox.Show(
                    "No tienes suficiente energía para atacar. Usa DEFENSA / RECUPERAR para restaurar energía y maná.",
                    "Chronos Arena",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                IniciarTemporizadorTurno();
                return;
            }

            int dano = nucleo.EjecutarAtaque(
                JugadorActivo,
                IAActiva);

            AgregarRegistro(
                JugadorActivo.Nombre +
                " ataca a " + IAActiva.Nombre +
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

            if (!nucleo.PuedeUsarMana(JugadorActivo, 20))
            {
                MessageBox.Show(
                    "No tienes suficiente maná para usar la habilidad especial.",
                    "Chronos Arena",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                IniciarTemporizadorTurno();
                return;
            }

            string resultado =
                nucleo.EjecutarHabilidad(
                    JugadorActivo,
                    IAActiva);

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

            Personaje defensor = JugadorActivo;
            int energiaAnterior = defensor.Energia;
            int manaAnterior = defensor.Mana;
            int defensaAnterior = defensor.Defensa;

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

            if (indiceJugador >= equipoJugador.Count - 1)
            {
                MessageBox.Show(
                    "No tienes más personajes disponibles para relevar.",
                    "Chronos Arena");
                IniciarTemporizadorTurno();
                return;
            }

            indiceJugador++;

            AgregarRegistro(
                "El jugador releva a su personaje. Entra " +
                JugadorActivo.Nombre + ".");

            ActualizarInterfaz();

            EjecutarTurnoIA();
        }

        private bool PuedeActuar()
        {
            if (batallaTerminada || turnoIAEnProceso)
                return false;

            if (JugadorActivo == null || IAActiva == null)
            {
                FinalizarBatalla();
                return false;
            }

            temporizadorTurno.Stop();

            return true;
        }

        private void ResolverAccionJugador()
        {
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
            ActualizarInterfaz();

            Personaje ia = IAActiva;
            Personaje jugador = JugadorActivo;

            if (ia.Vida <= 0)
            {
                indiceIA++;

                if (IAActiva == null)
                {
                    turnoIAEnProceso = false;
                    FinalizarBatalla();
                    return;
                }

                ia = IAActiva;
            }

            // La IA puede usar su habilidad especial.
            if (ia.Mana >= 20 &&
                random.Next(0, 100) < 35)
            {
                string resultado =
                    nucleo.EjecutarHabilidad(ia, jugador);

                AgregarRegistro(
                    "La computadora usa su especial: " +
                    resultado);
            }
            // La IA puede curarse si está muy debilitada.
            else if (ia.Vida < ia.VidaMax / 3 &&
                     ia.Mana >= 15)
            {
                int vidaAnterior = ia.Vida;

                nucleo.EjecutarCuracion(ia);

                AgregarRegistro(
                    ia.Nombre + " recupera " +
                    (ia.Vida - vidaAnterior) +
                    " puntos de vida.");
            }
            // Si no tiene energía para atacar, se defiende y la recupera.
            else if (nucleo.PuedeUsarEnergia(ia, 10))
            {
                int dano = nucleo.EjecutarAtaque(ia, jugador);
                AgregarRegistro(
                    "La computadora ataca con " + ia.Nombre +
                    " e inflige " + dano + " de daño.");
            }
            else
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
            }

            turnoIAEnProceso = false;

            ResolverDerrotasDespuesDeIA();
        }

        private void ResolverDerrotasDespuesDeIA()
        {
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
                "TIEMPO: " + segundosRestantes + " s";

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
                "TIEMPO: " + segundosRestantes + " s";

            if (segundosRestantes <= 0)
            {
                temporizadorTurno.Stop();

                AgregarRegistro(
                    "Se agotó el tiempo. El jugador pierde su turno.");

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

            DialogResult respuesta = MessageBox.Show(
                "Si vuelves al menú, te rendirás y la computadora ganará la partida.\r\n\r\n¿Deseas continuar?",
                "Confirmar rendición",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (respuesta != DialogResult.Yes)
                return;

            batallaTerminada = true;
            temporizadorTurno.Stop();

            AgregarRegistro(
                "El jugador se ha rendido. La computadora gana.");

            if (!gestor.GuardarHistorial(
                "IA",
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
                "La computadora ha ganado la partida.",
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
                ganador,
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
                ganador == "Jugador"
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
