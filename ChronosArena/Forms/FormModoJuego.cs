
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ChronosArena
{
    public partial class FormModoJuego : Form
    {
        public FormModoJuego()
        {
            InitializeComponent();
            PantallaCompleta.Instalar(this);
            EscaladorInterfaz.Instalar(this);

            // Evitar operaciones externas en el diseñador.
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            CargarFondo();
        }

        private void CargarFondo()
        {
            try
            {
                string url;
                if (GestorMazo.ObtenerUrls().TryGetValue(
                    "fondo:modo", out url) &&
                    !String.IsNullOrWhiteSpace(url))
                {
                    CargadorLocal.CargarImagen(picFondo, System.IO.Path.GetFileName(url));
                }
            }
            catch
            {
                picFondo.Image = null;
            }
        }

        private void BtnLocal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnDosJugadores_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "El modo de dos jugadores todavía no está implementado.",
                "Chronos Arena",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void BtnOnline_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "El modo en línea todavía no está implementado.",
                "Chronos Arena",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void BtnAtras_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
