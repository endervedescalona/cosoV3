using System.Drawing;
using System.Windows.Forms;

namespace ChronosArena
{
    partial class FormPrePartida
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitulo;
        private Label lblNombre1;
        private TextBox txtNombre1;
        private Label lblNombre2;
        private TextBox txtNombre2;
        private Label lblRival;
        private Panel pnlDados;
        private Label lblTituloDados;
        private Label lblDado1;
        private Label lblDado2;
        private Button btnLanzar;
        private Label lblEstado;
        private Button btnAtras;
        private Button btnContinuar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new Label();
            this.lblNombre1 = new Label();
            this.txtNombre1 = new TextBox();
            this.lblNombre2 = new Label();
            this.txtNombre2 = new TextBox();
            this.lblRival = new Label();
            this.pnlDados = new Panel();
            this.lblTituloDados = new Label();
            this.lblDado1 = new Label();
            this.lblDado2 = new Label();
            this.btnLanzar = new Button();
            this.lblEstado = new Label();
            this.btnAtras = new Button();
            this.btnContinuar = new Button();

            this.SuspendLayout();
            this.pnlDados.SuspendLayout();

            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Text = "ANTES DE INICIAR";
            this.lblTitulo.Font = new Font("Georgia", 23F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.White;
            this.lblTitulo.Location = new Point(30, 18);
            this.lblTitulo.Size = new Size(650, 48);
            this.lblTitulo.BackColor = Color.Transparent;

            this.lblNombre1.Name = "lblNombre1";
            this.lblNombre1.Text = "NOMBRE DEL JUGADOR 1";
            this.lblNombre1.Location = new Point(40, 94);
            this.lblNombre1.Size = new Size(380, 23);
            this.lblNombre1.ForeColor = Color.White;
            this.lblNombre1.BackColor = Color.Transparent;

            this.txtNombre1.Name = "txtNombre1";
            this.txtNombre1.Location = new Point(40, 121);
            this.txtNombre1.Size = new Size(360, 30);
            this.txtNombre1.Font = new Font("Courier New", 12F);
            this.txtNombre1.Text = "Jugador 1";
            this.txtNombre1.BorderStyle = BorderStyle.FixedSingle;

            this.lblNombre2.Name = "lblNombre2";
            this.lblNombre2.Text = "NOMBRE DEL JUGADOR 2";
            this.lblNombre2.Location = new Point(40, 180);
            this.lblNombre2.Size = new Size(380, 23);
            this.lblNombre2.ForeColor = Color.White;
            this.lblNombre2.BackColor = Color.Transparent;

            this.txtNombre2.Name = "txtNombre2";
            this.txtNombre2.Location = new Point(40, 207);
            this.txtNombre2.Size = new Size(360, 30);
            this.txtNombre2.Font = new Font("Courier New", 12F);
            this.txtNombre2.Text = "Jugador 2";
            this.txtNombre2.BorderStyle = BorderStyle.FixedSingle;

            this.lblRival.Name = "lblRival";
            this.lblRival.Text = "OPONENTE: COMPUTADORA";
            this.lblRival.Location = new Point(40, 180);
            this.lblRival.Size = new Size(390, 28);
            this.lblRival.ForeColor = Color.LightSkyBlue;
            this.lblRival.BackColor = Color.Transparent;

            this.pnlDados.Name = "pnlDados";
            this.pnlDados.Location = new Point(475, 92);
            this.pnlDados.Size = new Size(410, 265);
            this.pnlDados.BackColor = Color.FromArgb(25, 43, 65);
            this.pnlDados.BorderStyle = BorderStyle.FixedSingle;

            this.lblTituloDados.Name = "lblTituloDados";
            this.lblTituloDados.Text = "LANZAMIENTO DE DADOS";
            this.lblTituloDados.Location = new Point(15, 12);
            this.lblTituloDados.Size = new Size(380, 30);
            this.lblTituloDados.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTituloDados.ForeColor = Color.Gold;
            this.lblTituloDados.Font = new Font("Georgia", 14F, FontStyle.Bold);
            this.lblTituloDados.BackColor = Color.Transparent;

            this.lblDado1.Name = "lblDado1";
            this.lblDado1.Text = "-";
            this.lblDado1.Location = new Point(72, 75);
            this.lblDado1.Size = new Size(90, 90);
            this.lblDado1.TextAlign = ContentAlignment.MiddleCenter;
            this.lblDado1.BackColor = Color.White;
            this.lblDado1.ForeColor = Color.FromArgb(20, 25, 35);
            this.lblDado1.Font = new Font("Georgia", 30F, FontStyle.Bold);
            this.lblDado1.BorderStyle = BorderStyle.FixedSingle;

            this.lblDado2.Name = "lblDado2";
            this.lblDado2.Text = "-";
            this.lblDado2.Location = new Point(245, 75);
            this.lblDado2.Size = new Size(90, 90);
            this.lblDado2.TextAlign = ContentAlignment.MiddleCenter;
            this.lblDado2.BackColor = Color.White;
            this.lblDado2.ForeColor = Color.FromArgb(20, 25, 35);
            this.lblDado2.Font = new Font("Georgia", 30F, FontStyle.Bold);
            this.lblDado2.BorderStyle = BorderStyle.FixedSingle;

            this.pnlDados.Controls.Add(this.lblTituloDados);
            this.pnlDados.Controls.Add(this.lblDado1);
            this.pnlDados.Controls.Add(this.lblDado2);

            this.btnLanzar.Name = "btnLanzar";
            this.btnLanzar.Text = "LANZAR DADOS";
            this.btnLanzar.Location = new Point(40, 350);
            this.btnLanzar.Size = new Size(245, 52);
            this.btnLanzar.BackColor = Color.FromArgb(190, 145, 35);
            this.btnLanzar.ForeColor = Color.Black;
            this.btnLanzar.FlatStyle = FlatStyle.Flat;
            this.btnLanzar.Font = new Font("Courier New", 12F, FontStyle.Bold);

            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Text = "El resultado mas alto decide quien comienza y elige la carta ambiente.";
            this.lblEstado.Location = new Point(40, 420);
            this.lblEstado.Size = new Size(840, 38);
            this.lblEstado.ForeColor = Color.LightSkyBlue;
            this.lblEstado.BackColor = Color.Transparent;

            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Text = "ATRAS";
            this.btnAtras.Location = new Point(40, 470);
            this.btnAtras.Size = new Size(150, 36);
            this.btnAtras.BackColor = Color.FromArgb(65, 72, 90);
            this.btnAtras.ForeColor = Color.White;
            this.btnAtras.FlatStyle = FlatStyle.Flat;

            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Text = "CONTINUAR";
            this.btnContinuar.Location = new Point(675, 466);
            this.btnContinuar.Size = new Size(205, 40);
            this.btnContinuar.BackColor = Color.FromArgb(32, 130, 90);
            this.btnContinuar.ForeColor = Color.White;
            this.btnContinuar.FlatStyle = FlatStyle.Flat;
            this.btnContinuar.Enabled = false;

            this.AutoScaleMode = AutoScaleMode.None;
            this.ClientSize = new Size(920, 520);
            this.MinimumSize = new Size(860, 500);
            this.Name = "FormPrePartida";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "CHRONOS ARENA - ANTES DE INICIAR";
            this.BackColor = Color.FromArgb(15, 31, 50);
            this.ForeColor = Color.White;
            this.Font = new Font("Courier New", 9F);

            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblNombre1);
            this.Controls.Add(this.txtNombre1);
            this.Controls.Add(this.lblNombre2);
            this.Controls.Add(this.txtNombre2);
            this.Controls.Add(this.lblRival);
            this.Controls.Add(this.pnlDados);
            this.Controls.Add(this.btnLanzar);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.btnContinuar);

            this.pnlDados.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}