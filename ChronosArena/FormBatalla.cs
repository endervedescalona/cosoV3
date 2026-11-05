
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

        private GestorBatalla gestor = new GestorBatalla();
        private Random random = new Random();
        private bool batallaTerminada;

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

            equipoJugador = jugador.Select(
                p => p.Clonar()).ToList();

            equipoIA = ia.Select(
                p => p.Clonar()).ToList();

            indiceJugador = 0;
            indiceIA = 0;
            batallaTerminada = false;

            ActualizarInterfaz();
            AgregarRegistro("¡Comienza Chronos Arena!");
            AgregarRegistro(
                "El combate comienza sin dados. Los dados solo se utilizan al seleccionar las cartas.");
        }

        private void AgregarRegistro(string texto)
        {
            if (txtRegistro == null)
                return;

            txtRegistro.AppendText(
                DateTime.Now.ToString("HH:mm:ss") +
                "  " + texto + Environment.NewLine);

            txtRegistro.SelectionStart = txtRegistro.Text.Length;
            txtRegistro.ScrollToCaret();

            gestor.Registrar(texto);
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
                "\r\nElemento: " + jugador.Elemento +
                "\r\nVida: " + jugador.Vida + "/" + jugador.VidaMax +
                "\r\nAtaque: " + jugador.Ataque +
                "   Defensa: " + jugador.Defensa +
                "\r\nManá: " + jugador.Mana +
                "   Energía: " + jugador.Energia;

            lblIA.Text =
                "IA: " + ia.Nombre +
                "\r\nClase: " + ia.Clase +
                "\r\nElemento: " + ia.Elemento +
                "\r\nVida: " + ia.Vida + "/" + ia.VidaMax +
                "\r\nAtaque: " + ia.Ataque +
                "   Defensa: " + ia.Defensa +
                "\r\nManá: " + ia.Mana +
                "   Energía: " + ia.Energia;

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
                jugador.Vida + " / " + jugador.VidaMax + " HP";

            lblVidaIA.Text =
                ia.Vida + " / " + ia.VidaMax + " HP";

            CargarImagen(picJugador, jugador.ImagenUrl);
            CargarImagen(picIA, ia.ImagenUrl);

            bool activo = !batallaTerminada;

            btnAtaqueRapido.Enabled = activo;
            btnAtaquePesado.Enabled = activo;
            btnCombo.Enabled = activo;
            btnDefender.Enabled = activo;
            btnMeditar.Enabled = activo;
            btnHabilidad.Enabled = activo;
            btnRelevar.Enabled = activo &&
                indiceJugador < equipoJugador.Count - 1;
            btnRendirse.Enabled = activo;
        }

        private void CargarImagen(PictureBox cuadro, string url)
        {
            if (cuadro == null)
                return;

            if (String.IsNullOrWhiteSpace(url))
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

        private void EjecutarAtaqueRapido(
            object sender, EventArgs e)
        {
            if (!PuedeCombatir())
                return;

            Personaje jugador = JugadorActivo;
            Personaje ia = IAActiva;

            int ataqueOriginal = jugador.Ataque;
            jugador.Ataque = Math.Max(1, ataqueOriginal - 5);

            int dano = jugador.Atacar(ia);

            jugador.Ataque = ataqueOriginal;

            AgregarRegistro(
                jugador.Nombre + " ejecuta un ataque rápido e inflige " +
                dano + " de daño a " + ia.Nombre + ".");

            ResolverEstadoYTurno();
        }

        private void EjecutarAtaquePesado(
            object sender, EventArgs e)
        {
            if (!PuedeCombatir())
                return;

            Personaje jugador = JugadorActivo;
            Personaje ia = IAActiva;

            if (jugador.Energia < 15)
            {
                AgregarRegistro(
                    jugador.Nombre +
                    " no tiene suficiente energía para el ataque pesado.");

                return;
            }

            int ataqueOriginal = jugador.Ataque;
            jugador.Ataque += 15;
            jugador.Energia -= 15;

            int dano = jugador.Atacar(ia);

            jugador.Ataque = ataqueOriginal;

            AgregarRegistro(
                jugador.Nombre + " ejecuta un ataque pesado e inflige " +
                dano + " de daño.");

            ResolverEstadoYTurno();
        }

        private void EjecutarCombo(
            object sender, EventArgs e)
        {
            if (!PuedeCombatir())
                return;

            Personaje jugador = JugadorActivo;
            Personaje ia = IAActiva;

            if (jugador.Energia < 30)
            {
                AgregarRegistro(
                    "Necesitas 30 puntos de energía para ejecutar el combo.");

                return;
            }

            jugador.Energia -= 30;

            int danoTotal = 0;

            for (int i = 0; i < 3 && ia.Vida > 0; i++)
            {
                int dano = jugador.Atacar(ia);
                danoTotal += dano;
            }

            AgregarRegistro(
                jugador.Nombre + " realiza un combo de tres golpes. Daño total: " +
                danoTotal + ".");

            ResolverEstadoYTurno();
        }

        private void EjecutarDefensa(
            object sender, EventArgs e)
        {
            if (!PuedeCombatir())
                return;

            JugadorActivo.Defender();

            AgregarRegistro(
                JugadorActivo.Nombre +
                " adopta una postura defensiva y aumenta su defensa.");

            TurnoIA();
        }

        private void EjecutarMeditar(
            object sender, EventArgs e)
        {
            if (!PuedeCombatir())
                return;

            Personaje jugador = JugadorActivo;

            int vidaAnterior = jugador.Vida;
            int manaAnterior = jugador.Mana;

            jugador.Vida = Math.Min(
                jugador.VidaMax, jugador.Vida + 15);

            jugador.Mana = Math.Min(
                100, jugador.Mana + 15);

            AgregarRegistro(
                jugador.Nombre + " medita y recupera " +
                (jugador.Vida - vidaAnterior) + " de vida y " +
                (jugador.Mana - manaAnterior) + " de maná.");

            TurnoIA();
        }

        private void EjecutarHabilidad(
            object sender, EventArgs e)
        {
            if (!PuedeCombatir())
                return;

            Personaje jugador = JugadorActivo;
            Personaje ia = IAActiva;

            string mensaje = jugador.UsarHabilidad(ia);

            AgregarRegistro(mensaje);

            ResolverEstadoYTurno();
        }

        private void EjecutarRelevo(
            object sender, EventArgs e)
        {
            if (batallaTerminada)
                return;

            if (indiceJugador >= equipoJugador.Count - 1)
            {
                AgregarRegistro(
                    "No quedan otras cartas para relevar.");

                return;
            }

            indiceJugador++;

            AgregarRegistro(
                "El jugador releva a su personaje. Entra " +
                JugadorActivo.Nombre + ".");

            ActualizarInterfaz();
            TurnoIA();
        }

        private void EjecutarRendicion(
            object sender, EventArgs e)
        {
            if (batallaTerminada)
                return;

            DialogResult respuesta = MessageBox.Show(
                "¿Seguro que deseas rendirte?",
                "Rendirse",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                batallaTerminada = true;

                AgregarRegistro(
                    "El jugador se ha rendido. La IA gana la batalla.");

                gestor.GuardarHistorial("IA");

                DesactivarAcciones();

                MessageBox.Show(
                    "La IA ha ganado la batalla.",
                    "Chronos Arena",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private bool PuedeCombatir()
        {
            if (batallaTerminada)
                return false;

            if (JugadorActivo == null || IAActiva == null)
            {
                FinalizarBatalla();
                return false;
            }

            return true;
        }

        private void ResolverEstadoYTurno()
        {
            if (batallaTerminada)
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
                    "La IA envía a " + IAActiva.Nombre + ".");
            }

            if (JugadorActivo != null && JugadorActivo.Vida <= 0)
            {
                AgregarRegistro(
                    JugadorActivo.Nombre + " ha sido derrotado.");

                indiceJugador++;

                if (JugadorActivo == null)
                {
                    FinalizarBatalla();
                    return;
                }

                AgregarRegistro(
                    "Entra " + JugadorActivo.Nombre + " al combate.");
            }

            ActualizarInterfaz();

            if (!batallaTerminada)
                TurnoIA();
        }

        private void TurnoIA()
        {
            if (batallaTerminada ||
                JugadorActivo == null ||
                IAActiva == null)
            {
                FinalizarBatalla();
                return;
            }

            Personaje ia = IAActiva;
            Personaje jugador = JugadorActivo;

            if (ia.Vida <= 0)
            {
                ResolverEstadoYTurno();
                return;
            }

            if (ia.Vida <= ia.VidaMax / 3 && ia.Mana >= 15)
            {
                int vidaAnterior = ia.Vida;
                ia.Curar();

                if (ia.Vida > vidaAnterior)
                {
                    AgregarRegistro(
                        ia.Nombre + " se cura y recupera " +
                        (ia.Vida - vidaAnterior) + " de vida.");
                }
                else
                {
                    AgregarRegistro(
                        ia.Nombre + " intenta curarse, pero no puede.");
                }
            }
            else if (ia.Mana >= 20 && random.Next(0, 100) < 30)
            {
                AgregarRegistro(ia.UsarHabilidad(jugador));
            }
            else if (random.Next(0, 100) < 20)
            {
                ia.Defender();

                AgregarRegistro(
                    ia.Nombre + " se prepara para defenderse.");
            }
            else
            {
                string mensaje =
                    gestor.AtaqueBasico(ia, jugador);

                AgregarRegistro(mensaje);
            }

            if (jugador.Vida <= 0)
            {
                AgregarRegistro(
                    jugador.Nombre + " ha sido derrotado.");

                indiceJugador++;

                if (JugadorActivo == null)
                {
                    ActualizarInterfaz();
                    FinalizarBatalla();
                    return;
                }

                AgregarRegistro(
                    "El jugador envía a " +
                    JugadorActivo.Nombre + ".");
            }

            if (ia.Vida <= 0)
            {
                AgregarRegistro(
                    ia.Nombre + " ha sido derrotado.");

                indiceIA++;

                if (IAActiva == null)
                {
                    ActualizarInterfaz();
                    FinalizarBatalla();
                    return;
                }

                AgregarRegistro(
                    "La IA envía a " + IAActiva.Nombre + ".");
            }

            ActualizarInterfaz();
        }

        private void FinalizarBatalla()
        {
            if (batallaTerminada)
                return;

            batallaTerminada = true;

            string ganador;

            if (indiceJugador >= equipoJugador.Count)
                ganador = "IA";
            else
                ganador = "Jugador";

            AgregarRegistro(
                "La batalla ha terminado. Ganador: " + ganador + ".");

            gestor.GuardarHistorial(ganador);

            DesactivarAcciones();

            MessageBox.Show(
                "La batalla ha terminado.\r\nGanador: " + ganador,
                "Chronos Arena",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void DesactivarAcciones()
        {
            btnAtaqueRapido.Enabled = false;
            btnAtaquePesado.Enabled = false;
            btnCombo.Enabled = false;
            btnDefender.Enabled = false;
            btnMeditar.Enabled = false;
            btnHabilidad.Enabled = false;
            btnRelevar.Enabled = false;
            btnRendirse.Enabled = false;
        }

        private void BtnVolver_Click(
            object sender, EventArgs e)
        {
            Close();
        }
    }
}
