using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChronosArena
{
    public class FormModoJuego : Form
    {
        private PictureBox picFondo;

        public FormModoJuego()
        {
            Text = "Chronos Arena - Modo de juego";

            ClientSize = new Size(920, 510);

            StartPosition = FormStartPosition.CenterParent;

            FormBorderStyle = FormBorderStyle.FixedSingle;

            MaximizeBox = false;

            // Fondo
            picFondo = new PictureBox();

            picFondo.Dock = DockStyle.Fill;

            picFondo.SizeMode =
                PictureBoxSizeMode.StretchImage;

            picFondo.BackColor =
                Color.FromArgb(17, 20, 35);

            Controls.Add(picFondo);

            try
            {
                picFondo.LoadAsync(
                    "https://raw.githubusercontent.com/VedzabethCortez/ART_PACK/main/pictures/GAME_MODE.jpg");
            }
            catch
            {
                // Se conserva el color de respaldo.
            }

            // Título
            Label titulo = new Label();

            titulo.Text = "MODO DE JUEGO";

            titulo.Font = new Font(
                "Arial", 24F, FontStyle.Bold);

            titulo.ForeColor = Color.White;

            titulo.BackColor =
                Color.FromArgb(90, 10, 15, 25);

            titulo.TextAlign =
                ContentAlignment.MiddleCenter;

            titulo.SetBounds(250, 215, 420, 42);

            Controls.Add(titulo);

            // Modos
            CrearBoton(
                "LOCAL (JUGADOR VS IA)",
                300, 267, true);

            CrearBoton(
                "2 JUGADORES (MISMO PC)",
                300, 315, false);

            CrearBoton(
                "EN LINEA",
                300, 363, false);

            // Retorno al menú principal
            Button atras = CrearEstiloBoton(
                "VOLVER AL MENÚ PRINCIPAL",
                12, 455, 260, 42);

            atras.Click += delegate
            {
                DialogResult = DialogResult.Cancel;
                Close();
            };

            Controls.Add(atras);

            titulo.BringToFront();
            atras.BringToFront();
        }

        private Button CrearEstiloBoton(
            string texto,
            int x,
            int y,
            int w,
            int h)
        {
            Button b = new Button();

            b.Text = texto;

            b.SetBounds(x, y, w, h);

            b.Font = new Font(
                "Arial", 11F, FontStyle.Bold);

            b.BackColor = Color.Gainsboro;

            b.ForeColor = Color.Black;

            b.FlatStyle = FlatStyle.Flat;

            b.FlatAppearance.BorderSize = 2;

            b.Cursor = Cursors.Hand;

            return b;
        }

        private void CrearBoton(
            string texto,
            int x,
            int y,
            bool disponible)
        {
            Button b = CrearEstiloBoton(
                texto, x, y, 320, 40);

            b.Click += delegate
            {
                if (disponible)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show(
                        "Esta modalidad todavía no está implementada.",
                        "Chronos Arena");
                }
            };

            Controls.Add(b);

            b.BringToFront();
        }
    }
}