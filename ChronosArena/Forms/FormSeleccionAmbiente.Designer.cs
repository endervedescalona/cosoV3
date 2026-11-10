using System.Drawing;
using System.Windows.Forms;

namespace ChronosArena
{
    partial class FormSeleccionAmbiente
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitulo;
        private Label lblSubtitulo;
        private Label lblEstado;
        private Label lblResumen;

        private Panel pnlTsunami;
        private Panel pnlHuracan;
        private Panel pnlErupcion;
        private Panel pnlDeslave;

        private Button btnAtras;
        private Button btnConfirmar;
        private Button btnContinuar;

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
            this.lblTitulo = new Label();
            this.lblSubtitulo = new Label();
            this.lblEstado = new Label();
            this.lblResumen = new Label();

            this.pnlTsunami = new Panel();
            this.pnlHuracan = new Panel();
            this.pnlErupcion = new Panel();
            this.pnlDeslave = new Panel();

            this.btnAtras = new Button();
            this.btnConfirmar = new Button();
            this.btnContinuar = new Button();

            this.SuspendLayout();

            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Text = "CARTAS AMBIENTE";
            this.lblTitulo.Location = new Point(35, 18);
            this.lblTitulo.Size = new Size(530, 45);
            this.lblTitulo.Font = new Font("Georgia", 24F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.White;
            this.lblTitulo.BackColor = Color.Transparent;

            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Text = "SELECCIONA UNA SOLA CARTA";
            this.lblSubtitulo.Location = new Point(620, 26);
            this.lblSubtitulo.Size = new Size(600, 30);
            this.lblSubtitulo.Font = new Font("Courier New", 12F, FontStyle.Bold);
            this.lblSubtitulo.ForeColor = Color.LightSkyBlue;
            this.lblSubtitulo.BackColor = Color.Transparent;

            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Text = "ELIGE UNA CARTA AMBIENTE";
            this.lblEstado.Location = new Point(35, 75);
            this.lblEstado.Size = new Size(1190, 28);
            this.lblEstado.ForeColor = Color.Gold;
            this.lblEstado.Font = new Font("Courier New", 10F, FontStyle.Bold);
            this.lblEstado.BackColor = Color.Transparent;

            this.pnlTsunami.Name = "pnlTsunami";
            this.pnlTsunami.Location = new Point(35, 115);
            this.pnlTsunami.Size = new Size(280, 420);
            this.pnlTsunami.Padding = new Padding(3);
            this.pnlTsunami.BackColor = Color.FromArgb(40, 50, 68);
            this.pnlTsunami.BorderStyle = BorderStyle.FixedSingle;
            this.pnlTsunami.Cursor = Cursors.Hand;

            this.pnlHuracan.Name = "pnlHuracan";
            this.pnlHuracan.Location = new Point(335, 115);
            this.pnlHuracan.Size = new Size(280, 420);
            this.pnlHuracan.Padding = new Padding(3);
            this.pnlHuracan.BackColor = Color.FromArgb(40, 50, 68);
            this.pnlHuracan.BorderStyle = BorderStyle.FixedSingle;
            this.pnlHuracan.Cursor = Cursors.Hand;

            this.pnlErupcion.Name = "pnlErupcion";
            this.pnlErupcion.Location = new Point(635, 115);
            this.pnlErupcion.Size = new Size(280, 420);
            this.pnlErupcion.Padding = new Padding(3);
            this.pnlErupcion.BackColor = Color.FromArgb(40, 50, 68);
            this.pnlErupcion.BorderStyle = BorderStyle.FixedSingle;
            this.pnlErupcion.Cursor = Cursors.Hand;

            this.pnlDeslave.Name = "pnlDeslave";
            this.pnlDeslave.Location = new Point(935, 115);
            this.pnlDeslave.Size = new Size(280, 420);
            this.pnlDeslave.Padding = new Padding(3);
            this.pnlDeslave.BackColor = Color.FromArgb(40, 50, 68);
            this.pnlDeslave.BorderStyle = BorderStyle.FixedSingle;
            this.pnlDeslave.Cursor = Cursors.Hand;

            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Text = "PASA EL CURSOR SOBRE UNA CARTA PARA LEER SU RESUMEN.";
            this.lblResumen.Location = new Point(35, 550);
            this.lblResumen.Size = new Size(1180, 45);
            this.lblResumen.ForeColor = Color.White;
            this.lblResumen.Font = new Font("Courier New", 9F, FontStyle.Bold);
            this.lblResumen.TextAlign = ContentAlignment.MiddleCenter;
            this.lblResumen.BackColor = Color.Transparent;

            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Text = "ATRAS";
            this.btnAtras.Location = new Point(35, 615);
            this.btnAtras.Size = new Size(180, 42);
            this.btnAtras.BackColor = Color.FromArgb(65, 72, 90);
            this.btnAtras.ForeColor = Color.White;
            this.btnAtras.FlatStyle = FlatStyle.Flat;
            this.btnAtras.Font = new Font("Courier New", 10F, FontStyle.Bold);

            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Text = "CONFIRMAR CARTA";
            this.btnConfirmar.Location = new Point(715, 615);
            this.btnConfirmar.Size = new Size(230, 42);
            this.btnConfirmar.BackColor = Color.FromArgb(220, 220, 220);
            this.btnConfirmar.ForeColor = Color.Black;
            this.btnConfirmar.FlatStyle = FlatStyle.Flat;
            this.btnConfirmar.Font = new Font("Courier New", 10F, FontStyle.Bold);
            this.btnConfirmar.Enabled = false;

            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Text = "CONTINUAR";
            this.btnContinuar.Location = new Point(965, 615);
            this.btnContinuar.Size = new Size(150, 42);
            this.btnContinuar.BackColor = Color.FromArgb(220, 220, 220);
            this.btnContinuar.ForeColor = Color.Black;
            this.btnContinuar.FlatStyle = FlatStyle.Flat;
            this.btnContinuar.Font = new Font("Courier New", 10F, FontStyle.Bold);
            this.btnContinuar.Enabled = false;

            this.AutoScaleMode = AutoScaleMode.None;
            this.ClientSize = new Size(1250, 680);
            this.MinimumSize = new Size(1150, 650);
            this.Name = "FormSeleccionAmbiente";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "CHRONOS ARENA - CARTAS AMBIENTE";
            this.BackColor = Color.FromArgb(15, 31, 50);
            this.ForeColor = Color.White;
            this.Font = new Font("Courier New", 9.5F);
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.Sizable;

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