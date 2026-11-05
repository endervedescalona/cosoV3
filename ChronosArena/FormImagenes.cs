using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ChronosArena
{
    public partial class FormImagenes : Form
    {
        private Dictionary<string, TextBox> campos =
            new Dictionary<string, TextBox>();

        public FormImagenes()
        {
            InitializeComponent();

            Dictionary<string, string> urls = GestorMazo.ObtenerUrls();
            List<Personaje> personajes =
                GestorMazo.ObtenerMazoCompleto();

            int y = 8;

            AgregarCampo("Fondo de selección",
                "fondo:seleccion", y, urls);
            y += 38;

            AgregarCampo("Fondo de batalla",
                "fondo:batalla", y, urls);
            y += 42;

            foreach (Personaje p in personajes)
            {
                AgregarCampo(
                    p.Nombre + " (" + p.Clase + ", " + p.Faccion + ")",
                    "personaje:" + p.Nombre,
                    y,
                    urls);

                y += 38;
            }
        }

        private void AgregarCampo(
            string titulo,
            string clave,
            int y,
            Dictionary<string, string> urls)
        {
            Label label = new Label();
            label.Text = titulo;
            label.ForeColor = Color.White;
            label.Location = new Point(8, y + 3);
            label.Size = new Size(205, 25);

            TextBox box = new TextBox();
            box.Location = new Point(218, y);
            box.Size = new Size(485, 25);

            box.Text = urls.ContainsKey(clave)
                ? urls[clave]
                : String.Empty;

            panelUrls.Controls.Add(label);
            panelUrls.Controls.Add(box);

            campos.Add(clave, box);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> urls =
                GestorMazo.ObtenerUrls();

            foreach (KeyValuePair<string, TextBox> par in campos)
            {
                string valor = par.Value.Text.Trim();

                if (valor.Length > 0 &&
                    !valor.StartsWith("http://",
                        StringComparison.OrdinalIgnoreCase) &&
                    !valor.StartsWith("https://",
                        StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(
                        "La URL de '" + par.Key +
                        "' debe comenzar con http:// o https://.",
                        "URL inválida",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    par.Value.Focus();
                    return;
                }

                urls[par.Key] = valor;
            }

            try
            {
                GestorMazo.GuardarUrls(urls);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron guardar las URL: " + ex.Message,
                    "Error");
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}