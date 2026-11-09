using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ChronosArena
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            PantallaCompleta.Instalar(this);
            EscaladorInterfaz.Instalar(this);
            picFondo.LoadCompleted += PicFondo_LoadCompleted;
            picFondo.SendToBack();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (System.ComponentModel.LicenseManager.UsageMode ==
                System.ComponentModel.LicenseUsageMode.Designtime)
                return;

            CargarFondo();
        }

        /*private void CargarFondo() //OCULTA POKE AJA//
        {
            picFondo.BackColor = Color.FromArgb(20, 25, 38);
            try
            {
                string url;
                Dictionary<string, string> urls = GestorMazo.ObtenerUrls();
                if (urls.TryGetValue("fondo:menu", out url) &&
                    !String.IsNullOrWhiteSpace(url))
                {
                    picFondo.LoadAsync(url);
                }
                else
                {
                    picFondo.Image = null;
                }
            }
            catch (Exception)
            {
                picFondo.Image = null;
            }
        }
        */
       
       
		private void CargarFondo()
		{
			picFondo.BackColor = Color.FromArgb(20, 25, 38);
			try
    		{
        		string url;
        		Dictionary<string, string> urls = GestorMazo.ObtenerUrls();
        		if (urls.TryGetValue("fondo:menu", out url) && !String.IsNullOrWhiteSpace(url))
        		{
            			string nombreArchivo = System.IO.Path.GetFileName(url);
           				 CargadorLocal.CargarImagen(picFondo, nombreArchivo);
        		}
        		else
       		 	{
            		picFondo.Image = null;
        		}
   			 }
    		catch (Exception)
    		{
        picFondo.Image = null;
    	}
	}

        private void PicFondo_LoadCompleted(
            object sender,
            System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Error != null || e.Cancelled)
            {
                picFondo.Image = null;
                picFondo.BackColor = Color.FromArgb(20, 25, 38);
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
                        selector.MazoJugador, selector.MazoIA))
                    {
                        batalla.ShowDialog(this);
                    }
                }
            }
        }

        private void BtnCartas_Click(object sender, EventArgs e)
        {
            using (FormCartas cartas = new FormCartas())
                cartas.ShowDialog(this);
        }

        private void BtnReglas_Click(object sender, EventArgs e)
        {
            using (FormVentanaReglas reglas = new FormVentanaReglas())
                reglas.ShowDialog(this);
        }

        private void BtnRecord_Click(object sender, EventArgs e)
        {
            string ruta = GestorBatalla.ObtenerRutaHistorial();

            try
            {
                if (!File.Exists(ruta) || new FileInfo(ruta).Length == 0)
                {
                    MessageBox.Show(
                        "Todavía no hay partidas registradas.",
                        "Chronos Arena",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                using (Form ventana = new Form())
                {
                    ventana.Text = "CHRONOS ARENA - RECORD";
                    ventana.StartPosition = FormStartPosition.CenterParent;
                    ventana.Size = new Size(720, 500);
                    ventana.MinimumSize = new Size(600, 400);
                    ventana.BackColor = Color.FromArgb(20, 24, 33);

                    TextBox texto = new TextBox();
                    texto.Multiline = true;
                    texto.ReadOnly = true;
                    texto.ScrollBars = ScrollBars.Both;
                    texto.WordWrap = false;
                    texto.Dock = DockStyle.Fill;
                    texto.Font = new Font("Courier New", 10F);
                    texto.BackColor = Color.FromArgb(10, 14, 20);
                    texto.ForeColor = Color.Gold;
                    texto.Text = File.ReadAllText(ruta, Encoding.UTF8);
                    ventana.Controls.Add(texto);
                    ventana.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo leer el historial de partidas: " + ex.Message,
                    "Chronos Arena",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
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
