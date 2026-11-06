using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ChronosArena
{
   
    internal sealed class PantallaCompleta
    {
        private readonly Form formulario;
        private bool activa;
        private Rectangle limitesOriginales;
        private FormBorderStyle bordeOriginal;
        private FormWindowState estadoOriginal;
        private Size tamanoMinimoOriginal;

        private PantallaCompleta(Form form)
        {
            formulario = form;
            formulario.KeyPreview = true;
            formulario.KeyDown += Formulario_KeyDown;
            formulario.FormClosed += Formulario_FormClosed;
        }

        public static void Instalar(Form form)
        {
            if (form == null)
                return;

            if (System.ComponentModel.LicenseManager.UsageMode ==
                System.ComponentModel.LicenseUsageMode.Designtime)
                return;

            new PantallaCompleta(form);
        }

        private void Formulario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11 ||
                (e.Alt && e.KeyCode == Keys.Enter))
            {
                Alternar();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Escape && activa)
            {
                Restaurar();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void Alternar()
        {
            if (activa)
            {
                Restaurar();
                return;
            }

            limitesOriginales = formulario.Bounds;
            bordeOriginal = formulario.FormBorderStyle;
            estadoOriginal = formulario.WindowState;
            tamanoMinimoOriginal = formulario.MinimumSize;

            formulario.WindowState = FormWindowState.Normal;
            formulario.MinimumSize = Size.Empty;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Bounds = Screen.FromControl(formulario).Bounds;
            activa = true;
        }

        private void Restaurar()
        {
            if (!activa)
                return;

            formulario.WindowState = FormWindowState.Normal;
            formulario.FormBorderStyle = bordeOriginal;
            formulario.MinimumSize = tamanoMinimoOriginal;
            formulario.Bounds = limitesOriginales;
            formulario.WindowState = estadoOriginal;
            activa = false;
        }

        private void Formulario_FormClosed(object sender, FormClosedEventArgs e)
        {
            formulario.KeyDown -= Formulario_KeyDown;
            formulario.FormClosed -= Formulario_FormClosed;
        }
    }

   
    internal sealed class EscaladorInterfaz
    {
        private readonly Form formulario;
        private readonly Dictionary<Control, Rectangle> posiciones =
            new Dictionary<Control, Rectangle>();
        private readonly Dictionary<Control, float> tamanosFuente =
            new Dictionary<Control, float>();

        private Size tamanoBase;
        private float escalaX = 1F;
        private float escalaY = 1F;
        private float escalaFuente = 1F;
        private float desplazamientoX;
        private float desplazamientoY;
        private bool iniciado;
        private bool aplicando;

        private EscaladorInterfaz(Form form)
        {
            formulario = form;
            formulario.Load += Formulario_Load;
        }

        public static void Instalar(Form form)
        {
            if (form == null)
                return;

            if (System.ComponentModel.LicenseManager.UsageMode ==
                System.ComponentModel.LicenseUsageMode.Designtime)
                return;

            new EscaladorInterfaz(form);
        }

        private void Formulario_Load(object sender, EventArgs e)
        {
            if (iniciado)
                return;

            tamanoBase = formulario.ClientSize;
            RegistrarControles(formulario);
            formulario.Resize += Formulario_Resize;
            iniciado = true;
        }

        private void RegistrarControles(Control padre)
        {
            padre.ControlAdded += Control_ControlAdded;

            foreach (Control hijo in padre.Controls)
            {
                if (!posiciones.ContainsKey(hijo))
                {
                    posiciones.Add(hijo, hijo.Bounds);
                    tamanosFuente.Add(hijo, hijo.Font.Size);
                }

                RegistrarControles(hijo);
            }
        }

        private void Control_ControlAdded(object sender, ControlEventArgs e)
        {
            if (e.Control == null || posiciones.ContainsKey(e.Control))
                return;

            posiciones.Add(e.Control, e.Control.Bounds);
            tamanosFuente.Add(e.Control, e.Control.Font.Size);
            RegistrarControles(e.Control);

            if (iniciado && !aplicando)
                AplicarEscala();
        }

        private void Formulario_Resize(object sender, EventArgs e)
        {
            AplicarEscala();
        }

        private void AplicarEscala()
        {
            if (!iniciado || aplicando || tamanoBase.Width <= 0 ||
                tamanoBase.Height <= 0)
                return;

            if (formulario.ClientSize.Width <= 0 ||
                formulario.ClientSize.Height <= 0)
                return;

            float ajusteX = (float)formulario.ClientSize.Width / tamanoBase.Width;
            float ajusteY = (float)formulario.ClientSize.Height / tamanoBase.Height;

       
            escalaX = Math.Min(ajusteX, ajusteY);
            escalaY = escalaX;
            escalaFuente = escalaX;
            desplazamientoX = (formulario.ClientSize.Width -
                (tamanoBase.Width * escalaX)) / 2F;
            desplazamientoY = (formulario.ClientSize.Height -
                (tamanoBase.Height * escalaY)) / 2F;

            aplicando = true;
            formulario.SuspendLayout();

            try
            {
                foreach (Control control in formulario.Controls)
                    AplicarControl(control, false, true);
            }
            finally
            {
                formulario.ResumeLayout(true);
                aplicando = false;
            }
        }

        private void AplicarControl(Control control, bool dentroDeFlujo, bool esRaiz)
        {
            Rectangle original;
            float fuenteOriginal;

            if (!posiciones.TryGetValue(control, out original))
            {
                posiciones[control] = control.Bounds;
                tamanosFuente[control] = control.Font.Size;
                original = control.Bounds;
            }

            if (!tamanosFuente.TryGetValue(control, out fuenteOriginal))
            {
                fuenteOriginal = control.Font.Size;
                tamanosFuente[control] = fuenteOriginal;
            }

            if (control.Dock == DockStyle.None)
            {
                int x = dentroDeFlujo
                    ? control.Left
                    : (int)Math.Round(original.X * escalaX +
                        (esRaiz ? desplazamientoX : 0F));
                int y = dentroDeFlujo
                    ? control.Top
                    : (int)Math.Round(original.Y * escalaY +
                        (esRaiz ? desplazamientoY : 0F));
                int ancho = Math.Max(1, (int)Math.Round(original.Width * escalaX));
                int alto = Math.Max(1, (int)Math.Round(original.Height * escalaY));

                control.SetBounds(x, y, ancho, alto);
            }

            float nuevoTamano = Math.Max(6F,
                Math.Min(32F, fuenteOriginal * escalaFuente));

            if (Math.Abs(control.Font.Size - nuevoTamano) > 0.1F)
            {
                control.Font = new Font(
                    control.Font.FontFamily,
                    nuevoTamano,
                    control.Font.Style,
                    control.Font.Unit);
            }

            bool hijosEnFlujo = control is FlowLayoutPanel;

            foreach (Control hijo in control.Controls)
                AplicarControl(hijo, hijosEnFlujo, false);
        }
    }
}
