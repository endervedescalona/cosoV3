namespace ChronosArena
{
    partial class FormImagenes
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.Panel panelUrls;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components =
                new System.ComponentModel.Container();

            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNota = new System.Windows.Forms.Label();
            this.panelUrls = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();

            this.SuspendLayout();

            this.lblTitulo.Font =
                new System.Drawing.Font("Arial", 16F,
                    System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor =
                System.Drawing.Color.Gold;
            this.lblTitulo.Location =
                new System.Drawing.Point(15, 10);
            this.lblTitulo.Size =
                new System.Drawing.Size(740, 35);
            this.lblTitulo.Text = "CONFIGURAR IMÁGENES ONLINE";

            this.lblNota.ForeColor =
                System.Drawing.Color.LightSteelBlue;
            this.lblNota.Location =
                new System.Drawing.Point(18, 48);
            this.lblNota.Size =
                new System.Drawing.Size(730, 28);
            this.lblNota.Text =
                "Pega URL públicas de imágenes HTTP/HTTPS.";

            this.panelUrls.AutoScroll = true;
            this.panelUrls.Location =
                new System.Drawing.Point(18, 82);
            this.panelUrls.Size =
                new System.Drawing.Size(730, 440);
            this.panelUrls.BackColor =
                System.Drawing.Color.FromArgb(26, 31, 44);

            this.btnGuardar.Location =
                new System.Drawing.Point(390, 535);
            this.btnGuardar.Size =
                new System.Drawing.Size(170, 38);
            this.btnGuardar.Text = "Guardar URL";
            this.btnGuardar.BackColor =
                System.Drawing.Color.FromArgb(45, 120, 75);
            this.btnGuardar.ForeColor =
                System.Drawing.Color.White;
            this.btnGuardar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Click +=
                new System.EventHandler(this.BtnGuardar_Click);

            this.btnCancelar.Location =
                new System.Drawing.Point(575, 535);
            this.btnCancelar.Size =
                new System.Drawing.Size(170, 38);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.BackColor =
                System.Drawing.Color.FromArgb(65, 70, 85);
            this.btnCancelar.ForeColor =
                System.Drawing.Color.White;
            this.btnCancelar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Click +=
                new System.EventHandler(this.BtnCancelar_Click);

            this.BackColor =
                System.Drawing.Color.FromArgb(18, 22, 34);
            this.ClientSize =
                new System.Drawing.Size(765, 590);

            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblNota);
            this.Controls.Add(this.panelUrls);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chronos Arena - URLs";

            this.ResumeLayout(false);
        }
    }
}