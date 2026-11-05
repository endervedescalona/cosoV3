
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
        private System.Windows.Forms.Button btnDado;
        private System.Windows.Forms.Button btnElegir;
        private System.Windows.Forms.Button btnRetirar;
        private System.Windows.Forms.Button btnUrls;
        private System.Windows.Forms.Button btnComenzar;
        private System.Windows.Forms.Label lblJugador;
        private System.Windows.Forms.Label lblIA;

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
            this.lstMazoJugador = new System.Windows.Forms.ListBox();
            this.lstMazoIA = new System.Windows.Forms.ListBox();
            this.btnDado = new System.Windows.Forms.Button();
            this.btnElegir = new System.Windows.Forms.Button();
            this.btnRetirar = new System.Windows.Forms.Button();
            this.btnUrls = new System.Windows.Forms.Button();
            this.btnComenzar = new System.Windows.Forms.Button();
            this.lblJugador = new System.Windows.Forms.Label();
            this.lblIA = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // FORMULARIO
            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.BackColor =
                System.Drawing.Color.FromArgb(18, 22, 34);

            this.ClientSize =
                new System.Drawing.Size(1080, 640);

            this.MinimumSize =
                new System.Drawing.Size(1096, 679);

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterParent;

            this.Text = "Chronos Arena - Selección de mazo";

            // TITULO
            this.lblTitulo.Font =
                new System.Drawing.Font(
                    "Arial", 18F,
                    System.Drawing.FontStyle.Bold);

            this.lblTitulo.ForeColor =
                System.Drawing.Color.Gold;

            this.lblTitulo.Location =
                new System.Drawing.Point(15, 8);

            this.lblTitulo.Size =
                new System.Drawing.Size(1050, 36);

            this.lblTitulo.Text =
                "SELECCIÓN DE CARTAS - CHRONOS ARENA";

            // ESTADO
            this.lblEstado.ForeColor =
                System.Drawing.Color.White;

            this.lblEstado.BackColor =
                System.Drawing.Color.FromArgb(35, 42, 58);

            this.lblEstado.Location =
                new System.Drawing.Point(18, 48);

            this.lblEstado.Size =
                new System.Drawing.Size(1040, 34);

            this.lblEstado.Text =
                "Lanza los dados para decidir quién elige primero.";

            this.lblEstado.TextAlign =
                System.Drawing.ContentAlignment.MiddleLeft;

            // FILTRO
            this.lblFiltro.ForeColor =
                System.Drawing.Color.White;

            this.lblFiltro.Location =
                new System.Drawing.Point(18, 91);

            this.lblFiltro.Size =
                new System.Drawing.Size(80, 24);

            this.lblFiltro.Text = "Filtrar:";

            this.lblFiltro.TextAlign =
                System.Drawing.ContentAlignment.MiddleLeft;

            this.cmbFiltro.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.cmbFiltro.Location =
                new System.Drawing.Point(95, 91);

            this.cmbFiltro.Size =
                new System.Drawing.Size(220, 24);

            this.cmbFiltro.SelectedIndexChanged +=
                new System.EventHandler(
                    this.CmbFiltro_SelectedIndexChanged);

            // CONFIGURAR IMAGENES
            this.btnUrls.Location =
                new System.Drawing.Point(830, 88);

            this.btnUrls.Size =
                new System.Drawing.Size(228, 30);

            this.btnUrls.Text =
                "Configurar imágenes por URL";

            this.btnUrls.BackColor =
                System.Drawing.Color.FromArgb(65, 75, 95);

            this.btnUrls.ForeColor =
                System.Drawing.Color.White;

            this.btnUrls.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnUrls.Click +=
                new System.EventHandler(this.BtnUrls_Click);

            // CATALOGO
            this.panelCatalogo.AutoScroll = true;

            this.panelCatalogo.BackColor =
                System.Drawing.Color.FromArgb(26, 31, 44);

            this.panelCatalogo.Location =
                new System.Drawing.Point(18, 125);

            this.panelCatalogo.Size =
                new System.Drawing.Size(665, 495);

            this.panelCatalogo.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left;

            // MAZO DEL JUGADOR
            this.lblJugador.ForeColor =
                System.Drawing.Color.LightSkyBlue;

            this.lblJugador.Location =
                new System.Drawing.Point(700, 130);

            this.lblJugador.Size =
                new System.Drawing.Size(175, 24);

            this.lblJugador.Text = "TU MAZO (0/5)";

            this.lstMazoJugador.Location =
                new System.Drawing.Point(700, 155);

            this.lstMazoJugador.Size =
                new System.Drawing.Size(175, 150);

            this.lstMazoJugador.BackColor =
                System.Drawing.Color.FromArgb(35, 42, 58);

            this.lstMazoJugador.ForeColor =
                System.Drawing.Color.White;

            // MAZO DE LA IA
            this.lblIA.ForeColor =
                System.Drawing.Color.Orange;

            this.lblIA.Location =
                new System.Drawing.Point(885, 130);

            this.lblIA.Size =
                new System.Drawing.Size(175, 24);

            this.lblIA.Text = "MAZO IA (0/5)";

            this.lstMazoIA.Location =
                new System.Drawing.Point(885, 155);

            this.lstMazoIA.Size =
                new System.Drawing.Size(175, 150);

            this.lstMazoIA.BackColor =
                System.Drawing.Color.FromArgb(35, 42, 58);

            this.lstMazoIA.ForeColor =
                System.Drawing.Color.White;

            this.lstMazoIA.Enabled = false;

            // BOTON DADOS
            this.btnDado.Location =
                new System.Drawing.Point(700, 320);

            this.btnDado.Size =
                new System.Drawing.Size(360, 42);

            this.btnDado.Text = "Lanzar dados";

            this.btnDado.BackColor =
                System.Drawing.Color.FromArgb(45, 83, 126);

            this.btnDado.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnDado.FlatAppearance.BorderSize = 0;

            this.btnDado.ForeColor =
                System.Drawing.Color.White;

            this.btnDado.Font =
                new System.Drawing.Font(
                    "Arial", 9F,
                    System.Drawing.FontStyle.Bold);

            this.btnDado.Cursor =
                System.Windows.Forms.Cursors.Hand;

            this.btnDado.Click +=
                new System.EventHandler(this.BtnDado_Click);

            // BOTON CONFIRMAR CARTA
            this.btnElegir.Location =
                new System.Drawing.Point(700, 370);

            this.btnElegir.Size =
                new System.Drawing.Size(360, 42);

            this.btnElegir.Text = "Confirmar carta";

            this.btnElegir.BackColor =
                System.Drawing.Color.FromArgb(45, 100, 126);

            this.btnElegir.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnElegir.FlatAppearance.BorderSize = 0;

            this.btnElegir.ForeColor =
                System.Drawing.Color.White;

            this.btnElegir.Font =
                new System.Drawing.Font(
                    "Arial", 9F,
                    System.Drawing.FontStyle.Bold);

            this.btnElegir.Cursor =
                System.Windows.Forms.Cursors.Hand;

            this.btnElegir.Enabled = false;

            this.btnElegir.Click +=
                new System.EventHandler(this.BtnElegir_Click);

            // BOTON RETIRAR CARTA
            this.btnRetirar.Location =
                new System.Drawing.Point(700, 420);

            this.btnRetirar.Size =
                new System.Drawing.Size(360, 42);

            this.btnRetirar.Text =
                "Retirar carta y reemplazar";

            this.btnRetirar.BackColor =
                System.Drawing.Color.FromArgb(110, 75, 45);

            this.btnRetirar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnRetirar.FlatAppearance.BorderSize = 0;

            this.btnRetirar.ForeColor =
                System.Drawing.Color.White;

            this.btnRetirar.Font =
                new System.Drawing.Font(
                    "Arial", 9F,
                    System.Drawing.FontStyle.Bold);

            this.btnRetirar.Enabled = false;

            this.btnRetirar.Click +=
                new System.EventHandler(this.BtnRetirar_Click);

            // BOTON COMENZAR BATALLA
            this.btnComenzar.Location =
                new System.Drawing.Point(700, 480);

            this.btnComenzar.Size =
                new System.Drawing.Size(360, 50);

            this.btnComenzar.Text =
                "COMENZAR BATALLA";

            this.btnComenzar.BackColor =
                System.Drawing.Color.FromArgb(155, 43, 48);

            this.btnComenzar.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            this.btnComenzar.FlatAppearance.BorderSize = 0;

            this.btnComenzar.ForeColor =
                System.Drawing.Color.White;

            this.btnComenzar.Font =
                new System.Drawing.Font(
                    "Arial", 11F,
                    System.Drawing.FontStyle.Bold);

            this.btnComenzar.Enabled = false;

            this.btnComenzar.Click +=
                new System.EventHandler(this.BtnComenzar_Click);

            // AGREGAR CONTROLES
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.cmbFiltro);
            this.Controls.Add(this.btnUrls);
            this.Controls.Add(this.panelCatalogo);
            this.Controls.Add(this.lblJugador);
            this.Controls.Add(this.lstMazoJugador);
            this.Controls.Add(this.lblIA);
            this.Controls.Add(this.lstMazoIA);
            this.Controls.Add(this.btnDado);
            this.Controls.Add(this.btnElegir);
            this.Controls.Add(this.btnRetirar);
            this.Controls.Add(this.btnComenzar);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
