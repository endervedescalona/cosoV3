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

        public FormBatalla(
            List<Personaje> jugador,
            List<Personaje> ia)
        {
            InitializeComponent();

            gestor = new GestorBatalla();
            nucleo = new NucleoBatalla();

            equipoJugador = jugador.Select(
                p => p.Clonar()).ToList();

            equipoIA = ia.Select(
                p => p.Clonar()).ToList();

            indiceJugador = 0;
            indiceIA = 0;

            batallaTerminada = false;
            turnoIAEnProceso = false;

            temporizadorTurno = new Timer();
            temporizadorTurno.Interval = 1000;
            temporizadorTurno.Tick +=
                TemporizadorTurno_Tick;

            CargarFondoArena();

            ActualizarInterfaz();

            AgregarRegistro(
                "La batalla de Chronos Arena ha comenzado.");

            AgregarRegistro(
                "Tienes 30 segundos para realizar tu acción.");

            IniciarTemporizadorTurno();

            FormClosed += delegate
            {
                if (temporizadorTurno != null)
                    temporizadorTurno.Dispose();
            };
        }

        private void CargarFondoArena()
        {
            string url =
                "https://raw.githubusercontent.com/VedzabethCortez/ART_PACK/main/pictures/ARENA.jpeg";

            try
            {
                picFondo.LoadAsync(url);
                picFondo.SendToBack();
            }
            catch
            {
                picFondo.BackColor =
                    Color.FromArgb(18, 23, 35);
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
                "JUGADOR: " + jugador.Nombre +
                "\r\nClase: " + jugador.Clase +
                "\r\nFacción: " + jugador.Faccion +
                "\r\nElemento: " + jugador.Elemento +
                "\r\nAtaque: " + jugador.Ataque +
                "\r\nDefensa: " + jugador.Defensa +
                "\r\nManá: " + jugador.Mana +
                "\r\nEnergía: " + jugador.Energia;

            lblIA.Text =
                "COMPUTADORA: " + ia.Nombre +
                "\r\nClase: " + ia.Clase +
                "\r\nFacción: " + ia.Faccion +
                "\r\nElemento: " + ia.Elemento +
                "\r\nAtaque: " + ia.Ataque +
                "\r\nDefensa: " + ia.Defensa +
                "\r\nManá: " + ia.Mana +
                "\r\nEnergía: " + ia.Energia;

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

            CargarImagen(picJugador, jugador.ImagenUrl);
            CargarImagen(picIA, ia.ImagenUrl);

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

            nucleo.EjecutarDefensa(JugadorActivo);

            AgregarRegistro(
                JugadorActivo.Nombre +
                " adopta una postura defensiva.");

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

            Random azar = new Random();

            // La IA puede usar su habilidad especial.
            if (ia.Mana >= 20 &&
                azar.Next(0, 100) < 35)
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
            // En los demás casos ataca.
            else
            {
                int dano = nucleo.EjecutarAtaque(
                    ia,
                    jugador);

                AgregarRegistro(
                    "La computadora ataca con " +
                    ia.Nombre + " e inflige " +
                    dano + " de daño.");
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

            lblAnuncio.Text = "TU TURNO";

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

            gestor.GuardarHistorial(
                "IA",
                equipoJugador,
                equipoIA);

            MessageBox.Show(
                "La computadora ha ganado la partida.",
                "Chronos Arena",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            DialogResult = DialogResult.Cancel;
            Close();
        }

        // FIN DE LA PARTIDA
        private void FinalizarBatalla()
        {
            if (batallaTerminada)
                return;

            batallaTerminada = true;
            temporizadorTurno.Stop();

            string ganador;

            if (JugadorActivo == null && IAActiva == null)
                ganador = "Empate";
            else if (JugadorActivo == null)
                ganador = "IA";
            else
                ganador = "Jugador";

            gestor.GuardarHistorial(
                ganador,
                equipoJugador,
                equipoIA);

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