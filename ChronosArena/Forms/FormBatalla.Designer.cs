using System.Drawing;
using System.Windows.Forms;

namespace ChronosArena
{
    partial class FormBatalla
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox picFondo;
        private System.Windows.Forms.PictureBox picJugador;
        private System.Windows.Forms.PictureBox picIA;
        private System.Windows.Forms.Panel pnlJugador;
        private System.Windows.Forms.Panel pnlIA;
        private System.Windows.Forms.Panel pnlRegistro;
        private System.Windows.Forms.Panel pnlAcciones;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblAnuncio;
        private System.Windows.Forms.Label lblJugador;
        private System.Windows.Forms.Label lblIA;
        private System.Windows.Forms.Label lblVidaJugador;
        private System.Windows.Forms.Label lblVidaIA;
        private System.Windows.Forms.Label lblEnergiaJugador;
        private System.Windows.Forms.Label lblEnergiaIA;
        private System.Windows.Forms.Label lblManaJugador;
        private System.Windows.Forms.Label lblManaIA;
        private System.Windows.Forms.Label lblRegistro;
        private System.Windows.Forms.Label lblTemporizador;
        private System.Windows.Forms.ProgressBar barraVidaJugador;
        private System.Windows.Forms.ProgressBar barraVidaIA;
        private System.Windows.Forms.ProgressBar barraEnergiaJugador;
        private System.Windows.Forms.ProgressBar barraEnergiaIA;
        private System.Windows.Forms.ProgressBar barraManaJugador;
        private System.Windows.Forms.ProgressBar barraManaIA;
        private System.Windows.Forms.TextBox txtRegistro;
        private System.Windows.Forms.Button btnAtaque;
        private System.Windows.Forms.Button btnEspecial;
        private System.Windows.Forms.Button btnDefensa;
        private System.Windows.Forms.Button btnRelevar;
        private System.Windows.Forms.Button btnVolver;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
        	this.picFondo = new System.Windows.Forms.PictureBox();
        	this.picJugador = new System.Windows.Forms.PictureBox();
        	this.picIA = new System.Windows.Forms.PictureBox();
        	this.pnlJugador = new System.Windows.Forms.Panel();
        	this.lblJugador = new System.Windows.Forms.Label();
        	this.lblVidaJugador = new System.Windows.Forms.Label();
        	this.barraVidaJugador = new System.Windows.Forms.ProgressBar();
        	this.lblEnergiaJugador = new System.Windows.Forms.Label();
        	this.barraEnergiaJugador = new System.Windows.Forms.ProgressBar();
        	this.lblManaJugador = new System.Windows.Forms.Label();
        	this.barraManaJugador = new System.Windows.Forms.ProgressBar();
        	this.pnlIA = new System.Windows.Forms.Panel();
        	this.lblIA = new System.Windows.Forms.Label();
        	this.lblVidaIA = new System.Windows.Forms.Label();
        	this.barraVidaIA = new System.Windows.Forms.ProgressBar();
        	this.lblEnergiaIA = new System.Windows.Forms.Label();
        	this.barraEnergiaIA = new System.Windows.Forms.ProgressBar();
        	this.lblManaIA = new System.Windows.Forms.Label();
        	this.barraManaIA = new System.Windows.Forms.ProgressBar();
        	this.pnlRegistro = new System.Windows.Forms.Panel();
        	this.lblRegistro = new System.Windows.Forms.Label();
        	this.txtRegistro = new System.Windows.Forms.TextBox();
        	this.pnlAcciones = new System.Windows.Forms.Panel();
        	this.btnAtaque = new System.Windows.Forms.Button();
        	this.btnEspecial = new System.Windows.Forms.Button();
        	this.btnDefensa = new System.Windows.Forms.Button();
        	this.btnRelevar = new System.Windows.Forms.Button();
        	this.lblTitulo = new System.Windows.Forms.Label();
        	this.lblAnuncio = new System.Windows.Forms.Label();
        	this.lblTemporizador = new System.Windows.Forms.Label();
        	this.btnVolver = new System.Windows.Forms.Button();
        	((System.ComponentModel.ISupportInitialize)(this.picFondo)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.picJugador)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.picIA)).BeginInit();
        	this.pnlJugador.SuspendLayout();
        	this.pnlIA.SuspendLayout();
        	this.pnlRegistro.SuspendLayout();
        	this.pnlAcciones.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// picFondo
        	// 
        	this.picFondo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(23)))), ((int)(((byte)(35)))));
        	this.picFondo.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.picFondo.Enabled = false;
        	this.picFondo.Location = new System.Drawing.Point(0, 0);
        	this.picFondo.Name = "picFondo";
        	this.picFondo.Size = new System.Drawing.Size(1110, 691);
        	this.picFondo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        	this.picFondo.TabIndex = 0;
        	this.picFondo.TabStop = false;
        	// 
        	// picJugador
        	// 
        	this.picJugador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(42)))));
        	this.picJugador.Location = new System.Drawing.Point(55, 12);
        	this.picJugador.Name = "picJugador";
        	this.picJugador.Size = new System.Drawing.Size(200, 160);
        	this.picJugador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        	this.picJugador.TabIndex = 0;
        	this.picJugador.TabStop = false;
        	// 
        	// picIA
        	// 
        	this.picIA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(42)))));
        	this.picIA.Location = new System.Drawing.Point(55, 12);
        	this.picIA.Name = "picIA";
        	this.picIA.Size = new System.Drawing.Size(200, 160);
        	this.picIA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        	this.picIA.TabIndex = 0;
        	this.picIA.TabStop = false;
        	// 
        	// pnlJugador
        	// 
        	this.pnlJugador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(19)))), ((int)(((byte)(31)))), ((int)(((byte)(47)))));
        	this.pnlJugador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.pnlJugador.Controls.Add(this.picJugador);
        	this.pnlJugador.Controls.Add(this.lblJugador);
        	this.pnlJugador.Controls.Add(this.lblVidaJugador);
        	this.pnlJugador.Controls.Add(this.barraVidaJugador);
        	this.pnlJugador.Controls.Add(this.lblEnergiaJugador);
        	this.pnlJugador.Controls.Add(this.barraEnergiaJugador);
        	this.pnlJugador.Controls.Add(this.lblManaJugador);
        	this.pnlJugador.Controls.Add(this.barraManaJugador);
        	this.pnlJugador.Location = new System.Drawing.Point(25, 150);
        	this.pnlJugador.Name = "pnlJugador";
        	this.pnlJugador.Size = new System.Drawing.Size(310, 390);
        	this.pnlJugador.TabIndex = 4;
        	// 
        	// lblJugador
        	// 
        	this.lblJugador.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold);
        	this.lblJugador.ForeColor = System.Drawing.Color.White;
        	this.lblJugador.Location = new System.Drawing.Point(10, 177);
        	this.lblJugador.Name = "lblJugador";
        	this.lblJugador.Size = new System.Drawing.Size(288, 78);
        	this.lblJugador.TabIndex = 1;
        	// 
        	// lblVidaJugador
        	// 
        	this.lblVidaJugador.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Bold);
        	this.lblVidaJugador.ForeColor = System.Drawing.Color.LightGreen;
        	this.lblVidaJugador.Location = new System.Drawing.Point(15, 256);
        	this.lblVidaJugador.Name = "lblVidaJugador";
        	this.lblVidaJugador.Size = new System.Drawing.Size(280, 17);
        	this.lblVidaJugador.TabIndex = 2;
        	this.lblVidaJugador.Text = "VIDA";
        	// 
        	// barraVidaJugador
        	// 
        	this.barraVidaJugador.Location = new System.Drawing.Point(15, 274);
        	this.barraVidaJugador.Name = "barraVidaJugador";
        	this.barraVidaJugador.Size = new System.Drawing.Size(280, 12);
        	this.barraVidaJugador.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
        	this.barraVidaJugador.TabIndex = 3;
        	// 
        	// lblEnergiaJugador
        	// 
        	this.lblEnergiaJugador.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Bold);
        	this.lblEnergiaJugador.ForeColor = System.Drawing.Color.LightSkyBlue;
        	this.lblEnergiaJugador.Location = new System.Drawing.Point(15, 291);
        	this.lblEnergiaJugador.Name = "lblEnergiaJugador";
        	this.lblEnergiaJugador.Size = new System.Drawing.Size(280, 17);
        	this.lblEnergiaJugador.TabIndex = 4;
        	this.lblEnergiaJugador.Text = "ENERGÍA";
        	// 
        	// barraEnergiaJugador
        	// 
        	this.barraEnergiaJugador.Location = new System.Drawing.Point(15, 309);
        	this.barraEnergiaJugador.Name = "barraEnergiaJugador";
        	this.barraEnergiaJugador.Size = new System.Drawing.Size(280, 12);
        	this.barraEnergiaJugador.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
        	this.barraEnergiaJugador.TabIndex = 5;
        	// 
        	// lblManaJugador
        	// 
        	this.lblManaJugador.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Bold);
        	this.lblManaJugador.ForeColor = System.Drawing.Color.Plum;
        	this.lblManaJugador.Location = new System.Drawing.Point(15, 326);
        	this.lblManaJugador.Name = "lblManaJugador";
        	this.lblManaJugador.Size = new System.Drawing.Size(280, 17);
        	this.lblManaJugador.TabIndex = 6;
        	this.lblManaJugador.Text = "MANÁ";
        	// 
        	// barraManaJugador
        	// 
        	this.barraManaJugador.Location = new System.Drawing.Point(15, 344);
        	this.barraManaJugador.Name = "barraManaJugador";
        	this.barraManaJugador.Size = new System.Drawing.Size(280, 12);
        	this.barraManaJugador.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
        	this.barraManaJugador.TabIndex = 7;
        	// 
        	// pnlIA
        	// 
        	this.pnlIA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(23)))), ((int)(((byte)(29)))));
        	this.pnlIA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.pnlIA.Controls.Add(this.picIA);
        	this.pnlIA.Controls.Add(this.lblIA);
        	this.pnlIA.Controls.Add(this.lblVidaIA);
        	this.pnlIA.Controls.Add(this.barraVidaIA);
        	this.pnlIA.Controls.Add(this.lblEnergiaIA);
        	this.pnlIA.Controls.Add(this.barraEnergiaIA);
        	this.pnlIA.Controls.Add(this.lblManaIA);
        	this.pnlIA.Controls.Add(this.barraManaIA);
        	this.pnlIA.Location = new System.Drawing.Point(765, 150);
        	this.pnlIA.Name = "pnlIA";
        	this.pnlIA.Size = new System.Drawing.Size(310, 390);
        	this.pnlIA.TabIndex = 5;
        	// 
        	// lblIA
        	// 
        	this.lblIA.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold);
        	this.lblIA.ForeColor = System.Drawing.Color.White;
        	this.lblIA.Location = new System.Drawing.Point(10, 177);
        	this.lblIA.Name = "lblIA";
        	this.lblIA.Size = new System.Drawing.Size(288, 78);
        	this.lblIA.TabIndex = 1;
        	// 
        	// lblVidaIA
        	// 
        	this.lblVidaIA.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Bold);
        	this.lblVidaIA.ForeColor = System.Drawing.Color.LightGreen;
        	this.lblVidaIA.Location = new System.Drawing.Point(15, 256);
        	this.lblVidaIA.Name = "lblVidaIA";
        	this.lblVidaIA.Size = new System.Drawing.Size(280, 17);
        	this.lblVidaIA.TabIndex = 2;
        	this.lblVidaIA.Text = "VIDA IA";
        	// 
        	// barraVidaIA
        	// 
        	this.barraVidaIA.Location = new System.Drawing.Point(15, 274);
        	this.barraVidaIA.Name = "barraVidaIA";
        	this.barraVidaIA.Size = new System.Drawing.Size(280, 12);
        	this.barraVidaIA.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
        	this.barraVidaIA.TabIndex = 3;
        	// 
        	// lblEnergiaIA
        	// 
        	this.lblEnergiaIA.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Bold);
        	this.lblEnergiaIA.ForeColor = System.Drawing.Color.LightSkyBlue;
        	this.lblEnergiaIA.Location = new System.Drawing.Point(15, 291);
        	this.lblEnergiaIA.Name = "lblEnergiaIA";
        	this.lblEnergiaIA.Size = new System.Drawing.Size(280, 17);
        	this.lblEnergiaIA.TabIndex = 4;
        	this.lblEnergiaIA.Text = "ENERGÍA IA";
        	// 
        	// barraEnergiaIA
        	// 
        	this.barraEnergiaIA.Location = new System.Drawing.Point(15, 309);
        	this.barraEnergiaIA.Name = "barraEnergiaIA";
        	this.barraEnergiaIA.Size = new System.Drawing.Size(280, 12);
        	this.barraEnergiaIA.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
        	this.barraEnergiaIA.TabIndex = 5;
        	// 
        	// lblManaIA
        	// 
        	this.lblManaIA.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Bold);
        	this.lblManaIA.ForeColor = System.Drawing.Color.Plum;
        	this.lblManaIA.Location = new System.Drawing.Point(15, 326);
        	this.lblManaIA.Name = "lblManaIA";
        	this.lblManaIA.Size = new System.Drawing.Size(280, 17);
        	this.lblManaIA.TabIndex = 6;
        	this.lblManaIA.Text = "MANÁ IA";
        	// 
        	// barraManaIA
        	// 
        	this.barraManaIA.Location = new System.Drawing.Point(15, 344);
        	this.barraManaIA.Name = "barraManaIA";
        	this.barraManaIA.Size = new System.Drawing.Size(280, 12);
        	this.barraManaIA.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
        	this.barraManaIA.TabIndex = 7;
        	// 
        	// pnlRegistro
        	// 
        	this.pnlRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(16)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
        	this.pnlRegistro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.pnlRegistro.Controls.Add(this.lblRegistro);
        	this.pnlRegistro.Controls.Add(this.txtRegistro);
        	this.pnlRegistro.Location = new System.Drawing.Point(355, 150);
        	this.pnlRegistro.Name = "pnlRegistro";
        	this.pnlRegistro.Size = new System.Drawing.Size(390, 390);
        	this.pnlRegistro.TabIndex = 6;
        	// 
        	// lblRegistro
        	// 
        	this.lblRegistro.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.lblRegistro.ForeColor = System.Drawing.Color.Red;
        	this.lblRegistro.Location = new System.Drawing.Point(10, 8);
        	this.lblRegistro.Name = "lblRegistro";
        	this.lblRegistro.Size = new System.Drawing.Size(370, 30);
        	this.lblRegistro.TabIndex = 0;
        	this.lblRegistro.Text = "RESUMEN DEL COMBATE";
        	// 
        	// txtRegistro
        	// 
        	this.txtRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(17)))), ((int)(((byte)(26)))));
        	this.txtRegistro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.txtRegistro.Font = new System.Drawing.Font("Courier New", 8.5F);
        	this.txtRegistro.ForeColor = System.Drawing.Color.White;
        	this.txtRegistro.Location = new System.Drawing.Point(12, 45);
        	this.txtRegistro.Multiline = true;
        	this.txtRegistro.Name = "txtRegistro";
        	this.txtRegistro.ReadOnly = true;
        	this.txtRegistro.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        	this.txtRegistro.Size = new System.Drawing.Size(364, 330);
        	this.txtRegistro.TabIndex = 1;
        	// 
        	// pnlAcciones
        	// 
        	this.pnlAcciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(16)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
        	this.pnlAcciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.pnlAcciones.Controls.Add(this.btnAtaque);
        	this.pnlAcciones.Controls.Add(this.btnEspecial);
        	this.pnlAcciones.Controls.Add(this.btnDefensa);
        	this.pnlAcciones.Controls.Add(this.btnRelevar);
        	this.pnlAcciones.Location = new System.Drawing.Point(25, 555);
        	this.pnlAcciones.Name = "pnlAcciones";
        	this.pnlAcciones.Size = new System.Drawing.Size(1050, 95);
        	this.pnlAcciones.TabIndex = 7;
        	// 
        	// btnAtaque
        	// 
        	this.btnAtaque.BackColor = System.Drawing.Color.Red;
        	this.btnAtaque.Cursor = System.Windows.Forms.Cursors.Hand;
        	this.btnAtaque.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
        	this.btnAtaque.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.btnAtaque.Font = new System.Drawing.Font("Courier New", 11F, System.Drawing.FontStyle.Bold);
        	this.btnAtaque.ForeColor = System.Drawing.Color.Black;
        	this.btnAtaque.Location = new System.Drawing.Point(25, 20);
        	this.btnAtaque.Name = "btnAtaque";
        	this.btnAtaque.Size = new System.Drawing.Size(220, 52);
        	this.btnAtaque.TabIndex = 1;
        	this.btnAtaque.Text = "ATAQUE";
        	this.btnAtaque.UseVisualStyleBackColor = false;
        	this.btnAtaque.Click += new System.EventHandler(this.BtnAtaque_Click);
        	// 
        	// btnEspecial
        	// 
        	this.btnEspecial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
        	this.btnEspecial.Cursor = System.Windows.Forms.Cursors.Hand;
        	this.btnEspecial.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
        	this.btnEspecial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.btnEspecial.Font = new System.Drawing.Font("Courier New", 11F, System.Drawing.FontStyle.Bold);
        	this.btnEspecial.ForeColor = System.Drawing.Color.Black;
        	this.btnEspecial.Location = new System.Drawing.Point(280, 20);
        	this.btnEspecial.Name = "btnEspecial";
        	this.btnEspecial.Size = new System.Drawing.Size(220, 52);
        	this.btnEspecial.TabIndex = 2;
        	this.btnEspecial.Text = "ESPECIAL";
        	this.btnEspecial.UseVisualStyleBackColor = false;
        	this.btnEspecial.Click += new System.EventHandler(this.BtnEspecial_Click);
        	// 
        	// btnDefensa
        	// 
        	this.btnDefensa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
        	this.btnDefensa.Cursor = System.Windows.Forms.Cursors.Hand;
        	this.btnDefensa.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
        	this.btnDefensa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.btnDefensa.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.btnDefensa.ForeColor = System.Drawing.Color.Black;
        	this.btnDefensa.Location = new System.Drawing.Point(535, 20);
        	this.btnDefensa.Name = "btnDefensa";
        	this.btnDefensa.Size = new System.Drawing.Size(220, 52);
        	this.btnDefensa.TabIndex = 3;
        	this.btnDefensa.Text = "DEFENSA / RECUPERAR";
        	this.btnDefensa.UseVisualStyleBackColor = false;
        	this.btnDefensa.Click += new System.EventHandler(this.BtnDefensa_Click);
        	// 
        	// btnRelevar
        	// 
        	this.btnRelevar.BackColor = System.Drawing.Color.Yellow;
        	this.btnRelevar.Cursor = System.Windows.Forms.Cursors.Hand;
        	this.btnRelevar.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
        	this.btnRelevar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.btnRelevar.Font = new System.Drawing.Font("Courier New", 11F, System.Drawing.FontStyle.Bold);
        	this.btnRelevar.ForeColor = System.Drawing.Color.Black;
        	this.btnRelevar.Location = new System.Drawing.Point(790, 20);
        	this.btnRelevar.Name = "btnRelevar";
        	this.btnRelevar.Size = new System.Drawing.Size(220, 52);
        	this.btnRelevar.TabIndex = 4;
        	this.btnRelevar.Text = "RELEVAR";
        	this.btnRelevar.UseVisualStyleBackColor = false;
        	this.btnRelevar.Click += new System.EventHandler(this.BtnRelevar_Click);
        	// 
        	// lblTitulo
        	// 
        	this.lblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(27)))));
        	this.lblTitulo.Font = new System.Drawing.Font("Courier New", 23F, System.Drawing.FontStyle.Bold);
        	this.lblTitulo.ForeColor = System.Drawing.Color.Red;
        	this.lblTitulo.Location = new System.Drawing.Point(230, 12);
        	this.lblTitulo.Name = "lblTitulo";
        	this.lblTitulo.Size = new System.Drawing.Size(640, 42);
        	this.lblTitulo.TabIndex = 1;
        	this.lblTitulo.Text = "CHRONOS ARENA";
        	// 
        	// lblAnuncio
        	// 
        	this.lblAnuncio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(25)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
        	this.lblAnuncio.Font = new System.Drawing.Font("Courier New", 11F, System.Drawing.FontStyle.Bold);
        	this.lblAnuncio.ForeColor = System.Drawing.Color.White;
        	this.lblAnuncio.Location = new System.Drawing.Point(300, 105);
        	this.lblAnuncio.Name = "lblAnuncio";
        	this.lblAnuncio.Size = new System.Drawing.Size(500, 30);
        	this.lblAnuncio.TabIndex = 3;
        	this.lblAnuncio.Text = "TU TURNO";
        	// 
        	// lblTemporizador
        	// 
        	this.lblTemporizador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(20)))), ((int)(((byte)(24)))), ((int)(((byte)(35)))));
        	this.lblTemporizador.Font = new System.Drawing.Font("Courier New", 17F, System.Drawing.FontStyle.Bold);
        	this.lblTemporizador.ForeColor = System.Drawing.Color.White;
        	this.lblTemporizador.Location = new System.Drawing.Point(440, 58);
        	this.lblTemporizador.Name = "lblTemporizador";
        	this.lblTemporizador.Size = new System.Drawing.Size(220, 42);
        	this.lblTemporizador.TabIndex = 2;
        	this.lblTemporizador.Text = "TIEMPO: 30 s";
        	// 
        	// btnVolver
        	// 
        	this.btnVolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(35)))), ((int)(((byte)(42)))));
        	this.btnVolver.Cursor = System.Windows.Forms.Cursors.Hand;
        	this.btnVolver.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
        	this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.btnVolver.Font = new System.Drawing.Font("Courier New", 8.5F, System.Drawing.FontStyle.Bold);
        	this.btnVolver.ForeColor = System.Drawing.Color.White;
        	this.btnVolver.Location = new System.Drawing.Point(15, 12);
        	this.btnVolver.Name = "btnVolver";
        	this.btnVolver.Size = new System.Drawing.Size(180, 32);
        	this.btnVolver.TabIndex = 5;
        	this.btnVolver.Text = "VOLVER AL MENÚ";
        	this.btnVolver.UseVisualStyleBackColor = false;
        	this.btnVolver.Click += new System.EventHandler(this.BtnVolver_Click);
        	// 
        	// FormBatalla
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(27)))));
        	this.ClientSize = new System.Drawing.Size(1110, 691);
        	this.Controls.Add(this.lblTitulo);
        	this.Controls.Add(this.lblTemporizador);
        	this.Controls.Add(this.lblAnuncio);
        	this.Controls.Add(this.pnlJugador);
        	this.Controls.Add(this.pnlIA);
        	this.Controls.Add(this.pnlRegistro);
        	this.Controls.Add(this.pnlAcciones);
        	this.Controls.Add(this.btnVolver);
        	this.Controls.Add(this.picFondo);
        this.Controls.SetChildIndex(this.picFondo, this.Controls.Count - 1);
        	this.Font = new System.Drawing.Font("Courier New", 9F);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
        	this.MaximizeBox = true;
        	this.MinimumSize = new System.Drawing.Size(1116, 719);
        	this.Name = "FormBatalla";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Chronos Arena - Campo de batalla";
        	((System.ComponentModel.ISupportInitialize)(this.picFondo)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.picJugador)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.picIA)).EndInit();
        	this.pnlJugador.ResumeLayout(false);
        	this.pnlIA.ResumeLayout(false);
        	this.pnlRegistro.ResumeLayout(false);
        	this.pnlRegistro.PerformLayout();
        	this.pnlAcciones.ResumeLayout(false);
        	this.ResumeLayout(false);
        }

    }
}
