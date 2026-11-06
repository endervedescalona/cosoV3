
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ChronosArena
{
    public partial class FormCartas : System.Windows.Forms.Form
    {
        private static readonly Dictionary<string, string> Descripciones =
            new Dictionary<string, string>()
        {
            {
                "Vista general",
                "CHRONOS ARENA\r\n\r\nEl mundo esta dividido en cuatro grandes clanes, cada uno vinculado a un elemento y a una cultura diferente. Selecciona un clan para conocer su historia y su origen."
            },
            {
                "Kazekiri",
                "KAZEKIRI - ELEMENTO: AIRE\r\n\r\nPor encima del mundo conocido se encuentran los templos celestiales de Kazekiri. Es un reino habitado por seres divinos y criaturas extraordinarias que viven entre las nubes."
            },
            {
                "Daichi",
                "DAICHI - ELEMENTO: TIERRA\r\n\r\nDaichi es un territorio donde la naturaleza y la ingenieria conviven. Sus paisajes estan llenos de vapor, engranajes, cristales y mecanismos."
            },
            {
                "Mizushiro",
                "MIZUSHIRO - ELEMENTO: AGUA\r\n\r\nMizushiro representa una sociedad donde el conocimiento y el desarrollo han permitido alcanzar grandes avances."
            },
            {
                "Homura",
                "HOMURA - ELEMENTO: FUEGO\r\n\r\nHomura es un reino abrasador dominado por el calor y las llamas. Sus habitantes poseen una gran conexion con el fuego."
            }
        };

        public FormCartas()
        {
            InitializeComponent();
            PantallaCompleta.Instalar(this);
            EscaladorInterfaz.Instalar(this);

            cmbClan.SelectedIndexChanged +=
                new EventHandler(Filtro_SelectedIndexChanged);

            fondo.LoadCompleted +=
                new AsyncCompletedEventHandler(Fondo_LoadCompleted);

            btnAtras.Click +=
                new EventHandler(BtnAtras_Click);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            CargarFondo("Vista general");
        }

        private void Filtro_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            if (cmbClan.SelectedItem == null)
                return;

            string clan = cmbClan.SelectedItem.ToString();

            string descripcion;

            if (Descripciones.TryGetValue(clan, out descripcion))
                lblDescripcion.Text = descripcion;

            CargarFondo(clan);
        }

        private void CargarFondo(string clan)
        {
            fondo.Image = null;
            fondo.BackColor = Color.FromArgb(15, 22, 40);

            if (String.IsNullOrEmpty(clan) ||
                clan == "Vista general")
                return;

            try
            {
                string url;

                Dictionary<string, string> urls =
                    GestorMazo.ObtenerUrls();

                if (urls.TryGetValue("fondo:clan:" + clan, out url)
                    && !String.IsNullOrWhiteSpace(url))
                {
                    fondo.LoadAsync(url);
                }
            }
            catch
            {
                fondo.Image = null;
            }
        }

        private void Fondo_LoadCompleted(
            object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null || e.Cancelled)
            {
                fondo.Image = null;
                fondo.BackColor = Color.FromArgb(15, 22, 40);
            }
        }

        private void BtnAtras_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
