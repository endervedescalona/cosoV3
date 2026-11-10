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
            DoubleBuffered = true;
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

        private void CargarFondo()
        {
            picFondo.BackColor = Color.FromArgb(20, 25, 38);
            try
            {
                string url;
                Dictionary<string, string> urls = GestorMazo.ObtenerUrls();
                if (urls.TryGetValue("fondo:menu", out url) &&
                    !String.IsNullOrWhiteSpace(url))
                {
                    CargadorLocal.CargarImagen(picFondo, System.IO.Path.GetFileName(url));
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

            try
            {
                // Si el usuario pulsa ATRAS en la preparación, vuelve a la
                // selección del mazo, no se pierde directamente al menú.
                while (true)
                {
                    List<Personaje> equipo1;
                    List<Personaje> equipo2;

                    using (FormSeleccionMazo selector = new FormSeleccionMazo())
                    {
                        if (selector.ShowDialog(this) != DialogResult.OK)
                            return;

                        if (PartidaConfig.EsOnline)
                        {
                            GestorRed red = PartidaConfig.Red;
                            equipo1 = red.EsAnfitrion ? selector.MazoJugador : selector.MazoIA;
                            equipo2 = red.EsAnfitrion ? selector.MazoIA : selector.MazoJugador;
                        }
                        else
                        {
                            equipo1 = selector.MazoJugador;
                            equipo2 = selector.MazoIA;
                        }
                    }

                    bool ambienteConfirmado = false;
                    bool volverSeleccionMazo = false;
                    while (!ambienteConfirmado)
                    {
                        using (FormPrePartida preparacion = new FormPrePartida())
                        {
                            if (preparacion.ShowDialog(this) != DialogResult.OK)
                            {
                                if (PartidaConfig.EsOnline)
                                    return;
                                volverSeleccionMazo = true;
                                break;
                            }

                            PartidaConfig.NombreJugador1 = preparacion.NombreJugador1;
                            PartidaConfig.NombreJugador2 = preparacion.NombreJugador2;
                            PartidaConfig.EquipoInicial = preparacion.EquipoComienza;
                        }

                        using (FormSeleccionAmbiente ambiente = new FormSeleccionAmbiente(PartidaConfig.EquipoInicial))
                        {
                            DialogResult resultadoAmbiente = ambiente.ShowDialog(this);
                            if (resultadoAmbiente == DialogResult.OK)
                                ambienteConfirmado = true;
                            else if (PartidaConfig.EsOnline)
                                return; // la conexión se cancela en ambos equipos
                            // En modo local, ATRAS vuelve a la fase de dados.
                        }
                    }

                    if (volverSeleccionMazo)
                        continue;

                    FormBatalla batalla;
                    if (PartidaConfig.EsOnline)
                        batalla = new FormBatalla(equipo1, equipo2, PartidaConfig.Red);
                    else
                        batalla = new FormBatalla(equipo1, equipo2);

                    using (batalla)
                        batalla.ShowDialog(this);
                    break;
                }
            }
            finally
            {
                PartidaConfig.Reiniciar();
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
