
namespace ChronosArena
{
    partial class FormVentanaReglas
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel pnlObjetivo;
        private System.Windows.Forms.Panel pnlEquipos;
        private System.Windows.Forms.Panel pnlClases;
        private System.Windows.Forms.Panel pnlAcciones;
        private System.Windows.Forms.Panel pnlTurnos;
        private System.Windows.Forms.Panel pnlVictoria;
        private System.Windows.Forms.Button btnCerrar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void CrearTarjeta(
            System.Windows.Forms.Panel panel,
            string titulo,
            string contenido,
            int x,
            int y)
        {
            panel.Location = new System.Drawing.Point(x, y);
            panel.Size = new System.Drawing.Size(385, 142);
            panel.BackColor =
                System.Drawing.Color.FromArgb(30, 39, 57);
            panel.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            System.Windows.Forms.Label encabezado =
                new System.Windows.Forms.Label();

            encabezado.Text = titulo;
            encabezado.Location =
                new System.Drawing.Point(16, 12);
            encabezado.Size =
                new System.Drawing.Size(345, 27);
            encabezado.Font =
                new System.Drawing.Font(
                    "Arial", 13F,
                    System.Drawing.FontStyle.Bold);
            encabezado.ForeColor =
                System.Drawing.Color.FromArgb(224, 184, 91);

            System.Windows.Forms.Label texto =
                new System.Windows.Forms.Label();

            texto.Text = contenido;
            texto.Location =
                new System.Drawing.Point(16, 46);
            texto.Size =
                new System.Drawing.Size(345, 85);
            texto.Font =
                new System.Drawing.Font("Arial", 9.5F);
            texto.ForeColor =
                System.Drawing.Color.Gainsboro;

            panel.Controls.Add(encabezado);
            panel.Controls.Add(texto);
        }

        private void InitializeComponent()
        {
            this.components =
                new System.ComponentModel.Container();

            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();

            this.pnlObjetivo = new System.Windows.Forms.Panel();
            this.pnlEquipos = new System.Windows.Forms.Panel();
            this.pnlClases = new System.Windows.Forms.Panel();
            this.pnlAcciones = new System.Windows.Forms.Panel();
            this.pnlTurnos = new System.Windows.Forms.Panel();
            this.pnlVictoria = new System.Windows.Forms.Panel();

            this.btnCerrar = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // TITULO
            this.lblTitulo.AutoSize = false;
            this.lblTitulo.Location =
                new System.Drawing.Point(25, 18);
            this.lblTitulo.Size =
                new System.Drawing.Size(800, 55);
            this.lblTitulo.Text = "CHRONOS ARENA";
            this.lblTitulo.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.Font =
                new System.Drawing.Font(
                    "Arial", 27F,
                    System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor =
                System.Drawing.Color.FromArgb(231, 193, 105);

            // SUBTITULO
            this.lblSubtitulo.Location =
                new System.Drawing.Point(25, 75);
            this.lblSubtitulo.Size =
                new System.Drawing.Size(800, 28);
            this.lblSubtitulo.Text =
                "REGLAMENTO OFICIAL  |  CONOCE LAS REGLAS DEL COMBATE";
            this.lblSubtitulo.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSubtitulo.Font =
                new System.Drawing.Font("Arial", 9F);
            this.lblSubtitulo.ForeColor =
                System.Drawing.Color.LightGray;

            // TARJETAS
            CrearTarjeta(
                this.pnlObjetivo,
                "01  OBJETIVO",
                "Derrota al equipo rival eliminando a sus cinco personajes. "
                + "En este modo te enfrentarás contra la computadora.",
                25, 125);

            CrearTarjeta(
                this.pnlEquipos,
                "02  EQUIPOS",
                "Cada equipo está formado por cinco personajes distintos. "
                + "El jugador selecciona sus cartas y la IA forma su propio equipo.",
                425, 125);

            CrearTarjeta(
                this.pnlClases,
                "03  CLASES Y ELEMENTOS",
                "Tanques: destacan por su resistencia. "
                + "Guerreros: destacan por su ataque. "
                + "Magos: utilizan habilidades especiales. "
                + "Elementos: Fuego, Agua, Aire y Tierra.",
                25, 285);

            CrearTarjeta(
                this.pnlAcciones,
                "04  ACCIONES",
                "ATAQUE: daña al rival. "
                + "ESPECIAL: utiliza maná para activar una habilidad. "
                + "DEFENSA: aumenta la protección. "
                + "RELEVAR: permite cambiar de personaje.",
                425, 285);

            CrearTarjeta(
                this.pnlTurnos,
                "05  TURNOS",
                "Cada turno dispone de 30 segundos. "
                + "Si el tiempo termina, el jugador pierde su turno "
                + "y la computadora realiza su acción.",
                25, 445);

            CrearTarjeta(
                this.pnlVictoria,
                "06  VICTORIA Y RENDICIÓN",
                "Gana quien derrote a los cinco personajes del equipo rival. "
                + "Si el jugador confirma que desea rendirse y volver al menú, "
                + "la victoria será para la IA.",
                425, 445);

            // BOTON CERRAR
            this.btnCerrar.Location =
                new System.Drawing.Point(325, 605);
            this.btnCerrar.Size =
                new System.Drawing.Size(200, 42);
            this.btnCerrar.Text = "VOLVER";
            this.btnCerrar.Font =
                new System.Drawing.Font(
                    "Arial", 10F,
                    System.Drawing.FontStyle.Bold);
            this.btnCerrar.BackColor =
                System.Drawing.Color.FromArgb(170, 126, 48);
            this.btnCerrar.ForeColor =
                System.Drawing.Color.White;
            this.btnCerrar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.Cursor =
                System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Click +=
                new System.EventHandler(this.BtnCerrar_Click);

            // FORMULARIO
            this.BackColor =
                System.Drawing.Color.FromArgb(15, 21, 34);
            this.ClientSize =
                new System.Drawing.Size(850, 675);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblSubtitulo);

            this.Controls.Add(this.pnlObjetivo);
            this.Controls.Add(this.pnlEquipos);
            this.Controls.Add(this.pnlClases);
            this.Controls.Add(this.pnlAcciones);
            this.Controls.Add(this.pnlTurnos);
            this.Controls.Add(this.pnlVictoria);

            this.Controls.Add(this.btnCerrar);

            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chronos Arena - Reglamento";

            this.ResumeLayout(false);
        }
    }
}
