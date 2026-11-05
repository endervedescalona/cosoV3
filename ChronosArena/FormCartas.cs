using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ChronosArena
{
    public class FormCartas : Form
    {
        private PictureBox fondo;

        private ComboBox filtro;

        private Label titulo;

        private Label descripcion;

        private static readonly Dictionary<string, string> Fondos =
            new Dictionary<string, string>()
        {
            {
                "Mizushiro",
                "https://raw.githubusercontent.com/VedzabethCortez/ART_PACK/main/pictures/NEOMIZU.jpeg"
            },
            {
                "Kazekiri",
                "https://raw.githubusercontent.com/VedzabethCortez/ART_PACK/main/pictures/OLIMPUS.jpeg"
            },
            {
                "Homura",
                "https://raw.githubusercontent.com/VedzabethCortez/ART_PACK/main/pictures/VELLIGNIS.jpeg"
            },
            {
                "Daichi",
                "https://raw.githubusercontent.com/VedzabethCortez/ART_PACK/main/pictures/BRANCHES.jpeg"
            }
        };

        private static readonly Dictionary<string, string> Descripciones =
            new Dictionary<string, string>()
        {
            {
                "Vista general",
                "CHRONOS ARENA\r\n\r\n" +
                "El mundo está dividido en cuatro grandes clanes, " +
                "cada uno vinculado a un elemento y a una cultura diferente. " +
                "Selecciona un clan para conocer su historia y su origen."
            },
            {
                "Kazekiri",
                "KAZEKIRI - ELEMENTO: AIRE\r\n\r\n" +
                "Por encima del mundo conocido se encuentran los templos " +
                "celestiales de Kazekiri. Es un reino habitado por seres " +
                "divinos y criaturas extraordinarias que viven entre las " +
                "nubes. Sus habitantes poseen una conexión especial con " +
                "el viento y los poderes celestiales. Entre ellos se " +
                "encuentra Ibuki, un ser vinculado a este mundo superior."
            },
            {
                "Daichi",
                "DAICHI - ELEMENTO: TIERRA\r\n\r\n" +
                "Daichi es un territorio donde la naturaleza y la " +
                "ingeniería conviven. Sus paisajes están llenos de vapor, " +
                "engranajes, cristales y mecanismos. Sus habitantes han " +
                "aprendido a combinar los recursos naturales con la " +
                "tecnología para construir una sociedad poderosa."
            },
            {
                "Mizushiro",
                "MIZUSHIRO - ELEMENTO: AGUA\r\n\r\n" +
                "Mizushiro representa una sociedad de apariencia utópica, " +
                "donde el conocimiento y el desarrollo han permitido " +
                "alcanzar grandes avances. Sus habitantes son conocidos " +
                "por su inteligencia, agilidad y poder. El agua representa " +
                "la fluidez y la adaptación de este clan."
            },
            {
                "Homura",
                "HOMURA - ELEMENTO: FUEGO\r\n\r\n" +
                "Homura es un reino abrasador que parece estar atrapado " +
                "en el tiempo. Sus territorios están dominados por el " +
                "calor y las llamas. Sus habitantes son seres luminosos " +
                "que poseen una gran conexión con el fuego y son capaces " +
                "de controlar poderes de enorme intensidad."
            }
        };

        public FormCartas()
        {
            Text = "Chronos Arena - Cartas";

            ClientSize = new Size(920, 510);

            StartPosition = FormStartPosition.CenterParent;

            FormBorderStyle = FormBorderStyle.FixedSingle;

            MaximizeBox = false;

            // Fondo
            fondo = new PictureBox();

            fondo.Dock = DockStyle.Fill;

            fondo.SizeMode =
                PictureBoxSizeMode.StretchImage;

            fondo.BackColor =
                Color.FromArgb(15, 22, 40);

            Controls.Add(fondo);

            // Título
            titulo = new Label();

            titulo.Text = "CARTAS";

            titulo.Font = new Font(
                "Arial", 24F, FontStyle.Bold);

            titulo.ForeColor = Color.White;

            titulo.BackColor =
                Color.FromArgb(120, 10, 15, 30);

            titulo.TextAlign =
                ContentAlignment.MiddleCenter;

            titulo.SetBounds(290, 25, 340, 48);

            Controls.Add(titulo);

            // Descripción del clan
            descripcion = new Label();

            descripcion.Font = new Font(
                "Arial", 12F, FontStyle.Regular);

            descripcion.ForeColor = Color.White;

            descripcion.BackColor =
                Color.FromArgb(190, 10, 15, 30);

            descripcion.TextAlign =
                ContentAlignment.MiddleCenter;

            descripcion.BorderStyle =
                BorderStyle.FixedSingle;

            descripcion.Padding =
                new Padding(20);

            descripcion.SetBounds(
                200, 155, 520, 240);

            descripcion.AutoSize = false;

            Controls.Add(descripcion);

            // Etiqueta del filtro
            Label etiqueta = new Label();

            etiqueta.Text = "FILTRAR POR CLAN:";

            etiqueta.Font = new Font(
                "Arial", 11F, FontStyle.Bold);

            etiqueta.ForeColor = Color.White;

            etiqueta.BackColor =
                Color.FromArgb(130, 10, 15, 30);

            etiqueta.SetBounds(270, 95, 150, 30);

            etiqueta.TextAlign =
                ContentAlignment.MiddleCenter;

            Controls.Add(etiqueta);

            // Selector de clanes
            filtro = new ComboBox();

            filtro.DropDownStyle =
                ComboBoxStyle.DropDownList;

            filtro.Font =
                new Font("Arial", 11F);

            filtro.SetBounds(425, 95, 220, 30);

            filtro.Items.AddRange(
                new object[]
                {
                    "Vista general",
                    "Mizushiro",
                    "Kazekiri",
                    "Homura",
                    "Daichi"
                });

            filtro.SelectedIndexChanged +=
                Filtro_SelectedIndexChanged;

            Controls.Add(filtro);

            // Botón para regresar
            Button atras = new Button();

            atras.Text = "ATRÁS";

            atras.Font = new Font(
                "Arial", 11F, FontStyle.Bold);

            atras.SetBounds(15, 455, 185, 40);

            atras.Click += delegate
            {
                Close();
            };

            Controls.Add(atras);

            // Vista inicial
            filtro.SelectedIndex = 0;

            // Mantener los controles por encima del fondo.
            titulo.BringToFront();

            descripcion.BringToFront();

            etiqueta.BringToFront();

            filtro.BringToFront();

            atras.BringToFront();
        }

        private void Filtro_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            // Quitar cualquier imagen anterior.
            fondo.Image = null;

            string clan = filtro.SelectedItem.ToString();

            // Actualizar descripción.
            if (Descripciones.ContainsKey(clan))
            {
                descripcion.Text =
                    Descripciones[clan];
            }

            // La vista general no tiene imagen de clan.
            string url;

            if (!Fondos.TryGetValue(clan, out url))
                return;

            // Cargar el fondo correspondiente al clan.
            try
            {
                fondo.LoadAsync(url);
            }
            catch
            {
                fondo.Image = null;
            }
        }
    }
}