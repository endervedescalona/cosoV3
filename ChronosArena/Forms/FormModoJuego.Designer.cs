
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChronosArena
{
    public partial class FormModoJuego
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.PictureBox picFondo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;

        private System.Windows.Forms.Button btnLocal;
        private System.Windows.Forms.Button btnDosJugadores;
        private System.Windows.Forms.Button btnOnline;
        private System.Windows.Forms.Button btnAtras;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
        	this.picFondo = new System.Windows.Forms.PictureBox();
        	this.lblTitulo = new System.Windows.Forms.Label();
        	this.lblSubtitulo = new System.Windows.Forms.Label();
        	this.btnLocal = new System.Windows.Forms.Button();
        	this.btnDosJugadores = new System.Windows.Forms.Button();
        	this.btnOnline = new System.Windows.Forms.Button();
        	this.btnAtras = new System.Windows.Forms.Button();
        	((System.ComponentModel.ISupportInitialize)(this.picFondo)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// picFondo
        	// 
        	this.picFondo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
        	this.picFondo.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.picFondo.Enabled = false;
        	this.picFondo.Location = new System.Drawing.Point(0, 0);
        	this.picFondo.Name = "picFondo";
        	this.picFondo.Size = new System.Drawing.Size(930, 521);
        	this.picFondo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        	this.picFondo.TabIndex = 0;
        	this.picFondo.TabStop = false;
        	// 
        	// lblTitulo
        	// 
        	this.lblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(10)))), ((int)(((byte)(15)))), ((int)(((byte)(25)))));
        	this.lblTitulo.Font = new System.Drawing.Font("Courier New", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.lblTitulo.ForeColor = System.Drawing.Color.White;
        	this.lblTitulo.Location = new System.Drawing.Point(200, 85);
        	this.lblTitulo.Name = "lblTitulo";
        	this.lblTitulo.Size = new System.Drawing.Size(520, 55);
        	this.lblTitulo.TabIndex = 1;
        	this.lblTitulo.Text = "¡PREPARATE PARA LA BATALLA!";
        	this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        	// 
        	// lblSubtitulo
        	// 
        	this.lblSubtitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(10)))), ((int)(((byte)(15)))), ((int)(((byte)(25)))));
        	this.lblSubtitulo.Font = new System.Drawing.Font("Courier New", 11F);
        	this.lblSubtitulo.ForeColor = System.Drawing.Color.Gainsboro;
        	this.lblSubtitulo.Location = new System.Drawing.Point(220, 150);
        	this.lblSubtitulo.Name = "lblSubtitulo";
        	this.lblSubtitulo.Size = new System.Drawing.Size(480, 30);
        	this.lblSubtitulo.TabIndex = 2;
        	this.lblSubtitulo.Text = "SELECCIONA TU MODO DE JUEGO";
        	this.lblSubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        	// 
        	// btnLocal
        	// 
        	this.btnLocal.BackColor = System.Drawing.Color.White;
        	this.btnLocal.Cursor = System.Windows.Forms.Cursors.Hand;
        	this.btnLocal.FlatAppearance.BorderSize = 2;
        	this.btnLocal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.btnLocal.Font = new System.Drawing.Font("Courier New", 11F, System.Drawing.FontStyle.Bold);
        	this.btnLocal.ForeColor = System.Drawing.Color.Black;
        	this.btnLocal.Location = new System.Drawing.Point(300, 210);
        	this.btnLocal.Name = "btnLocal";
        	this.btnLocal.Size = new System.Drawing.Size(320, 45);
        	this.btnLocal.TabIndex = 3;
        	this.btnLocal.Text = "PLAYER VS COM";
        	this.btnLocal.UseVisualStyleBackColor = false;
        	this.btnLocal.Click += new System.EventHandler(this.BtnLocal_Click);
        	// 
        	// btnDosJugadores
        	// 
        	this.btnDosJugadores.BackColor = System.Drawing.Color.White;
        	this.btnDosJugadores.Cursor = System.Windows.Forms.Cursors.Hand;
        	this.btnDosJugadores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.btnDosJugadores.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
        	this.btnDosJugadores.ForeColor = System.Drawing.Color.Black;
        	this.btnDosJugadores.Location = new System.Drawing.Point(300, 270);
        	this.btnDosJugadores.Name = "btnDosJugadores";
        	this.btnDosJugadores.Size = new System.Drawing.Size(320, 45);
        	this.btnDosJugadores.TabIndex = 4;
        	this.btnDosJugadores.Text = "PLAYER VS PLAYER";
        	this.btnDosJugadores.UseVisualStyleBackColor = false;
        	this.btnDosJugadores.Click += new System.EventHandler(this.BtnDosJugadores_Click);
        	// 
        	// btnOnline
        	// 
        	this.btnOnline.BackColor = System.Drawing.Color.White;
        	this.btnOnline.Cursor = System.Windows.Forms.Cursors.Hand;
        	this.btnOnline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.btnOnline.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
        	this.btnOnline.ForeColor = System.Drawing.Color.Black;
        	this.btnOnline.Location = new System.Drawing.Point(300, 330);
        	this.btnOnline.Name = "btnOnline";
        	this.btnOnline.Size = new System.Drawing.Size(320, 45);
        	this.btnOnline.TabIndex = 5;
        	this.btnOnline.Text = "ONLINE MODE";
        	this.btnOnline.UseVisualStyleBackColor = false;
        	this.btnOnline.Click += new System.EventHandler(this.BtnOnline_Click);
        	// 
        	// btnAtras
        	// 
        	this.btnAtras.BackColor = System.Drawing.Color.White;
        	this.btnAtras.Cursor = System.Windows.Forms.Cursors.Hand;
        	this.btnAtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.btnAtras.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
        	this.btnAtras.ForeColor = System.Drawing.Color.Black;
        	this.btnAtras.Location = new System.Drawing.Point(18, 455);
        	this.btnAtras.Name = "btnAtras";
        	this.btnAtras.Size = new System.Drawing.Size(220, 38);
        	this.btnAtras.TabIndex = 6;
        	this.btnAtras.Text = "VOLVER AL MENU";
        	this.btnAtras.UseVisualStyleBackColor = false;
        	this.btnAtras.Click += new System.EventHandler(this.BtnAtras_Click);
        	// 
        	// FormModoJuego
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
        	this.ClientSize = new System.Drawing.Size(930, 521);
        	this.Controls.Add(this.picFondo);
        	this.Controls.Add(this.lblTitulo);
        	this.Controls.Add(this.lblSubtitulo);
        	this.Controls.Add(this.btnLocal);
        	this.Controls.Add(this.btnDosJugadores);
        	this.Controls.Add(this.btnOnline);
        	this.Controls.Add(this.btnAtras);
        this.Controls.SetChildIndex(this.picFondo, this.Controls.Count - 1);
        	this.Font = new System.Drawing.Font("Courier New", 10F);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
        	this.MaximizeBox = true;
        	this.MinimumSize = new System.Drawing.Size(936, 549);
        	this.Name = "FormModoJuego";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        	this.Text = "Chronos Arena - Modo de juego";
        	((System.ComponentModel.ISupportInitialize)(this.picFondo)).EndInit();
        	this.ResumeLayout(false);
        }
    }
}
