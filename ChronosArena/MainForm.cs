using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace ChronosArena
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Mantener el fondo detrás de los controles.
            picFondo.SendToBack();

            lblTitulo.BringToFront();
            btnEmpezar.BringToFront();
            btnCartas.BringToFront();
            btnReglas.BringToFront();
            btnRecord.BringToFront();
            btnSalir.BringToFront();
            btnDesarrolladores.BringToFront();

            LimpiarRecordDeInicio();
            CargarFondo();
        }

        private void LimpiarRecordDeInicio()
        {
            string ruta = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "BitacoraBatalla.txt");

            try
            {
                File.WriteAllText(ruta, String.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo preparar el archivo de récord: " + ex.Message,
                    "Chronos Arena");
            }
        }

        private void CargarFondo()
        {
            string url =
                "https://raw.githubusercontent.com/VedzabethCortez/ART_PACK/main/pictures/MAIN_MENU.jpg";

            try
            {
                picFondo.LoadAsync(url);
            }
            catch
            {
                MessageBox.Show(
                    "No se pudo cargar la imagen del menú.",
                    "Chronos Arena");
            }
        }

        private void BtnEmpezar_Click(object sender, EventArgs e)
        {
            using (FormModoJuego modo = new FormModoJuego())
            {
                if (modo.ShowDialog(this) != DialogResult.OK)
                    return;
            }

            using (FormSeleccionMazo selector = new FormSeleccionMazo())
            {
                if (selector.ShowDialog(this) == DialogResult.OK)
                {
                    using (FormBatalla batalla = new FormBatalla(
                        selector.MazoJugador,
                        selector.MazoIA))
                    {
                        batalla.ShowDialog(this);
                    }
                }
            }
        }

        private void BtnCartas_Click(object sender, EventArgs e)
        {
            using (FormCartas cartas = new FormCartas())
            {
                cartas.ShowDialog(this);
            }
        }

        private void BtnReglas_Click(object sender, EventArgs e)
        {
            using (FormVentanaReglas reglas = new FormVentanaReglas())
            {
                reglas.ShowDialog(this);
            }
        }

        private void BtnRecord_Click(object sender, EventArgs e)
        {
            string ruta = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "BitacoraBatalla.txt");

            if (!File.Exists(ruta) ||
                new FileInfo(ruta).Length == 0)
            {
                MessageBox.Show(
                    "Todavía no hay partidas registradas.",
                    "Chronos Arena",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            Form ventana = new Form();

            ventana.Text = "CHRONOS ARENA - RECORD";
            ventana.StartPosition = FormStartPosition.CenterParent;
            ventana.Size = new Size(650, 450);
            ventana.BackColor = Color.FromArgb(20, 24, 33);

            TextBox texto = new TextBox();

            texto.Multiline = true;
            texto.ReadOnly = true;
            texto.ScrollBars = ScrollBars.Vertical;
            texto.Dock = DockStyle.Fill;
            texto.Font = new Font("Consolas", 10F);
            texto.BackColor = Color.FromArgb(10, 14, 20);
            texto.ForeColor = Color.Gold;
            texto.Text = File.ReadAllText(ruta);

            ventana.Controls.Add(texto);
            ventana.ShowDialog(this);
            ventana.Dispose();
        }

        private void BtnDesarrolladores_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "CHRONOS ARENA\r\nProyecto desarrollado para Programación Orientada a Objetos.",
                "Desarrolladores",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}