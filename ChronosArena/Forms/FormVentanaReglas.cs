using System;
using System.Windows.Forms;

namespace ChronosArena
{
    public partial class FormVentanaReglas : Form
    {
        public FormVentanaReglas()
        {
            InitializeComponent();
            PantallaCompleta.Instalar(this);
            EscaladorInterfaz.Instalar(this);
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
