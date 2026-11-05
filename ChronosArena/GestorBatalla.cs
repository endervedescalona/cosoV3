using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ChronosArena
{
    public class GestorBatalla
    {
        private Random aleatorio = new Random();
        private List<string> historial = new List<string>();

        // Se conserva para la selección de cartas.
        // No se utiliza para determinar los ataques durante la batalla.
        public int LanzarDado()
        {
            return aleatorio.Next(1, 7);
        }

        public void Registrar(string texto)
        {
            historial.Add(
                DateTime.Now.ToString("HH:mm:ss") + " - " + texto);
        }

        public void GuardarHistorial(string ganador)
        {
            try
            {
                string[] contenido = new string[]
                {
                    "CHRONOS ARENA",
                    "Ganador: " + ganador,
                    ""
                };

                File.WriteAllLines(
                    "BitacoraBatalla.txt",
                    contenido.Concat(historial).ToArray());
            }
            catch (IOException)
            {
                // Si no se puede escribir el archivo,
                // la partida puede continuar.
            }
            catch (UnauthorizedAccessException)
            {
                // Evita interrumpir el combate por permisos.
            }
        }

        public string AtaqueBasico(
            Personaje atacante,
            Personaje defensor)
        {
            if (atacante == null || defensor == null)
            {
                return "No se pudo realizar el ataque.";
            }

            int dano = atacante.Atacar(defensor);

            string mensaje =
                atacante.Nombre + " ataca a " + defensor.Nombre +
                " e inflige " + dano + " de daño. Vida restante: " +
                defensor.Vida + ".";

            Registrar(mensaje);

            return mensaje;
        }
    }
}