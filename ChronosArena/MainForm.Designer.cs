namespace ChronosArena
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelFondo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Button btnEmpezar;
        private System.Windows.Forms.Button btnReglas;
        private System.Windows.Forms.Button btnSalir;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelFondo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.btnEmpezar = new System.Windows.Forms.Button();
            this.btnReglas = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();

            this.SuspendLayout();
            this.panelFondo.SuspendLayout();

            this.panelFondo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFondo.BackColor =
                System.Drawing.Color.FromArgb(18, 22, 34);

            this.lblTitulo.Location = new System.Drawing.Point(40, 45);
            this.lblTitulo.Size = new System.Drawing.Size(520, 65);
            this.lblTitulo.Text = "CHRONOS ARENA";
            this.lblTitulo.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.ForeColor = System.Drawing.Color.Gold;
            this.lblTitulo.Font = new System.Drawing.Font(
                "Arial", 28F, System.Drawing.FontStyle.Bold);

            this.lblSubtitulo.Location = new System.Drawing.Point(40, 110);
            this.lblSubtitulo.Size = new System.Drawing.Size(520, 30);
            this.lblSubtitulo.Text = "Duelo táctico de cartas elementales";
            this.lblSubtitulo.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSubtitulo.ForeColor =
                System.Drawing.Color.LightSteelBlue;
            this.lblSubtitulo.Font = new System.Drawing.Font(
                "Arial", 11F, System.Drawing.FontStyle.Italic);

            this.btnEmpezar.Location = new System.Drawing.Point(150, 175);
            this.btnEmpezar.Size = new System.Drawing.Size(300, 48);
            this.btnEmpezar.Text = "EMPEZAR PARTIDA";
            this.btnEmpezar.BackColor =
                System.Drawing.Color.FromArgb(155, 43, 48);
            this.btnEmpezar.ForeColor = System.Drawing.Color.White;
            this.btnEmpezar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnEmpezar.Click +=
                new System.EventHandler(this.BtnEmpezar_Click);

            this.btnReglas.Location = new System.Drawing.Point(150, 245);
            this.btnReglas.Size = new System.Drawing.Size(300, 48);
            this.btnReglas.Text = "REGLAS";
            this.btnReglas.BackColor =
                System.Drawing.Color.FromArgb(45, 83, 126);
            this.btnReglas.ForeColor = System.Drawing.Color.White;
            this.btnReglas.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnReglas.Click +=
                new System.EventHandler(this.BtnReglas_Click);

            this.btnSalir.Location = new System.Drawing.Point(150, 315);
            this.btnSalir.Size = new System.Drawing.Size(300, 48);
            this.btnSalir.Text = "SALIR";
            this.btnSalir.BackColor =
                System.Drawing.Color.FromArgb(55, 60, 72);
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Click +=
                new System.EventHandler(this.BtnSalir_Click);

            this.panelFondo.Controls.Add(this.lblTitulo);
            this.panelFondo.Controls.Add(this.lblSubtitulo);
            this.panelFondo.Controls.Add(this.btnEmpezar);
            this.panelFondo.Controls.Add(this.btnReglas);
            this.panelFondo.Controls.Add(this.btnSalir);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 410);
            this.Controls.Add(this.panelFondo);
            this.Name = "MainForm";
            this.Text = "Chronos Arena";
            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            this.panelFondo.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}