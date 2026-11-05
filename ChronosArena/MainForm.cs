using System;
using System.Windows.Forms;

namespace ChronosArena
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnEmpezar_Click(object sender, EventArgs e)
        {
            using (FormSeleccionMazo selector = new FormSeleccionMazo())
            {
                if (selector.ShowDialog(this) == DialogResult.OK)
                {
                    using (FormBatalla batalla =
                        new FormBatalla(selector.MazoJugador, selector.MazoIA))
                    {
                        batalla.ShowDialog(this);
                    }
                }
            }
        }

        private void BtnReglas_Click(object sender, EventArgs e)
        {
            using (FormVentanaReglas reglas = new FormVentanaReglas())
            {
                reglas.ShowDialog(this);
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}