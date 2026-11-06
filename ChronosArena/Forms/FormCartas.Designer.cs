
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChronosArena
{
    public partial class FormCartas
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.PictureBox fondo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.ComboBox cmbClan;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Button btnAtras;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
        	this.fondo = new System.Windows.Forms.PictureBox();
        	this.lblTitulo = new System.Windows.Forms.Label();
        	this.lblFiltro = new System.Windows.Forms.Label();
        	this.cmbClan = new System.Windows.Forms.ComboBox();
        	this.lblDescripcion = new System.Windows.Forms.Label();
        	this.btnAtras = new System.Windows.Forms.Button();
        	((System.ComponentModel.ISupportInitialize)(this.fondo)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// fondo
        	// 
        	this.fondo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(22)))), ((int)(((byte)(40)))));
        	this.fondo.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.fondo.Location = new System.Drawing.Point(0, 0);
        	this.fondo.Name = "fondo";
        	this.fondo.Size = new System.Drawing.Size(920, 510);
		this.fondo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        	this.fondo.TabIndex = 0;
        	this.fondo.TabStop = false;
        	// 
        	// lblTitulo
        	// 
        	this.lblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(10)))), ((int)(((byte)(15)))), ((int)(((byte)(30)))));
        	this.lblTitulo.Font = new System.Drawing.Font("Courier New", 25F, System.Drawing.FontStyle.Bold);
        	this.lblTitulo.ForeColor = System.Drawing.Color.White;
        	this.lblTitulo.Location = new System.Drawing.Point(250, 20);
        	this.lblTitulo.Name = "lblTitulo";
        	this.lblTitulo.Size = new System.Drawing.Size(420, 52);
        	this.lblTitulo.TabIndex = 1;
        	this.lblTitulo.Text = "CLANES DE CHRONOS";
        	this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        	// 
        	// lblFiltro
        	// 
        	this.lblFiltro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(10)))), ((int)(((byte)(15)))), ((int)(((byte)(30)))));
        	this.lblFiltro.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
        	this.lblFiltro.ForeColor = System.Drawing.Color.White;
        	this.lblFiltro.Location = new System.Drawing.Point(220, 95);
        	this.lblFiltro.Name = "lblFiltro";
        	this.lblFiltro.Size = new System.Drawing.Size(205, 32);
        	this.lblFiltro.TabIndex = 2;
        	this.lblFiltro.Text = "FILTRAR POR CLAN:";
        	this.lblFiltro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        	// 
        	// cmbClan
        	// 
        	this.cmbClan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.cmbClan.Font = new System.Drawing.Font("Courier New", 10F);
        	this.cmbClan.FormattingEnabled = true;
        	this.cmbClan.Items.AddRange(new object[] {
        	        	        	"Vista general",
        	        	        	"Mizushiro",
        	        	        	"Kazekiri",
        	        	        	"Homura",
        	        	        	"Daichi"});
        	this.cmbClan.Location = new System.Drawing.Point(435, 97);
        	this.cmbClan.Name = "cmbClan";
        	this.cmbClan.Size = new System.Drawing.Size(265, 24);
        	this.cmbClan.TabIndex = 3;
        	// 
        	// lblDescripcion
        	// 
        	this.lblDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(10)))), ((int)(((byte)(15)))), ((int)(((byte)(30)))));
        	this.lblDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.lblDescripcion.Font = new System.Drawing.Font("Courier New", 10F);
        	this.lblDescripcion.ForeColor = System.Drawing.Color.White;
        	this.lblDescripcion.Location = new System.Drawing.Point(145, 150);
        	this.lblDescripcion.Name = "lblDescripcion";
        	this.lblDescripcion.Padding = new System.Windows.Forms.Padding(22);
        	this.lblDescripcion.Size = new System.Drawing.Size(630, 275);
        	this.lblDescripcion.TabIndex = 4;
        	this.lblDescripcion.Text = "Selecciona un clan para consultar su historia.";
        	this.lblDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        	// 
        	// btnAtras
        	// 
        	this.btnAtras.BackColor = System.Drawing.Color.Gainsboro;
        	this.btnAtras.Cursor = System.Windows.Forms.Cursors.Hand;
        	this.btnAtras.FlatAppearance.BorderSize = 2;
        	this.btnAtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.btnAtras.Font = new System.Drawing.Font("Courier New", 11F, System.Drawing.FontStyle.Bold);
        	this.btnAtras.ForeColor = System.Drawing.Color.Black;
        	this.btnAtras.Location = new System.Drawing.Point(18, 455);
        	this.btnAtras.Name = "btnAtras";
        	this.btnAtras.Size = new System.Drawing.Size(180, 38);
        	this.btnAtras.TabIndex = 5;
        	this.btnAtras.Text = "ATRAS";
        	this.btnAtras.UseVisualStyleBackColor = false;
        	// 
        	// FormCartas
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(22)))), ((int)(((byte)(40)))));
        	this.ClientSize = new System.Drawing.Size(920, 510);
        	this.Controls.Add(this.fondo);
        	this.Controls.Add(this.lblTitulo);
        	this.Controls.Add(this.lblFiltro);
        	this.Controls.Add(this.cmbClan);
        	this.Controls.Add(this.lblDescripcion);
        	this.Controls.Add(this.btnAtras);
        this.Controls.SetChildIndex(this.fondo, this.Controls.Count - 1);
        	this.Font = new System.Drawing.Font("Courier New", 10F);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
        	this.MaximizeBox = true;
        	this.Name = "FormCartas";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        	this.Text = "Chronos Arena - Clanes";
        	((System.ComponentModel.ISupportInitialize)(this.fondo)).EndInit();
        	this.ResumeLayout(false);
        }
    }
}
