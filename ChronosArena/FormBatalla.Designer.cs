using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChronosArena
{
    partial class FormBatalla
    {
        private System.ComponentModel.IContainer components = null;

        private PictureBox picFondo;
        private PictureBox picJugador;
        private PictureBox picIA;

        private Panel pnlJugador;
        private Panel pnlIA;
        private Panel pnlRegistro;
        private Panel pnlAcciones;

        private Label lblTitulo;
        private Label lblAnuncio;
        private Label lblJugador;
        private Label lblIA;
        private Label lblVidaJugador;
        private Label lblVidaIA;
        private Label lblRegistro;
        private Label lblTemporizador;

        private ProgressBar barraVidaJugador;
        private ProgressBar barraVidaIA;

        private TextBox txtRegistro;

        private Button btnAtaque;
        private Button btnEspecial;
        private Button btnDefensa;
        private Button btnRelevar;
        private Button btnVolver;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components =
                new System.ComponentModel.Container();

            this.picFondo = new PictureBox();
            this.picJugador = new PictureBox();
            this.picIA = new PictureBox();

            this.pnlJugador = new Panel();
            this.pnlIA = new Panel();
            this.pnlRegistro = new Panel();
            this.pnlAcciones = new Panel();

            this.lblTitulo = new Label();
            this.lblAnuncio = new Label();
            this.lblJugador = new Label();
            this.lblIA = new Label();
            this.lblVidaJugador = new Label();
            this.lblVidaIA = new Label();
            this.lblRegistro = new Label();
            this.lblTemporizador = new Label();

            this.barraVidaJugador = new ProgressBar();
            this.barraVidaIA = new ProgressBar();

            this.txtRegistro = new TextBox();

            this.btnAtaque = new Button();
            this.btnEspecial = new Button();
            this.btnDefensa = new Button();
            this.btnRelevar = new Button();
            this.btnVolver = new Button();

            ((System.ComponentModel.ISupportInitialize)
                (this.picFondo)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.picJugador)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.picIA)).BeginInit();

            this.SuspendLayout();

            // FORMULARIO
            this.ClientSize = new Size(1100, 680);
            this.MinimumSize = new Size(1116, 719);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(13, 17, 27);
            this.Text = "Chronos Arena - Campo de batalla";

            // FONDO DE ARENA
            this.picFondo.Dock = DockStyle.Fill;
            this.picFondo.Location = new Point(0, 0);
            this.picFondo.Size = new Size(1100, 680);
            this.picFondo.SizeMode = PictureBoxSizeMode.StretchImage;
            this.picFondo.BackColor = Color.FromArgb(18, 23, 35);
            this.picFondo.Name = "picFondo";

            // TITULO
            this.lblTitulo.AutoSize = false;
            this.lblTitulo.Location = new Point(230, 12);
            this.lblTitulo.Size = new Size(640, 42);
            this.lblTitulo.Text = "CHRONOS ARENA";
            this.lblTitulo.Font =
                new Font("Arial", 23F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.Gold;
            this.lblTitulo.TextAlign =
                ContentAlignment.MiddleCenter;
            this.lblTitulo.BackColor =
                Color.FromArgb(190, 13, 17, 27);

            // TEMPORIZADOR
            this.lblTemporizador.Location =
                new Point(440, 58);
            this.lblTemporizador.Size =
                new Size(220, 42);
            this.lblTemporizador.Text = "TIEMPO: 30 s";
            this.lblTemporizador.Font =
                new Font("Arial", 17F, FontStyle.Bold);
            this.lblTemporizador.ForeColor = Color.Gold;
            this.lblTemporizador.BackColor =
                Color.FromArgb(220, 20, 24, 35);
            this.lblTemporizador.TextAlign =
                ContentAlignment.MiddleCenter;

            // ANUNCIO DE TURNO
            this.lblAnuncio.Location =
                new Point(300, 105);
            this.lblAnuncio.Size =
                new Size(500, 30);
            this.lblAnuncio.Text = "TU TURNO";
            this.lblAnuncio.Font =
                new Font("Arial", 12F, FontStyle.Bold);
            this.lblAnuncio.ForeColor = Color.White;
            this.lblAnuncio.BackColor =
                Color.FromArgb(190, 25, 35, 50);
            this.lblAnuncio.TextAlign =
                ContentAlignment.MiddleCenter;

            // PANEL JUGADOR
            this.pnlJugador.Location =
                new Point(25, 150);
            this.pnlJugador.Size =
                new Size(310, 390);
            this.pnlJugador.BackColor =
                Color.FromArgb(220, 19, 31, 47);
            this.pnlJugador.BorderStyle =
                BorderStyle.FixedSingle;

            this.picJugador.Location =
                new Point(55, 15);
            this.picJugador.Size =
                new Size(200, 205);
            this.picJugador.SizeMode =
                PictureBoxSizeMode.Zoom;
            this.picJugador.BackColor =
                Color.FromArgb(25, 30, 42);

            this.lblJugador.Location =
                new Point(10, 225);
            this.lblJugador.Size =
                new Size(288, 105);
            this.lblJugador.Font =
                new Font("Arial", 10F, FontStyle.Bold);
            this.lblJugador.ForeColor = Color.White;
            this.lblJugador.TextAlign =
                ContentAlignment.MiddleLeft;

            this.barraVidaJugador.Location =
                new Point(15, 340);
            this.barraVidaJugador.Size =
                new Size(280, 15);
            this.barraVidaJugador.Style =
                ProgressBarStyle.Continuous;

            this.lblVidaJugador.Location =
                new Point(15, 357);
            this.lblVidaJugador.Size =
                new Size(280, 22);
            this.lblVidaJugador.Font =
                new Font("Arial", 9F, FontStyle.Bold);
            this.lblVidaJugador.ForeColor =
                Color.LightGreen;
            this.lblVidaJugador.TextAlign =
                ContentAlignment.MiddleCenter;

            this.pnlJugador.Controls.Add(this.picJugador);
            this.pnlJugador.Controls.Add(this.lblJugador);
            this.pnlJugador.Controls.Add(this.barraVidaJugador);
            this.pnlJugador.Controls.Add(this.lblVidaJugador);

            // PANEL IA
            this.pnlIA.Location =
                new Point(765, 150);
            this.pnlIA.Size =
                new Size(310, 390);
            this.pnlIA.BackColor =
                Color.FromArgb(220, 38, 23, 29);
            this.pnlIA.BorderStyle =
                BorderStyle.FixedSingle;

            this.picIA.Location =
                new Point(55, 15);
            this.picIA.Size =
                new Size(200, 205);
            this.picIA.SizeMode =
                PictureBoxSizeMode.Zoom;
            this.picIA.BackColor =
                Color.FromArgb(25, 30, 42);

            this.lblIA.Location =
                new Point(10, 225);
            this.lblIA.Size =
                new Size(288, 105);
            this.lblIA.Font =
                new Font("Arial", 10F, FontStyle.Bold);
            this.lblIA.ForeColor = Color.White;
            this.lblIA.TextAlign =
                ContentAlignment.MiddleLeft;

            this.barraVidaIA.Location =
                new Point(15, 340);
            this.barraVidaIA.Size =
                new Size(280, 15);
            this.barraVidaIA.Style =
                ProgressBarStyle.Continuous;

            this.lblVidaIA.Location =
                new Point(15, 357);
            this.lblVidaIA.Size =
                new Size(280, 22);
            this.lblVidaIA.Font =
                new Font("Arial", 9F, FontStyle.Bold);
            this.lblVidaIA.ForeColor =
                Color.LightGreen;
            this.lblVidaIA.TextAlign =
                ContentAlignment.MiddleCenter;

            this.pnlIA.Controls.Add(this.picIA);
            this.pnlIA.Controls.Add(this.lblIA);
            this.pnlIA.Controls.Add(this.barraVidaIA);
            this.pnlIA.Controls.Add(this.lblVidaIA);

            // REGISTRO DE COMBATE
            this.pnlRegistro.Location =
                new Point(355, 150);
            this.pnlRegistro.Size =
                new Size(390, 390);
            this.pnlRegistro.BackColor =
                Color.FromArgb(225, 16, 22, 33);
            this.pnlRegistro.BorderStyle =
                BorderStyle.FixedSingle;

            this.lblRegistro.Location =
                new Point(10, 8);
            this.lblRegistro.Size =
                new Size(370, 30);
            this.lblRegistro.Text =
                "RESUMEN DEL COMBATE";
            this.lblRegistro.Font =
                new Font("Arial", 12F, FontStyle.Bold);
            this.lblRegistro.ForeColor = Color.Gold;
            this.lblRegistro.TextAlign =
                ContentAlignment.MiddleCenter;

            this.txtRegistro.Location =
                new Point(12, 45);
            this.txtRegistro.Size =
                new Size(364, 330);
            this.txtRegistro.Multiline = true;
            this.txtRegistro.ReadOnly = true;
            this.txtRegistro.ScrollBars =
                ScrollBars.Vertical;
            this.txtRegistro.BackColor =
                Color.FromArgb(12, 17, 26);
            this.txtRegistro.ForeColor =
                Color.White;
            this.txtRegistro.Font =
                new Font("Consolas", 9F);
            this.txtRegistro.BorderStyle =
                BorderStyle.FixedSingle;

            this.pnlRegistro.Controls.Add(this.lblRegistro);
            this.pnlRegistro.Controls.Add(this.txtRegistro);

            // PANEL DE ACCIONES
            this.pnlAcciones.Location =
                new Point(25, 555);
            this.pnlAcciones.Size =
                new Size(1050, 95);
            this.pnlAcciones.BackColor =
                Color.FromArgb(225, 16, 22, 33);
            this.pnlAcciones.BorderStyle =
                BorderStyle.FixedSingle;

            ConfigurarBoton(
                this.btnAtaque,
                "ATAQUE",
                25,
                Color.FromArgb(160, 48, 45));

            ConfigurarBoton(
                this.btnEspecial,
                "ESPECIAL",
                280,
                Color.FromArgb(95, 55, 145));

            ConfigurarBoton(
                this.btnDefensa,
                "DEFENSA",
                535,
                Color.FromArgb(42, 100, 125));

            ConfigurarBoton(
                this.btnRelevar,
                "RELEVAR",
                790,
                Color.FromArgb(130, 100, 35));

            this.btnAtaque.Click +=
                new EventHandler(this.BtnAtaque_Click);

            this.btnEspecial.Click +=
                new EventHandler(this.BtnEspecial_Click);

            this.btnDefensa.Click +=
                new EventHandler(this.BtnDefensa_Click);

            this.btnRelevar.Click +=
                new EventHandler(this.BtnRelevar_Click);

            this.pnlAcciones.Controls.Add(this.btnAtaque);
            this.pnlAcciones.Controls.Add(this.btnEspecial);
            this.pnlAcciones.Controls.Add(this.btnDefensa);
            this.pnlAcciones.Controls.Add(this.btnRelevar);

            // BOTON VOLVER
            this.btnVolver.Location =
                new Point(15, 12);
            this.btnVolver.Size =
                new Size(145, 32);
            this.btnVolver.Text = "VOLVER AL MENÚ";
            this.btnVolver.Font =
                new Font("Arial", 9F, FontStyle.Bold);
            this.btnVolver.BackColor =
                Color.FromArgb(70, 35, 42);
            this.btnVolver.ForeColor = Color.White;
            this.btnVolver.FlatStyle = FlatStyle.Flat;
            this.btnVolver.FlatAppearance.BorderColor =
                Color.DarkRed;
            this.btnVolver.Cursor = Cursors.Hand;
            this.btnVolver.Click +=
                new EventHandler(this.BtnVolver_Click);

            // AGREGAR CONTROLES
            this.Controls.Add(this.picFondo);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblTemporizador);
            this.Controls.Add(this.lblAnuncio);
            this.Controls.Add(this.pnlJugador);
            this.Controls.Add(this.pnlIA);
            this.Controls.Add(this.pnlRegistro);
            this.Controls.Add(this.pnlAcciones);
            this.Controls.Add(this.btnVolver);

            this.picFondo.SendToBack();

            this.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)
                (this.picFondo)).EndInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.picJugador)).EndInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.picIA)).EndInit();
        }

        private void ConfigurarBoton(
            Button boton,
            string texto,
            int x,
            Color color)
        {
            boton.Location = new Point(x, 20);
            boton.Size = new Size(220, 52);
            boton.Text = texto;
            boton.Font =
                new Font("Arial", 12F, FontStyle.Bold);
            boton.BackColor = color;
            boton.ForeColor = Color.White;
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 1;
            boton.FlatAppearance.BorderColor = Color.Gold;
            boton.Cursor = Cursors.Hand;
        }
    }
}