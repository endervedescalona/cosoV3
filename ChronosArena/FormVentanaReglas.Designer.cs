namespace ChronosArena
{
    partial class FormVentanaReglas
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtReglas;
        private System.Windows.Forms.Button btnCerrar;

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

            this.txtReglas = new System.Windows.Forms.TextBox();
            this.btnCerrar = new System.Windows.Forms.Button();

            this.SuspendLayout();

            this.txtReglas.Location =
                new System.Drawing.Point(18, 18);
            this.txtReglas.Size =
                new System.Drawing.Size(560, 390);
            this.txtReglas.Multiline = true;
            this.txtReglas.ReadOnly = true;
            this.txtReglas.ScrollBars =
                System.Windows.Forms.ScrollBars.Vertical;
            this.txtReglas.Font =
                new System.Drawing.Font("Arial", 10F);
            this.txtReglas.BackColor =
                System.Drawing.Color.FromArgb(30, 36, 50);
            this.txtReglas.ForeColor =
                System.Drawing.Color.White;

            this.btnCerrar.Location =
                new System.Drawing.Point(418, 422);
            this.btnCerrar.Size =
                new System.Drawing.Size(160, 38);
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.BackColor =
                System.Drawing.Color.FromArgb(45, 83, 126);
            this.btnCerrar.ForeColor =
                System.Drawing.Color.White;
            this.btnCerrar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Click +=
                new System.EventHandler(this.BtnCerrar_Click);

            this.BackColor =
                System.Drawing.Color.FromArgb(18, 22, 34);
            this.ClientSize =
                new System.Drawing.Size(596, 475);
            this.Controls.Add(this.txtReglas);
            this.Controls.Add(this.btnCerrar);
            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chronos Arena - Reglas";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}