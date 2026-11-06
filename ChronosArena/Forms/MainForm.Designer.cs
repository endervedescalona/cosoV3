namespace ChronosArena
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.PictureBox picFondo;
        private System.Windows.Forms.Label lblTitulo;

        private System.Windows.Forms.Button btnEmpezar;
        private System.Windows.Forms.Button btnCartas;
        private System.Windows.Forms.Button btnReglas;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnDesarrolladores;

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
        	this.btnEmpezar = new System.Windows.Forms.Button();
        	this.btnCartas = new System.Windows.Forms.Button();
        	this.btnReglas = new System.Windows.Forms.Button();
        	this.btnRecord = new System.Windows.Forms.Button();
        	this.btnSalir = new System.Windows.Forms.Button();
        	this.btnDesarrolladores = new System.Windows.Forms.Button();
        	((System.ComponentModel.ISupportInitialize)(this.picFondo)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// picFondo
        	// 
        	this.picFondo.BackColor = System.Drawing.Color.FromArgb(20, 25, 38);
        	this.picFondo.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.picFondo.Enabled = false;
        	this.picFondo.Location = new System.Drawing.Point(0, 0);
        	this.picFondo.Name = "picFondo";
        	this.picFondo.Size = new System.Drawing.Size(920, 510);
        	this.picFondo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        	this.picFondo.TabIndex = 0;
        	this.picFondo.TabStop = false;
        	// 
        	// lblTitulo
        	// 
        	this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
        	this.lblTitulo.Font = new System.Drawing.Font("Courier New", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.lblTitulo.ForeColor = System.Drawing.Color.White;
        	this.lblTitulo.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
        	this.lblTitulo.Location = new System.Drawing.Point(35, 20);
        	this.lblTitulo.Name = "lblTitulo";
        	this.lblTitulo.Size = new System.Drawing.Size(520, 75);
        	this.lblTitulo.TabIndex = 1;
        	this.lblTitulo.Text = "CHRONOS  ARENA";
        	this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// btnEmpezar
        	// 
        	this.btnEmpezar.BackColor = System.Drawing.Color.Gainsboro;
        	this.btnEmpezar.Cursor = System.Windows.Forms.Cursors.Hand;
        	this.btnEmpezar.FlatAppearance.BorderSize = 2;
        	this.btnEmpezar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.btnEmpezar.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.btnEmpezar.ForeColor = System.Drawing.Color.Black;
        	this.btnEmpezar.Location = new System.Drawing.Point(42, 164);
        	this.btnEmpezar.Name = "btnEmpezar";
        	this.btnEmpezar.Size = new System.Drawing.Size(188, 36);
        	this.btnEmpezar.TabIndex = 2;
        	this.btnEmpezar.Text = "INICIO";
        	this.btnEmpezar.UseVisualStyleBackColor = false;
        	this.btnEmpezar.Click += new System.EventHandler(this.BtnEmpezar_Click);
        	// 
        	// btnCartas
        	// 
        	this.btnCartas.BackColor = System.Drawing.Color.Gainsboro;
        	this.btnCartas.Cursor = System.Windows.Forms.Cursors.Hand;
        	this.btnCartas.FlatAppearance.BorderSize = 2;
        	this.btnCartas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.btnCartas.Font = this.btnEmpezar.Font;
        	this.btnCartas.ForeColor = System.Drawing.Color.Black;
        	this.btnCartas.Location = new System.Drawing.Point(42, 211);
        	this.btnCartas.Name = "btnCartas";
        	this.btnCartas.Size = new System.Drawing.Size(188, 36);
        	this.btnCartas.TabIndex = 3;
        	this.btnCartas.Text = "CARTAS";
        	this.btnCartas.UseVisualStyleBackColor = false;
        	this.btnCartas.Click += new System.EventHandler(this.BtnCartas_Click);
        	// 
        	// btnReglas
        	// 
        	this.btnReglas.BackColor = System.Drawing.Color.Gainsboro;
        	this.btnReglas.Cursor = System.Windows.Forms.Cursors.Hand;
        	this.btnReglas.FlatAppearance.BorderSize = 2;
        	this.btnReglas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.btnReglas.Font = this.btnEmpezar.Font;
        	this.btnReglas.ForeColor = System.Drawing.Color.Black;
        	this.btnReglas.Location = new System.Drawing.Point(42, 258);
        	this.btnReglas.Name = "btnReglas";
        	this.btnReglas.Size = new System.Drawing.Size(188, 36);
        	this.btnReglas.TabIndex = 4;
        	this.btnReglas.Text = "REGLAS";
        	this.btnReglas.UseVisualStyleBackColor = false;
        	this.btnReglas.Click += new System.EventHandler(this.BtnReglas_Click);
        	// 
        	// btnRecord
        	// 
        	this.btnRecord.BackColor = System.Drawing.Color.Gainsboro;
        	this.btnRecord.Cursor = System.Windows.Forms.Cursors.Hand;
        	this.btnRecord.FlatAppearance.BorderSize = 2;
        	this.btnRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.btnRecord.Font = this.btnEmpezar.Font;
        	this.btnRecord.ForeColor = System.Drawing.Color.Black;
        	this.btnRecord.Location = new System.Drawing.Point(42, 305);
        	this.btnRecord.Name = "btnRecord";
        	this.btnRecord.Size = new System.Drawing.Size(188, 36);
        	this.btnRecord.TabIndex = 5;
        	this.btnRecord.Text = "RECORD";
        	this.btnRecord.UseVisualStyleBackColor = false;
        	this.btnRecord.Click += new System.EventHandler(this.BtnRecord_Click);
        	// 
        	// btnSalir
        	// 
        	this.btnSalir.BackColor = System.Drawing.Color.Gainsboro;
        	this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
        	this.btnSalir.FlatAppearance.BorderSize = 2;
        	this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.btnSalir.Font = this.btnEmpezar.Font;
        	this.btnSalir.ForeColor = System.Drawing.Color.Black;
        	this.btnSalir.Location = new System.Drawing.Point(42, 352);
        	this.btnSalir.Name = "btnSalir";
        	this.btnSalir.Size = new System.Drawing.Size(188, 36);
        	this.btnSalir.TabIndex = 6;
        	this.btnSalir.Text = "SALIR";
        	this.btnSalir.UseVisualStyleBackColor = false;
        	this.btnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
        	// 
        	// btnDesarrolladores
        	// 
        	this.btnDesarrolladores.BackColor = System.Drawing.Color.Gainsboro;
        	this.btnDesarrolladores.Cursor = System.Windows.Forms.Cursors.Hand;
        	this.btnDesarrolladores.FlatAppearance.BorderSize = 2;
        	this.btnDesarrolladores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.btnDesarrolladores.Font = new System.Drawing.Font("Courier New", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.btnDesarrolladores.ForeColor = System.Drawing.Color.Black;
        	this.btnDesarrolladores.Location = new System.Drawing.Point(706, 462);
        	this.btnDesarrolladores.Name = "btnDesarrolladores";
        	this.btnDesarrolladores.Size = new System.Drawing.Size(202, 36);
        	this.btnDesarrolladores.TabIndex = 7;
        	this.btnDesarrolladores.Text = "DESARROLLADORES";
        	this.btnDesarrolladores.UseVisualStyleBackColor = false;
        	this.btnDesarrolladores.Click += new System.EventHandler(this.BtnDesarrolladores_Click);
        	// 
        	// MainForm
        	// 
        	this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(38)))));
        	this.Font = new System.Drawing.Font("Courier New", 9F);
		this.ClientSize = new System.Drawing.Size(920, 510);
		this.Controls.Add(this.picFondo);
		this.Controls.Add(this.lblTitulo);
		this.Controls.Add(this.btnEmpezar);
		this.Controls.Add(this.btnCartas);
		this.Controls.Add(this.btnReglas);
		this.Controls.Add(this.btnRecord);
		this.Controls.Add(this.btnSalir);
		this.Controls.Add(this.btnDesarrolladores);
		this.Controls.SetChildIndex(this.picFondo, this.Controls.Count - 1);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
        	this.MaximizeBox = true;
        	this.Name = "MainForm";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Chronos Arena";
        	((System.ComponentModel.ISupportInitialize)(this.picFondo)).EndInit();
        	this.ResumeLayout(false);
        }
    }
}