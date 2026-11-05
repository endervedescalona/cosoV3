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

        private System.Windows.Forms.ListBox lstMazoJugador;
        private System.Windows.Forms.ListBox lstMazoIA;

        private System.Windows.Forms.Button btnElegir;
        private System.Windows.Forms.Button btnRetirar;
        private System.Windows.Forms.Button btnUrls;
        private System.Windows.Forms.Button btnComenzar;
        private System.Windows.Forms.Button btnVolverModo;

        private System.Windows.Forms.Label lblJugador;
        private System.Windows.Forms.Label lblIA;

        private System.Windows.Forms.PictureBox picReverso;

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
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblFiltro = new System.Windows.Forms.Label();

            this.cmbFiltro = new System.Windows.Forms.ComboBox();

            this.panelCatalogo =
                new System.Windows.Forms.FlowLayoutPanel();

            this.lstMazoJugador =
                new System.Windows.Forms.ListBox();

            this.lstMazoIA =
                new System.Windows.Forms.ListBox();

            this.btnElegir = new System.Windows.Forms.Button();
            this.btnRetirar = new System.Windows.Forms.Button();
            this.btnUrls = new System.Windows.Forms.Button();
            this.btnComenzar = new System.Windows.Forms.Button();
            this.btnVolverModo = new System.Windows.Forms.Button();

            this.lblJugador = new System.Windows.Forms.Label();
            this.lblIA = new System.Windows.Forms.Label();

            this.picReverso =
                new System.Windows.Forms.PictureBox();

            ((System.ComponentModel.ISupportInitialize)
                (this.picReverso)).BeginInit();

            this.SuspendLayout();

            // Formulario
            this.BackColor =
                System.Drawing.Color.FromArgb(7, 39, 59);

            this.ClientSize =
                new System.Drawing.Size(920, 510);

            this.MinimumSize =
                new System.Drawing.Size(936, 549);

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterParent;

            this.Text = "Chronos Arena - Selección de personajes";

            // lblTitulo
            this.lblTitulo.SetBounds(18, 10, 350, 32);

            this.lblTitulo.Text =
                "SELECCIÓN DE PERSONAJES";

            this.lblTitulo.Font = new System.Drawing.Font(
                "Arial", 17F, System.Drawing.FontStyle.Bold);

            this.lblTitulo.ForeColor =
                System.Drawing.Color.White;

            // lblEstado
            this.lblEstado.SetBounds(345, 455, 255, 42);

            this.lblEstado.Text =
                "Selecciona una carta del catálogo.";

            this.lblEstado.ForeColor =
                System.Drawing.Color.White;

            this.lblEstado.BackColor =
                System.Drawing.Color.FromArgb(20, 55, 75);

            this.lblEstado.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;

            // lblFiltro
            this.lblFiltro.SetBounds(18, 48, 75, 22);

            this.lblFiltro.Text = "FILTRAR POR";

            this.lblFiltro.Font = new System.Drawing.Font(
                "Arial", 8F, System.Drawing.FontStyle.Bold);

            this.lblFiltro.ForeColor =
                System.Drawing.Color.White;

            // cmbFiltro
            this.cmbFiltro.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cmbFiltro.SetBounds(98, 46, 205, 24);

            this.cmbFiltro.SelectedIndexChanged +=
                new System.EventHandler(
                    this.CmbFiltro_SelectedIndexChanged);

            // picReverso
            this.picReverso.SetBounds(18, 78, 285, 415);

            this.picReverso.SizeMode =
                System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            this.picReverso.BackColor =
                System.Drawing.Color.FromArgb(30, 20, 48);

            // panelCatalogo
            this.panelCatalogo.SetBounds(315, 78, 285, 360);

            this.panelCatalogo.AutoScroll = true;

            this.panelCatalogo.WrapContents = true;

            this.panelCatalogo.BackColor =
                System.Drawing.Color.FromArgb(10, 35, 53);

            // lblJugador
            this.lblJugador.SetBounds(620, 15, 135, 25);

            this.lblJugador.Text = "TU MAZO (0/5)";

            this.lblJugador.Font = new System.Drawing.Font(
                "Arial", 12F, System.Drawing.FontStyle.Bold);

            this.lblJugador.ForeColor =
                System.Drawing.Color.White;

            // lstMazoJugador
            this.lstMazoJugador.SetBounds(620, 45, 135, 145);

            this.lstMazoJugador.BackColor =
                System.Drawing.Color.FromArgb(25, 49, 65);

            this.lstMazoJugador.ForeColor =
                System.Drawing.Color.White;

            this.lstMazoJugador.Font =
                new System.Drawing.Font("Arial", 8F);

            // lblIA
            this.lblIA.SetBounds(620, 200, 135, 25);

            this.lblIA.Text = "MAZO PC (0/5)";

            this.lblIA.Font = new System.Drawing.Font(
                "Arial", 12F, System.Drawing.FontStyle.Bold);

            this.lblIA.ForeColor =
                System.Drawing.Color.White;

            // lstMazoIA
            this.lstMazoIA.SetBounds(620, 230, 135, 125);

            this.lstMazoIA.BackColor =
                System.Drawing.Color.FromArgb(25, 49, 65);

            this.lstMazoIA.ForeColor =
                System.Drawing.Color.White;

            this.lstMazoIA.Font =
                new System.Drawing.Font("Arial", 8F);

            this.lstMazoIA.Enabled = false;

            // btnUrls
            this.btnUrls.Visible = false;

            this.btnUrls.Click +=
                new System.EventHandler(this.BtnUrls_Click);

            // btnVolverModo
            this.btnVolverModo.SetBounds(620, 370, 135, 38);

            this.btnVolverModo.Text = "VOLVER A MODOS";

            this.btnVolverModo.Click +=
                new System.EventHandler(this.BtnVolverModo_Click);

            // btnElegir
            this.btnElegir.SetBounds(770, 365, 135, 40);

            this.btnElegir.Text = "CONFIRMAR CARTA";

            this.btnElegir.Enabled = false;

            this.btnElegir.Click +=
                new System.EventHandler(this.BtnElegir_Click);

            // btnRetirar
            this.btnRetirar.SetBounds(770, 412, 135, 40);

            this.btnRetirar.Text = "RETIRAR CARTA";

            this.btnRetirar.Enabled = false;

            this.btnRetirar.Click +=
                new System.EventHandler(this.BtnRetirar_Click);

            // btnComenzar
            this.btnComenzar.SetBounds(770, 459, 135, 38);

            this.btnComenzar.Text = "CONTINUAR";

            this.btnComenzar.Enabled = false;

            this.btnComenzar.Click +=
                new System.EventHandler(this.BtnComenzar_Click);

            // Estilo de botones
            System.Windows.Forms.Button[] botones =
                new System.Windows.Forms.Button[]
                {
                    this.btnUrls,
                    this.btnVolverModo,
                    this.btnElegir,
                    this.btnRetirar,
                    this.btnComenzar
                };

            foreach (System.Windows.Forms.Button b in botones)
            {
                b.Font = new System.Drawing.Font(
                    "Arial", 8.5F,
                    System.Drawing.FontStyle.Bold);

                b.BackColor =
                    System.Drawing.Color.Gainsboro;

                b.ForeColor =
                    System.Drawing.Color.Black;

                b.FlatStyle =
                    System.Windows.Forms.FlatStyle.Flat;

                b.Cursor =
                    System.Windows.Forms.Cursors.Hand;
            }

            // Agregar controles
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

            ((System.ComponentModel.ISupportInitialize)
                (this.picReverso)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}