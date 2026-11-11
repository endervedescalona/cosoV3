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
        private System.Windows.Forms.Button btnGuardarEquipo;

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
        	this.btnGuardarEquipo = new System.Windows.Forms.Button();
        	this.pnlDados.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// lblTitulo
        	// 
        	this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
        	this.lblTitulo.Font = new System.Drawing.Font("Courier New", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
        	this.lblTitulo.Location = new System.Drawing.Point(30, 18);
        	this.lblTitulo.Name = "lblTitulo";
        	this.lblTitulo.Size = new System.Drawing.Size(650, 48);
        	this.lblTitulo.TabIndex = 0;
        	this.lblTitulo.Text = "ANTES DE INICIAR";
        	// 
        	// lblNombre1
        	// 
        	this.lblNombre1.BackColor = System.Drawing.Color.Transparent;
        	this.lblNombre1.ForeColor = System.Drawing.Color.White;
        	this.lblNombre1.Location = new System.Drawing.Point(40, 94);
        	this.lblNombre1.Name = "lblNombre1";
        	this.lblNombre1.Size = new System.Drawing.Size(380, 23);
        	this.lblNombre1.TabIndex = 1;
        	this.lblNombre1.Text = "NOMBRE DEL JUGADOR 1";
        	// 
        	// txtNombre1
        	// 
        	this.txtNombre1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.txtNombre1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.txtNombre1.Location = new System.Drawing.Point(40, 121);
        	this.txtNombre1.Name = "txtNombre1";
        	this.txtNombre1.Size = new System.Drawing.Size(360, 22);
        	this.txtNombre1.TabIndex = 2;
        	this.txtNombre1.Text = "Jugador 1";
        	// 
        	// lblNombre2
        	// 
        	this.lblNombre2.BackColor = System.Drawing.Color.Transparent;
        	this.lblNombre2.ForeColor = System.Drawing.Color.White;
        	this.lblNombre2.Location = new System.Drawing.Point(40, 180);
        	this.lblNombre2.Name = "lblNombre2";
        	this.lblNombre2.Size = new System.Drawing.Size(380, 23);
        	this.lblNombre2.TabIndex = 3;
        	this.lblNombre2.Text = "NOMBRE DEL JUGADOR 2";
        	// 
        	// txtNombre2
        	// 
        	this.txtNombre2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.txtNombre2.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.txtNombre2.Location = new System.Drawing.Point(40, 207);
        	this.txtNombre2.Name = "txtNombre2";
        	this.txtNombre2.Size = new System.Drawing.Size(360, 22);
        	this.txtNombre2.TabIndex = 4;
        	this.txtNombre2.Text = "Jugador 2";
        	// 
        	// lblRival
        	// 
        	this.lblRival.BackColor = System.Drawing.Color.Transparent;
        	this.lblRival.ForeColor = System.Drawing.Color.LightSkyBlue;
        	this.lblRival.Location = new System.Drawing.Point(40, 180);
        	this.lblRival.Name = "lblRival";
        	this.lblRival.Size = new System.Drawing.Size(390, 28);
        	this.lblRival.TabIndex = 5;
        	this.lblRival.Text = "OPONENTE: COMPUTADORA";
        	// 
        	// pnlDados
        	// 
        	this.pnlDados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(43)))), ((int)(((byte)(65)))));
        	this.pnlDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.pnlDados.Controls.Add(this.lblTituloDados);
        	this.pnlDados.Controls.Add(this.lblDado1);
        	this.pnlDados.Controls.Add(this.lblDado2);
        	this.pnlDados.Location = new System.Drawing.Point(480, 92);
        	this.pnlDados.Name = "pnlDados";
        	this.pnlDados.Size = new System.Drawing.Size(405, 228);
        	this.pnlDados.TabIndex = 6;
        	// 
        	// lblTituloDados
        	// 
        	this.lblTituloDados.BackColor = System.Drawing.Color.Transparent;
        	this.lblTituloDados.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.lblTituloDados.ForeColor = System.Drawing.Color.Lime;
        	this.lblTituloDados.Location = new System.Drawing.Point(15, 12);
        	this.lblTituloDados.Name = "lblTituloDados";
        	this.lblTituloDados.Size = new System.Drawing.Size(380, 30);
        	this.lblTituloDados.TabIndex = 0;
        	this.lblTituloDados.Text = "LANZAMIENTO DE DADOS";
        	this.lblTituloDados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        	// 
        	// lblDado1
        	// 
        	this.lblDado1.BackColor = System.Drawing.Color.White;
        	this.lblDado1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.lblDado1.Font = new System.Drawing.Font("Courier New", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.lblDado1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(35)))));
        	this.lblDado1.Location = new System.Drawing.Point(72, 75);
        	this.lblDado1.Name = "lblDado1";
        	this.lblDado1.Size = new System.Drawing.Size(90, 90);
        	this.lblDado1.TabIndex = 1;
        	this.lblDado1.Text = "-";
        	this.lblDado1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        	// 
        	// lblDado2
        	// 
        	this.lblDado2.BackColor = System.Drawing.Color.White;
        	this.lblDado2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.lblDado2.Font = new System.Drawing.Font("Courier New", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.lblDado2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(35)))));
        	this.lblDado2.Location = new System.Drawing.Point(245, 75);
        	this.lblDado2.Name = "lblDado2";
        	this.lblDado2.Size = new System.Drawing.Size(90, 90);
        	this.lblDado2.TabIndex = 2;
        	this.lblDado2.Text = "-";
        	this.lblDado2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        	// 
        	// btnLanzar
        	// 
        	this.btnLanzar.BackColor = System.Drawing.Color.Purple;
        	this.btnLanzar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.btnLanzar.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
        	this.btnLanzar.ForeColor = System.Drawing.Color.White;
        	this.btnLanzar.Location = new System.Drawing.Point(40, 350);
        	this.btnLanzar.Name = "btnLanzar";
        	this.btnLanzar.Size = new System.Drawing.Size(245, 52);
        	this.btnLanzar.TabIndex = 7;
        	this.btnLanzar.Text = "LANZAR DADOS";
        	this.btnLanzar.UseVisualStyleBackColor = false;
        	// 
        	// lblEstado
        	// 
        	this.lblEstado.BackColor = System.Drawing.Color.Transparent;
        	this.lblEstado.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.lblEstado.ForeColor = System.Drawing.Color.Yellow;
        	this.lblEstado.Location = new System.Drawing.Point(40, 420);
        	this.lblEstado.Name = "lblEstado";
        	this.lblEstado.Size = new System.Drawing.Size(840, 38);
        	this.lblEstado.TabIndex = 8;
        	this.lblEstado.Text = "El resultado mas alto decide quien comienza y elige la carta ambiente.";
        	// 
        	// btnAtras
        	// 
        	this.btnAtras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(72)))), ((int)(((byte)(90)))));
        	this.btnAtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.btnAtras.ForeColor = System.Drawing.Color.White;
        	this.btnAtras.Location = new System.Drawing.Point(40, 470);
        	this.btnAtras.Name = "btnAtras";
        	this.btnAtras.Size = new System.Drawing.Size(150, 36);
        	this.btnAtras.TabIndex = 9;
        	this.btnAtras.Text = "ATRAS";
        	this.btnAtras.UseVisualStyleBackColor = false;
        	// 
        	// btnContinuar
        	// 
        	this.btnContinuar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(130)))), ((int)(((byte)(90)))));
        	this.btnContinuar.Enabled = false;
        	this.btnContinuar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.btnContinuar.ForeColor = System.Drawing.Color.White;
        	this.btnContinuar.Location = new System.Drawing.Point(675, 466);
        	this.btnContinuar.Name = "btnContinuar";
        	this.btnContinuar.Size = new System.Drawing.Size(205, 40);
        	this.btnContinuar.TabIndex = 10;
        	this.btnContinuar.Text = "CONTINUAR";
        	this.btnContinuar.UseVisualStyleBackColor = false;
        	// 
        	// btnGuardarEquipo
        	// 
        	this.btnGuardarEquipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(95)))), ((int)(((byte)(145)))));
        	this.btnGuardarEquipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.btnGuardarEquipo.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.btnGuardarEquipo.ForeColor = System.Drawing.Color.White;
        	this.btnGuardarEquipo.Location = new System.Drawing.Point(315, 350);
        	this.btnGuardarEquipo.Name = "btnGuardarEquipo";
        	this.btnGuardarEquipo.Size = new System.Drawing.Size(245, 52);
        	this.btnGuardarEquipo.TabIndex = 11;
        	this.btnGuardarEquipo.Text = "GUARDAR EQUIPO";
        	this.btnGuardarEquipo.UseVisualStyleBackColor = false;
        	// 
        	// FormPrePartida
        	// 
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        	this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(31)))), ((int)(((byte)(50)))));
        	this.ClientSize = new System.Drawing.Size(920, 520);
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
        	this.Controls.Add(this.btnGuardarEquipo);
        	this.Font = new System.Drawing.Font("Courier New", 9F);
        	this.ForeColor = System.Drawing.Color.White;
        	this.MinimumSize = new System.Drawing.Size(860, 500);
        	this.Name = "FormPrePartida";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        	this.Text = "CHRONOS ARENA - ANTES DE INICIAR";
        	this.pnlDados.ResumeLayout(false);
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
    }
}