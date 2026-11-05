using System;
using System.Windows.Forms;

namespace ChronosArena
{
    public partial class FormVentanaReglas : Form
    {
        public FormVentanaReglas()
        {
            InitializeComponent();

            txtReglas.Text =
                "REGLAS DE CHRONOS ARENA\r\n\r\n" +
                "1. Selección: cada equipo debe reunir cinco personajes distintos.\r\n\r\n" +
                "2. Dados: se utilizan durante la selección de cartas para determinar quién elige primero. No se utilizan durante el combate.\r\n\r\n" +
                "3. Selección: el jugador y la IA eligen cartas del catálogo. Una misma carta no puede pertenecer a ambos equipos.\r\n\r\n" +
                "4. Clases: los tanques destacan por su resistencia, los magos por sus habilidades y los guerreros por su ataque.\r\n\r\n" +
                "5. Combate: el jugador puede atacar, usar su habilidad especial, defenderse o curarse. La IA responde automáticamente.\r\n\r\n" +
                "6. Elementos: existen Fuego, Agua, Aire y Tierra. Algunas combinaciones otorgan ventaja elemental.\r\n\r\n" +
                "7. Victoria: gana el equipo que derrota a los cinco personajes del rival.\r\n\r\n" +
                "8. Imágenes: puedes configurar imágenes mediante direcciones URL públicas.";
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}