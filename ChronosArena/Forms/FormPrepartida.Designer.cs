using System.Drawing;
using System.Windows.Forms;

namespace ChronosArena
{
    partial class FormPrePartida
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNombre1;
        private System.Windows.Forms.TextBox txtNombre1;
        private System.Windows.Forms.Label lblNombre2;
        private System.Windows.Forms.TextBox txtNombre2;
        private System.Windows.Forms.Label lblRival;
        private System.Windows.Forms.Panel pnlDados;
        private System.Windows.Forms.Label lblTituloDados;
        private System.Windows.Forms.Label lblDado1;
        private System.Windows.Forms.Label lblDado2;
        private System.Windows.Forms.Button btnLanzar;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Button btnContinuar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNombre1 = new System.Windows.Forms.Label();
            this.txtNombre1 = new System.Windows.Forms.TextBox();
            this.lblNombre2 = new System.Windows.Forms.Label();
            this.txtNombre2 = new System.Windows.Forms.TextBox();
            this.lblRival = new System.Windows.Forms.Label();
            this.pnlDados = new System.Windows.Forms.Panel();
            this.lblTituloDados = new System.Windows.Forms.Label();
            this.lblDado1 = new System.Windows.Forms.Label();
            this.lblDado2 = new System.Windows.Forms.Label();
            this.btnLanzar = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            this.btnAtras = new System.Windows.Forms.Button();
            this.btnContinuar = new System.Windows.Forms.Button();

            this.SuspendLayout();
            this.pnlDados.SuspendLayout();

            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Text = "ANTES DE INICIAR";
            this.lblTitulo.Font = new System.Drawing.Font("Georgia", 23F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(30, 18);
            this.lblTitulo.Size = new System.Drawing.Size(650, 48);
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;

            this.lblNombre1.Name = "lblNombre1";
            this.lblNombre1.Text = "NOMBRE DEL JUGADOR 1";
            this.lblNombre1.Location = new System.Drawing.Point(40, 94);
            this.lblNombre1.Size = new System.Drawing.Size(380, 23);
            this.lblNombre1.ForeColor = System.Drawing.Color.White;
            this.lblNombre1.BackColor = System.Drawing.Color.Transparent;

            this.txtNombre1.Name = "txtNombre1";
            this.txtNombre1.Location = new System.Drawing.Point(40, 121);
            this.txtNombre1.Size = new System.Drawing.Size(360, 30);
            this.txtNombre1.Font = new System.Drawing.Font("Courier New", 12F);
            this.txtNombre1.Text = "Jugador 1";
            this.txtNombre1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblNombre2.Name = "lblNombre2";
            this.lblNombre2.Text = "NOMBRE DEL JUGADOR 2";
            this.lblNombre2.Location = new System.Drawing.Point(40, 180);
            this.lblNombre2.Size = new System.Drawing.Size(380, 23);
            this.lblNombre2.ForeColor = System.Drawing.Color.White;
            this.lblNombre2.BackColor = System.Drawing.Color.Transparent;

            this.txtNombre2.Name = "txtNombre2";
            this.txtNombre2.Location = new System.Drawing.Point(40, 207);
            this.txtNombre2.Size = new System.Drawing.Size(360, 30);
            this.txtNombre2.Font = new System.Drawing.Font("Courier New", 12F);
            this.txtNombre2.Text = "Jugador 2";
            this.txtNombre2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblRival.Name = "lblRival";
            this.lblRival.Text = "OPONENTE: COMPUTADORA";
            this.lblRival.Location = new System.Drawing.Point(40, 180);
            this.lblRival.Size = new System.Drawing.Size(390, 28);
            this.lblRival.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.lblRival.BackColor = System.Drawing.Color.Transparent;

            this.pnlDados.Name = "pnlDados";
            this.pnlDados.Location = new System.Drawing.Point(475, 92);
            this.pnlDados.Size = new System.Drawing.Size(410, 265);
            this.pnlDados.BackColor = System.Drawing.Color.FromArgb(25, 43, 65);
            this.pnlDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblTituloDados.Name = "lblTituloDados";
            this.lblTituloDados.Text = "LANZAMIENTO DE DADOS";
            this.lblTituloDados.Location = new System.Drawing.Point(15, 12);
            this.lblTituloDados.Size = new System.Drawing.Size(380, 30);
            this.lblTituloDados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTituloDados.ForeColor = System.Drawing.Color.Gold;
            this.lblTituloDados.Font = new System.Drawing.Font("Georgia", 14F, System.Drawing.FontStyle.Bold);
            this.lblTituloDados.BackColor = System.Drawing.Color.Transparent;

            this.lblDado1.Name = "lblDado1";
            this.lblDado1.Text = "-";
            this.lblDado1.Location = new System.Drawing.Point(72, 75);
            this.lblDado1.Size = new System.Drawing.Size(90, 90);
            this.lblDado1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDado1.BackColor = System.Drawing.Color.White;
            this.lblDado1.ForeColor = System.Drawing.Color.FromArgb(20, 25, 35);
            this.lblDado1.Font = new System.Drawing.Font("Georgia", 30F, System.Drawing.FontStyle.Bold);
            this.lblDado1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.lblDado2.Name = "lblDado2";
            this.lblDado2.Text = "-";
            this.lblDado2.Location = new System.Drawing.Point(245, 75);
            this.lblDado2.Size = new System.Drawing.Size(90, 90);
            this.lblDado2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDado2.BackColor = System.Drawing.Color.White;
            this.lblDado2.ForeColor = System.Drawing.Color.FromArgb(20, 25, 35);
            this.lblDado2.Font = new System.Drawing.Font("Georgia", 30F, System.Drawing.FontStyle.Bold);
            this.lblDado2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.pnlDados.Controls.Add(this.lblTituloDados);
            this.pnlDados.Controls.Add(this.lblDado1);
            this.pnlDados.Controls.Add(this.lblDado2);

            this.btnLanzar.Name = "btnLanzar";
            this.btnLanzar.Text = "LANZAR DADOS";
            this.btnLanzar.Location = new System.Drawing.Point(40, 350);
            this.btnLanzar.Size = new System.Drawing.Size(245, 52);
            this.btnLanzar.BackColor = System.Drawing.Color.FromArgb(190, 145, 35);
            this.btnLanzar.ForeColor = System.Drawing.Color.Black;
            this.btnLanzar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLanzar.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);

            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Text = "El resultado mas alto decide quien comienza y elige la carta ambiente.";
            this.lblEstado.Location = new System.Drawing.Point(40, 420);
            this.lblEstado.Size = new System.Drawing.Size(840, 38);
            this.lblEstado.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.lblEstado.BackColor = System.Drawing.Color.Transparent;

            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Text = "ATRAS";
            this.btnAtras.Location = new System.Drawing.Point(40, 470);
            this.btnAtras.Size = new System.Drawing.Size(150, 36);
            this.btnAtras.BackColor = System.Drawing.Color.FromArgb(65, 72, 90);
            this.btnAtras.ForeColor = System.Drawing.Color.White;
            this.btnAtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Text = "CONTINUAR";
            this.btnContinuar.Location = new System.Drawing.Point(675, 466);
            this.btnContinuar.Size = new System.Drawing.Size(205, 40);
            this.btnContinuar.BackColor = System.Drawing.Color.FromArgb(32, 130, 90);
            this.btnContinuar.ForeColor = System.Drawing.Color.White;
            this.btnContinuar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinuar.Enabled = false;

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(920, 520);
            this.MinimumSize = new System.Drawing.Size(860, 500);
            this.Name = "FormPrePartida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CHRONOS ARENA - ANTES DE INICIAR";
            this.BackColor = System.Drawing.Color.FromArgb(15, 31, 50);
            this.ForeColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Courier New", 9F);

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