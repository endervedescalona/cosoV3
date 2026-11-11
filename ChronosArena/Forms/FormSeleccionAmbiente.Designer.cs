namespace ChronosArena
{
    partial class FormSeleccionAmbiente
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblResumen;

        private System.Windows.Forms.Panel pnlTsunami;
        private System.Windows.Forms.Panel pnlHuracan;
        private System.Windows.Forms.Panel pnlErupcion;
        private System.Windows.Forms.Panel pnlDeslave;

        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnContinuar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblResumen = new System.Windows.Forms.Label();

            this.pnlTsunami = new System.Windows.Forms.Panel();
            this.pnlHuracan = new System.Windows.Forms.Panel();
            this.pnlErupcion = new System.Windows.Forms.Panel();
            this.pnlDeslave = new System.Windows.Forms.Panel();

            this.btnAtras = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnContinuar = new System.Windows.Forms.Button();

            this.SuspendLayout();

            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Text = "CARTAS AMBIENTE";
            this.lblTitulo.Location = new System.Drawing.Point(35, 18);
            this.lblTitulo.Size = new System.Drawing.Size(530, 45);
            this.lblTitulo.Font = new System.Drawing.Font("Georgia", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;

            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Text = "SELECCIONA UNA SOLA CARTA";
            this.lblSubtitulo.Location = new System.Drawing.Point(620, 26);
            this.lblSubtitulo.Size = new System.Drawing.Size(600, 30);
            this.lblSubtitulo.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.lblSubtitulo.BackColor = System.Drawing.Color.Transparent;

            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Text = "ELIGE UNA CARTA AMBIENTE";
            this.lblEstado.Location = new System.Drawing.Point(35, 75);
            this.lblEstado.Size = new System.Drawing.Size(1190, 28);
            this.lblEstado.ForeColor = System.Drawing.Color.Gold;
            this.lblEstado.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
            this.lblEstado.BackColor = System.Drawing.Color.Transparent;

            this.pnlTsunami.Name = "pnlTsunami";
            this.pnlTsunami.Location = new System.Drawing.Point(35, 115);
            this.pnlTsunami.Size = new System.Drawing.Size(280, 420);
            this.pnlTsunami.Padding = new System.Windows.Forms.Padding(3);
            this.pnlTsunami.BackColor = System.Drawing.Color.FromArgb(40, 50, 68);
            this.pnlTsunami.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTsunami.Cursor = System.Windows.Forms.Cursors.Hand;

            this.pnlHuracan.Name = "pnlHuracan";
            this.pnlHuracan.Location = new System.Drawing.Point(335, 115);
            this.pnlHuracan.Size = new System.Drawing.Size(280, 420);
            this.pnlHuracan.Padding = new System.Windows.Forms.Padding(3);
            this.pnlHuracan.BackColor = System.Drawing.Color.FromArgb(40, 50, 68);
            this.pnlHuracan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHuracan.Cursor = System.Windows.Forms.Cursors.Hand;

            this.pnlErupcion.Name = "pnlErupcion";
            this.pnlErupcion.Location = new System.Drawing.Point(635, 115);
            this.pnlErupcion.Size = new System.Drawing.Size(280, 420);
            this.pnlErupcion.Padding = new System.Windows.Forms.Padding(3);
            this.pnlErupcion.BackColor = System.Drawing.Color.FromArgb(40, 50, 68);
            this.pnlErupcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlErupcion.Cursor = System.Windows.Forms.Cursors.Hand;

            this.pnlDeslave.Name = "pnlDeslave";
            this.pnlDeslave.Location = new System.Drawing.Point(935, 115);
            this.pnlDeslave.Size = new System.Drawing.Size(280, 420);
            this.pnlDeslave.Padding = new System.Windows.Forms.Padding(3);
            this.pnlDeslave.BackColor = System.Drawing.Color.FromArgb(40, 50, 68);
            this.pnlDeslave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDeslave.Cursor = System.Windows.Forms.Cursors.Hand;

            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Text = "PASA EL CURSOR SOBRE UNA CARTA PARA LEER SU RESUMEN.";
            this.lblResumen.Location = new System.Drawing.Point(35, 550);
            this.lblResumen.Size = new System.Drawing.Size(1180, 45);
            this.lblResumen.ForeColor = System.Drawing.Color.White;
            this.lblResumen.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold);
            this.lblResumen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblResumen.BackColor = System.Drawing.Color.Transparent;

            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Text = "ATRAS";
            this.btnAtras.Location = new System.Drawing.Point(35, 615);
            this.btnAtras.Size = new System.Drawing.Size(180, 42);
            this.btnAtras.BackColor = System.Drawing.Color.FromArgb(65, 72, 90);
            this.btnAtras.ForeColor = System.Drawing.Color.White;
            this.btnAtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtras.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);

            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Text = "CONFIRMAR CARTA";
            this.btnConfirmar.Location = new System.Drawing.Point(715, 615);
            this.btnConfirmar.Size = new System.Drawing.Size(230, 42);
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(220, 220, 220);
            this.btnConfirmar.ForeColor = System.Drawing.Color.Black;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
            this.btnConfirmar.Enabled = false;

            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Text = "CONTINUAR";
            this.btnContinuar.Location = new System.Drawing.Point(965, 615);
            this.btnContinuar.Size = new System.Drawing.Size(150, 42);
            this.btnContinuar.BackColor = System.Drawing.Color.FromArgb(220, 220, 220);
            this.btnContinuar.ForeColor = System.Drawing.Color.Black;
            this.btnContinuar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinuar.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
            this.btnContinuar.Enabled = false;

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1250, 680);
            this.MinimumSize = new System.Drawing.Size(1150, 650);
            this.Name = "FormSeleccionAmbiente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CHRONOS ARENA - CARTAS AMBIENTE";
            this.BackColor = System.Drawing.Color.FromArgb(15, 31, 50);
            this.ForeColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Courier New", 9.5F);
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;

            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblSubtitulo);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.pnlTsunami);
            this.Controls.Add(this.pnlHuracan);
            this.Controls.Add(this.pnlErupcion);
            this.Controls.Add(this.pnlDeslave);
            this.Controls.Add(this.lblResumen);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnContinuar);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}