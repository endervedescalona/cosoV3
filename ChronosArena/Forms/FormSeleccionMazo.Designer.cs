using System.Drawing;
using System.Windows.Forms;

namespace ChronosArena
{
    partial class FormSeleccionMazo
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.ComboBox cmbFiltro;
        private System.Windows.Forms.FlowLayoutPanel panelCatalogo;
        private System.Windows.Forms.PictureBox picReverso;
        private System.Windows.Forms.Label lblJugador;
        private System.Windows.Forms.Label lblIA;
        private System.Windows.Forms.ListBox lstMazoJugador;
        private System.Windows.Forms.ListBox lstMazoIA;
        private System.Windows.Forms.Button btnElegir;
        private System.Windows.Forms.Button btnRetirar;
        private System.Windows.Forms.Button btnComenzar;
        private System.Windows.Forms.Button btnVolverModo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
        	this.lblTitulo = new System.Windows.Forms.Label();
        	this.lblEstado = new System.Windows.Forms.Label();
        	this.lblFiltro = new System.Windows.Forms.Label();
        	this.cmbFiltro = new System.Windows.Forms.ComboBox();
        	this.panelCatalogo = new System.Windows.Forms.FlowLayoutPanel();
        	this.picReverso = new System.Windows.Forms.PictureBox();
        	this.lblJugador = new System.Windows.Forms.Label();
        	this.lblIA = new System.Windows.Forms.Label();
        	this.lstMazoJugador = new System.Windows.Forms.ListBox();
        	this.lstMazoIA = new System.Windows.Forms.ListBox();
        	this.btnElegir = new System.Windows.Forms.Button();
        	this.btnRetirar = new System.Windows.Forms.Button();
        	this.btnComenzar = new System.Windows.Forms.Button();
        	this.btnVolverModo = new System.Windows.Forms.Button();
        	((System.ComponentModel.ISupportInitialize)(this.picReverso)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// lblTitulo
        	// 
        	this.lblTitulo.Font = new System.Drawing.Font("Courier New", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
        	this.lblTitulo.ForeColor = System.Drawing.Color.White;
        	this.lblTitulo.Location = new System.Drawing.Point(18, 10);
        	this.lblTitulo.Name = "lblTitulo";
        	this.lblTitulo.Size = new System.Drawing.Size(350, 32);
        	this.lblTitulo.TabIndex = 0;
        	this.lblTitulo.Text = "SELECCIÓN DE PERSONAJES";
        	// 
        	// lblEstado
        	// 
        	this.lblEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(55)))), ((int)(((byte)(75)))));
        	this.lblEstado.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold);
        	this.lblEstado.ForeColor = System.Drawing.Color.White;
        	this.lblEstado.Location = new System.Drawing.Point(315, 455);
        	this.lblEstado.Name = "lblEstado";
        	this.lblEstado.Size = new System.Drawing.Size(285, 42);
        	this.lblEstado.TabIndex = 1;
        	this.lblEstado.Text = "Selecciona una carta del catálogo.";
        	// 
        	// lblFiltro
        	// 
        	this.lblFiltro.Font = new System.Drawing.Font("Courier New", 8.5F, System.Drawing.FontStyle.Bold);
        	this.lblFiltro.ForeColor = System.Drawing.Color.White;
        	this.lblFiltro.Location = new System.Drawing.Point(18, 48);
        	this.lblFiltro.Name = "lblFiltro";
        	this.lblFiltro.Size = new System.Drawing.Size(95, 22);
        	this.lblFiltro.TabIndex = 2;
        	this.lblFiltro.Text = "FILTRAR POR";
        	// 
        	// cmbFiltro
        	// 
        	this.cmbFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.cmbFiltro.Font = new System.Drawing.Font("Courier New", 8.5F);
        	this.cmbFiltro.FormattingEnabled = true;
        	this.cmbFiltro.Location = new System.Drawing.Point(115, 46);
        	this.cmbFiltro.Name = "cmbFiltro";
        	this.cmbFiltro.Size = new System.Drawing.Size(188, 22);
        	this.cmbFiltro.TabIndex = 3;
        	this.cmbFiltro.SelectedIndexChanged += new System.EventHandler(this.CmbFiltro_SelectedIndexChanged);
        	// 
        	// panelCatalogo
        	// 
        	this.panelCatalogo.AutoScroll = true;
        	this.panelCatalogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(35)))), ((int)(((byte)(53)))));
        	this.panelCatalogo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
        	this.panelCatalogo.Location = new System.Drawing.Point(315, 78);
        	this.panelCatalogo.Name = "panelCatalogo";
        	this.panelCatalogo.Padding = new System.Windows.Forms.Padding(5);
        	this.panelCatalogo.Size = new System.Drawing.Size(285, 360);
        	this.panelCatalogo.TabIndex = 5;
        	this.panelCatalogo.WrapContents = false;
        	// 
        	// picReverso
        	// 
        	this.picReverso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(20)))), ((int)(((byte)(48)))));
        	this.picReverso.Location = new System.Drawing.Point(18, 78);
        	this.picReverso.Name = "picReverso";
        	this.picReverso.Size = new System.Drawing.Size(285, 415);
        	this.picReverso.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        	this.picReverso.TabIndex = 4;
        	this.picReverso.TabStop = false;
        	// 
        	// lblJugador
        	// 
        	this.lblJugador.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
        	this.lblJugador.ForeColor = System.Drawing.Color.White;
        	this.lblJugador.Location = new System.Drawing.Point(620, 15);
        	this.lblJugador.Name = "lblJugador";
        	this.lblJugador.Size = new System.Drawing.Size(145, 25);
        	this.lblJugador.TabIndex = 6;
        	this.lblJugador.Text = "TU MAZO (0/5)";
        	// 
        	// lblIA
        	// 
        	this.lblIA.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
        	this.lblIA.ForeColor = System.Drawing.Color.White;
        	this.lblIA.Location = new System.Drawing.Point(620, 200);
        	this.lblIA.Name = "lblIA";
        	this.lblIA.Size = new System.Drawing.Size(145, 25);
        	this.lblIA.TabIndex = 8;
        	this.lblIA.Text = "MAZO IA (0/5)";
        	// 
        	// lstMazoJugador
        	// 
        	this.lstMazoJugador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(49)))), ((int)(((byte)(65)))));
        	this.lstMazoJugador.Font = new System.Drawing.Font("Courier New", 8F);
        	this.lstMazoJugador.ForeColor = System.Drawing.Color.White;
        	this.lstMazoJugador.ItemHeight = 14;
        	this.lstMazoJugador.Location = new System.Drawing.Point(620, 45);
        	this.lstMazoJugador.Name = "lstMazoJugador";
        	this.lstMazoJugador.Size = new System.Drawing.Size(135, 144);
        	this.lstMazoJugador.TabIndex = 7;
        	// 
        	// lstMazoIA
        	// 
        	this.lstMazoIA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(49)))), ((int)(((byte)(65)))));
        	this.lstMazoIA.Font = new System.Drawing.Font("Courier New", 8F);
        	this.lstMazoIA.ForeColor = System.Drawing.Color.White;
        	this.lstMazoIA.ItemHeight = 14;
        	this.lstMazoIA.Location = new System.Drawing.Point(620, 230);
        	this.lstMazoIA.Name = "lstMazoIA";
        	this.lstMazoIA.Size = new System.Drawing.Size(135, 116);
        	this.lstMazoIA.TabIndex = 9;
        	this.lstMazoIA.SelectedIndexChanged += new System.EventHandler(this.LstMazoIASelectedIndexChanged);
        	// 
        	// btnElegir
        	// 
        	this.btnElegir.BackColor = System.Drawing.Color.Gainsboro;
        	this.btnElegir.Cursor = System.Windows.Forms.Cursors.Hand;
        	this.btnElegir.Enabled = false;
        	this.btnElegir.FlatAppearance.BorderSize = 2;
        	this.btnElegir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.btnElegir.Font = new System.Drawing.Font("Courier New", 8.5F, System.Drawing.FontStyle.Bold);
        	this.btnElegir.ForeColor = System.Drawing.Color.Black;
        	this.btnElegir.Location = new System.Drawing.Point(770, 365);
        	this.btnElegir.Name = "btnElegir";
        	this.btnElegir.Size = new System.Drawing.Size(135, 40);
        	this.btnElegir.TabIndex = 11;
        	this.btnElegir.Text = "CONFIRMAR CARTA";
        	this.btnElegir.UseVisualStyleBackColor = false;
        	this.btnElegir.Click += new System.EventHandler(this.BtnElegir_Click);
        	// 
        	// btnRetirar
        	// 
        	this.btnRetirar.BackColor = System.Drawing.Color.Gainsboro;
        	this.btnRetirar.Cursor = System.Windows.Forms.Cursors.Hand;
        	this.btnRetirar.Enabled = false;
        	this.btnRetirar.FlatAppearance.BorderSize = 2;
        	this.btnRetirar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.btnRetirar.Font = new System.Drawing.Font("Courier New", 8.5F, System.Drawing.FontStyle.Bold);
        	this.btnRetirar.ForeColor = System.Drawing.Color.Black;
        	this.btnRetirar.Location = new System.Drawing.Point(770, 412);
        	this.btnRetirar.Name = "btnRetirar";
        	this.btnRetirar.Size = new System.Drawing.Size(135, 40);
        	this.btnRetirar.TabIndex = 12;
        	this.btnRetirar.Text = "RETIRAR CARTA";
        	this.btnRetirar.UseVisualStyleBackColor = false;
        	this.btnRetirar.Click += new System.EventHandler(this.BtnRetirar_Click);
        	// 
        	// btnComenzar
        	// 
        	this.btnComenzar.BackColor = System.Drawing.Color.Gainsboro;
        	this.btnComenzar.Cursor = System.Windows.Forms.Cursors.Hand;
        	this.btnComenzar.Enabled = false;
        	this.btnComenzar.FlatAppearance.BorderSize = 2;
        	this.btnComenzar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.btnComenzar.Font = new System.Drawing.Font("Courier New", 8.5F, System.Drawing.FontStyle.Bold);
        	this.btnComenzar.ForeColor = System.Drawing.Color.Black;
        	this.btnComenzar.Location = new System.Drawing.Point(770, 459);
        	this.btnComenzar.Name = "btnComenzar";
        	this.btnComenzar.Size = new System.Drawing.Size(135, 38);
        	this.btnComenzar.TabIndex = 13;
        	this.btnComenzar.Text = "EMPEZAR";
        	this.btnComenzar.UseVisualStyleBackColor = false;
        	this.btnComenzar.Click += new System.EventHandler(this.BtnComenzar_Click);
        	// 
        	// btnVolverModo
        	// 
        	this.btnVolverModo.BackColor = System.Drawing.Color.Gainsboro;
        	this.btnVolverModo.Cursor = System.Windows.Forms.Cursors.Hand;
        	this.btnVolverModo.FlatAppearance.BorderSize = 2;
        	this.btnVolverModo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.btnVolverModo.Font = new System.Drawing.Font("Courier New", 8.5F, System.Drawing.FontStyle.Bold);
        	this.btnVolverModo.ForeColor = System.Drawing.Color.Black;
        	this.btnVolverModo.Location = new System.Drawing.Point(620, 370);
        	this.btnVolverModo.Name = "btnVolverModo";
        	this.btnVolverModo.Size = new System.Drawing.Size(135, 38);
        	this.btnVolverModo.TabIndex = 10;
        	this.btnVolverModo.Text = "VOLVER ATRÁS";
        	this.btnVolverModo.UseVisualStyleBackColor = false;
        	this.btnVolverModo.Click += new System.EventHandler(this.BtnVolverModo_Click);
        	// 
        	// FormSeleccionMazo
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(39)))), ((int)(((byte)(59)))));
        	this.ClientSize = new System.Drawing.Size(920, 511);
        	this.Controls.Add(this.lblTitulo);
        	this.Controls.Add(this.lblEstado);
        	this.Controls.Add(this.lblFiltro);
        	this.Controls.Add(this.cmbFiltro);
        	this.Controls.Add(this.picReverso);
        	this.Controls.Add(this.panelCatalogo);
        	this.Controls.Add(this.lblJugador);
        	this.Controls.Add(this.lstMazoJugador);
        	this.Controls.Add(this.lblIA);
        	this.Controls.Add(this.lstMazoIA);
        	this.Controls.Add(this.btnVolverModo);
        	this.Controls.Add(this.btnElegir);
        	this.Controls.Add(this.btnRetirar);
        	this.Controls.Add(this.btnComenzar);
        	this.Font = new System.Drawing.Font("Courier New", 9F);
        	this.MinimumSize = new System.Drawing.Size(936, 549);
        	this.Name = "FormSeleccionMazo";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        	this.Text = "Chronos Arena - Selección de personajes";
        	((System.ComponentModel.ISupportInitialize)(this.picReverso)).EndInit();
        	this.ResumeLayout(false);
        }
    }
}
