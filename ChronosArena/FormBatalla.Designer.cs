
namespace ChronosArena
{
    partial class FormBatalla
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblAnuncio;
        private System.Windows.Forms.Panel pnlJugador;
        private System.Windows.Forms.Panel pnlIA;
        private System.Windows.Forms.Label lblJugador;
        private System.Windows.Forms.Label lblIA;
        private System.Windows.Forms.PictureBox picJugador;
        private System.Windows.Forms.PictureBox picIA;
        private System.Windows.Forms.ProgressBar barraVidaJugador;
        private System.Windows.Forms.ProgressBar barraVidaIA;
        private System.Windows.Forms.Label lblVidaJugador;
        private System.Windows.Forms.Label lblVidaIA;
        private System.Windows.Forms.Label lblRegistro;
        private System.Windows.Forms.TextBox txtRegistro;

        private System.Windows.Forms.Button btnAtaqueRapido;
        private System.Windows.Forms.Button btnAtaquePesado;
        private System.Windows.Forms.Button btnCombo;
        private System.Windows.Forms.Button btnDefender;
        private System.Windows.Forms.Button btnMeditar;
        private System.Windows.Forms.Button btnHabilidad;
        private System.Windows.Forms.Button btnRelevar;
        private System.Windows.Forms.Button btnRendirse;
        private System.Windows.Forms.Button btnVolver;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components =
                new System.ComponentModel.Container();

            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblAnuncio = new System.Windows.Forms.Label();

            this.pnlJugador = new System.Windows.Forms.Panel();
            this.pnlIA = new System.Windows.Forms.Panel();

            this.lblJugador = new System.Windows.Forms.Label();
            this.lblIA = new System.Windows.Forms.Label();

            this.picJugador = new System.Windows.Forms.PictureBox();
            this.picIA = new System.Windows.Forms.PictureBox();

            this.barraVidaJugador = new System.Windows.Forms.ProgressBar();
            this.barraVidaIA = new System.Windows.Forms.ProgressBar();

            this.lblVidaJugador = new System.Windows.Forms.Label();
            this.lblVidaIA = new System.Windows.Forms.Label();

            this.lblRegistro = new System.Windows.Forms.Label();
            this.txtRegistro = new System.Windows.Forms.TextBox();

            this.btnAtaqueRapido = new System.Windows.Forms.Button();
            this.btnAtaquePesado = new System.Windows.Forms.Button();
            this.btnCombo = new System.Windows.Forms.Button();
            this.btnDefender = new System.Windows.Forms.Button();

            this.btnMeditar = new System.Windows.Forms.Button();
            this.btnHabilidad = new System.Windows.Forms.Button();
            this.btnRelevar = new System.Windows.Forms.Button();
            this.btnRendirse = new System.Windows.Forms.Button();

            this.btnVolver = new System.Windows.Forms.Button();

            this.pnlJugador.SuspendLayout();
            this.pnlIA.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)
                (this.picJugador)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.picIA)).BeginInit();

            this.SuspendLayout();

            // FORMULARIO
            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.BackColor =
                System.Drawing.Color.FromArgb(20, 24, 33);

            this.ClientSize =
                new System.Drawing.Size(920, 510);

            this.MinimumSize =
                new System.Drawing.Size(936, 549);

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterParent;

            this.Text =
                "Chronos Arena: Duelo Táctico Elemental";

            // TITULO
            this.lblTitulo.Font =
                new System.Drawing.Font(
                    "Arial", 17F,
                    System.Drawing.FontStyle.Bold);

            this.lblTitulo.ForeColor =
                System.Drawing.Color.Gold;

            this.lblTitulo.Location =
                new System.Drawing.Point(15, 5);

            this.lblTitulo.Size =
                new System.Drawing.Size(890, 32);

            this.lblTitulo.Text =
                "CHRONOS ARENA - DUELO TÁCTICO ELEMENTAL";

            this.lblTitulo.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;

            // ANUNCIO
            this.lblAnuncio.BackColor =
                System.Drawing.Color.FromArgb(37, 45, 61);

            this.lblAnuncio.ForeColor =
                System.Drawing.Color.LightSkyBlue;

            this.lblAnuncio.Font =
                new System.Drawing.Font(
                    "Arial", 10F,
                    System.Drawing.FontStyle.Bold);

            this.lblAnuncio.Location =
                new System.Drawing.Point(220, 42);

            this.lblAnuncio.Size =
                new System.Drawing.Size(480, 58);

            this.lblAnuncio.Text =
                "¡COMIENZA EL COMBATE!";

            this.lblAnuncio.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;

            // PANEL JUGADOR
            this.pnlJugador.BackColor =
                System.Drawing.Color.FromArgb(34, 43, 58);

            this.pnlJugador.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.pnlJugador.Location =
                new System.Drawing.Point(20, 42);

            this.pnlJugador.Size =
                new System.Drawing.Size(190, 190);

            // IMAGEN JUGADOR
            this.picJugador.BackColor =
                System.Drawing.Color.FromArgb(15, 19, 28);

            this.picJugador.Location =
                new System.Drawing.Point(8, 8);

            this.picJugador.Size =
                new System.Drawing.Size(172, 78);

            this.picJugador.SizeMode =
                System.Windows.Forms.PictureBoxSizeMode.Zoom;

            // DATOS JUGADOR
            this.lblJugador.ForeColor =
                System.Drawing.Color.White;

            this.lblJugador.Font =
                new System.Drawing.Font("Arial", 8.5F);

            this.lblJugador.Location =
                new System.Drawing.Point(8, 91);

            this.lblJugador.Size =
                new System.Drawing.Size(172, 70);

            this.lblJugador.Text =
                "JUGADOR";

            // VIDA JUGADOR
            this.barraVidaJugador.Location =
                new System.Drawing.Point(8, 164);

            this.barraVidaJugador.Size =
                new System.Drawing.Size(172, 12);

            this.barraVidaJugador.Minimum = 0;
            this.barraVidaJugador.Maximum = 100;
            this.barraVidaJugador.Value = 100;

            this.lblVidaJugador.ForeColor =
                System.Drawing.Color.LightGreen;

            this.lblVidaJugador.Location =
                new System.Drawing.Point(8, 176);

            this.lblVidaJugador.Size =
                new System.Drawing.Size(172, 13);

            this.lblVidaJugador.Text =
                "100 / 100 HP";

            this.pnlJugador.Controls.Add(this.picJugador);
            this.pnlJugador.Controls.Add(this.lblJugador);
            this.pnlJugador.Controls.Add(this.barraVidaJugador);
            this.pnlJugador.Controls.Add(this.lblVidaJugador);

            // PANEL IA
            this.pnlIA.BackColor =
                System.Drawing.Color.FromArgb(50, 35, 43);

            this.pnlIA.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;

            this.pnlIA.Location =
                new System.Drawing.Point(710, 42);

            this.pnlIA.Size =
                new System.Drawing.Size(190, 190);

            // IMAGEN IA
            this.picIA.BackColor =
                System.Drawing.Color.FromArgb(15, 19, 28);

            this.picIA.Location =
                new System.Drawing.Point(8, 8);

            this.picIA.Size =
                new System.Drawing.Size(172, 78);

            this.picIA.SizeMode =
                System.Windows.Forms.PictureBoxSizeMode.Zoom;

            // DATOS IA
            this.lblIA.ForeColor =
                System.Drawing.Color.White;

            this.lblIA.Font =
                new System.Drawing.Font("Arial", 8.5F);

            this.lblIA.Location =
                new System.Drawing.Point(8, 91);

            this.lblIA.Size =
                new System.Drawing.Size(172, 70);

            this.lblIA.Text =
                "INTELIGENCIA ARTIFICIAL";

            // VIDA IA
            this.barraVidaIA.Location =
                new System.Drawing.Point(8, 164);

            this.barraVidaIA.Size =
                new System.Drawing.Size(172, 12);

            this.barraVidaIA.Minimum = 0;
            this.barraVidaIA.Maximum = 100;
            this.barraVidaIA.Value = 100;

            this.lblVidaIA.ForeColor =
                System.Drawing.Color.LightCoral;

            this.lblVidaIA.Location =
                new System.Drawing.Point(8, 176);

            this.lblVidaIA.Size =
                new System.Drawing.Size(172, 13);

            this.lblVidaIA.Text =
                "100 / 100 HP";

            this.pnlIA.Controls.Add(this.picIA);
            this.pnlIA.Controls.Add(this.lblIA);
            this.pnlIA.Controls.Add(this.barraVidaIA);
            this.pnlIA.Controls.Add(this.lblVidaIA);

            // REGISTRO DE COMBATE
            this.lblRegistro.ForeColor =
                System.Drawing.Color.Gold;

            this.lblRegistro.Font =
                new System.Drawing.Font(
                    "Arial", 9F,
                    System.Drawing.FontStyle.Bold);

            this.lblRegistro.Location =
                new System.Drawing.Point(220, 108);

            this.lblRegistro.Size =
                new System.Drawing.Size(480, 20);

            this.lblRegistro.Text =
                "REGISTRO DE COMBATE";

            this.txtRegistro.BackColor =
                System.Drawing.Color.FromArgb(10, 14, 20);

            this.txtRegistro.ForeColor =
                System.Drawing.Color.LightGreen;

            this.txtRegistro.Font =
                new System.Drawing.Font("Consolas", 9F);

            this.txtRegistro.Location =
                new System.Drawing.Point(220, 130);

            this.txtRegistro.Size =
                new System.Drawing.Size(480, 102);

            this.txtRegistro.Multiline = true;
            this.txtRegistro.ReadOnly = true;
            this.txtRegistro.ScrollBars =
                System.Windows.Forms.ScrollBars.Vertical;

            // ATAQUE RAPIDO
            this.btnAtaqueRapido.Location =
                new System.Drawing.Point(30, 250);

            this.btnAtaqueRapido.Size =
                new System.Drawing.Size(210, 42);

            this.btnAtaqueRapido.Text =
                "Ataque rápido";

            this.btnAtaqueRapido.BackColor =
                System.Drawing.Color.FromArgb(153, 45, 51);

            this.btnAtaqueRapido.ForeColor =
                System.Drawing.Color.White;

            this.btnAtaqueRapido.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnAtaqueRapido.Click +=
                new System.EventHandler(
                    this.EjecutarAtaqueRapido);

            // ATAQUE PESADO
            this.btnAtaquePesado.Location =
                new System.Drawing.Point(250, 250);

            this.btnAtaquePesado.Size =
                new System.Drawing.Size(200, 42);

            this.btnAtaquePesado.Text =
                "Ataque pesado (-15 energía)";

            this.btnAtaquePesado.BackColor =
                System.Drawing.Color.FromArgb(133, 39, 46);

            this.btnAtaquePesado.ForeColor =
                System.Drawing.Color.White;

            this.btnAtaquePesado.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnAtaquePesado.Click +=
                new System.EventHandler(
                    this.EjecutarAtaquePesado);

            // COMBO
            this.btnCombo.Location =
                new System.Drawing.Point(460, 250);

            this.btnCombo.Size =
                new System.Drawing.Size(200, 42);

            this.btnCombo.Text =
                "Combo (30 energía)";

            this.btnCombo.BackColor =
                System.Drawing.Color.FromArgb(150, 112, 34);

            this.btnCombo.ForeColor =
                System.Drawing.Color.White;

            this.btnCombo.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnCombo.Click +=
                new System.EventHandler(
                    this.EjecutarCombo);

            // DEFENSA
            this.btnDefender.Location =
                new System.Drawing.Point(670, 250);

            this.btnDefender.Size =
                new System.Drawing.Size(220, 42);

            this.btnDefender.Text =
                "Escudo de defensa";

            this.btnDefender.BackColor =
                System.Drawing.Color.FromArgb(39, 82, 135);

            this.btnDefender.ForeColor =
                System.Drawing.Color.White;

            this.btnDefender.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnDefender.Click +=
                new System.EventHandler(
                    this.EjecutarDefensa);

            // MEDITAR
            this.btnMeditar.Location =
                new System.Drawing.Point(30, 305);

            this.btnMeditar.Size =
                new System.Drawing.Size(210, 42);

            this.btnMeditar.Text =
                "Meditar (+vida y maná)";

            this.btnMeditar.BackColor =
                System.Drawing.Color.FromArgb(36, 115, 112);

            this.btnMeditar.ForeColor =
                System.Drawing.Color.White;

            this.btnMeditar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnMeditar.Click +=
                new System.EventHandler(
                    this.EjecutarMeditar);

            // HABILIDAD
            this.btnHabilidad.Location =
                new System.Drawing.Point(250, 305);

            this.btnHabilidad.Size =
                new System.Drawing.Size(200, 42);

            this.btnHabilidad.Text =
                "Habilidad especial";

            this.btnHabilidad.BackColor =
                System.Drawing.Color.FromArgb(100, 57, 137);

            this.btnHabilidad.ForeColor =
                System.Drawing.Color.White;

            this.btnHabilidad.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnHabilidad.Click +=
                new System.EventHandler(
                    this.EjecutarHabilidad);

            // RELEVAR
            this.btnRelevar.Location =
                new System.Drawing.Point(460, 305);

            this.btnRelevar.Size =
                new System.Drawing.Size(200, 42);

            this.btnRelevar.Text =
                "Relevar carta";

            this.btnRelevar.BackColor =
                System.Drawing.Color.FromArgb(38, 112, 71);

            this.btnRelevar.ForeColor =
                System.Drawing.Color.White;

            this.btnRelevar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnRelevar.Click +=
                new System.EventHandler(
                    this.EjecutarRelevo);

            // RENDIRSE
            this.btnRendirse.Location =
                new System.Drawing.Point(670, 305);

            this.btnRendirse.Size =
                new System.Drawing.Size(220, 42);

            this.btnRendirse.Text =
                "Rendirse";

            this.btnRendirse.BackColor =
                System.Drawing.Color.FromArgb(156, 86, 40);

            this.btnRendirse.ForeColor =
                System.Drawing.Color.White;

            this.btnRendirse.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnRendirse.Click +=
                new System.EventHandler(
                    this.EjecutarRendicion);

            // VOLVER
            this.btnVolver.Location =
                new System.Drawing.Point(350, 370);

            this.btnVolver.Size =
                new System.Drawing.Size(220, 40);

            this.btnVolver.Text =
                "Volver al menú";

            this.btnVolver.BackColor =
                System.Drawing.Color.FromArgb(54, 62, 77);

            this.btnVolver.ForeColor =
                System.Drawing.Color.White;

            this.btnVolver.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnVolver.Click +=
                new System.EventHandler(
                    this.BtnVolver_Click);

            // AGREGAR CONTROLES AL FORMULARIO
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblAnuncio);
            this.Controls.Add(this.pnlJugador);
            this.Controls.Add(this.pnlIA);
            this.Controls.Add(this.lblRegistro);
            this.Controls.Add(this.txtRegistro);

            this.Controls.Add(this.btnAtaqueRapido);
            this.Controls.Add(this.btnAtaquePesado);
            this.Controls.Add(this.btnCombo);
            this.Controls.Add(this.btnDefender);

            this.Controls.Add(this.btnMeditar);
            this.Controls.Add(this.btnHabilidad);
            this.Controls.Add(this.btnRelevar);
            this.Controls.Add(this.btnRendirse);

            this.Controls.Add(this.btnVolver);

            this.pnlJugador.ResumeLayout(false);
            this.pnlIA.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)
                (this.picJugador)).EndInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.picIA)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
