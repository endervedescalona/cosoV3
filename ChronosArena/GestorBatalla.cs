
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ChronosArena
{
    public class GestorBatalla
    {
        private Random aleatorio = new Random();
        private NucleoBatalla nucleo = new NucleoBatalla();
        private List<string> historial = new List<string>();

        private string RutaRecord
        {
            get
            {
                return Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "BitacoraBatalla.txt");
            }
        }

        public int LanzarDado()
        {
            return aleatorio.Next(1, 7);
        }

        public void Registrar(string texto)
        {
            historial.Add(
                DateTime.Now.ToString("HH:mm:ss") +
                " - " + texto);
        }

        public void GuardarHistorial(
            string ganador,
            IList<Personaje> equipoJugador,
            IList<Personaje> equipoIA)
        {
            try
            {
                StringBuilder contenido =
                    new StringBuilder();

                contenido.AppendLine("==================================");
                contenido.AppendLine("         CHRONOS ARENA");
                contenido.AppendLine("==================================");
                contenido.AppendLine(
                    "Fecha: " +
                    DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));

                contenido.AppendLine(
                    "Ganador: " + ganador);

                contenido.AppendLine();
                contenido.AppendLine("EQUIPO DEL JUGADOR:");

                if (equipoJugador != null)
                {
                    for (int i = 0; i < equipoJugador.Count; i++)
                    {
                        if (equipoJugador[i] != null)
                        {
                            contenido.AppendLine(
                                "- " + equipoJugador[i].Nombre);
                        }
                    }
                }

                contenido.AppendLine();
                contenido.AppendLine("EQUIPO DE LA IA:");

                if (equipoIA != null)
                {
                    for (int i = 0; i < equipoIA.Count; i++)
                    {
                        if (equipoIA[i] != null)
                        {
                            contenido.AppendLine(
                                "- " + equipoIA[i].Nombre);
                        }
                    }
                }

                contenido.AppendLine();
                contenido.AppendLine();

                File.AppendAllText(
                    RutaRecord,
                    contenido.ToString(),
                    Encoding.UTF8);
            }
            catch (IOException)
            {
                // El combate no se interrumpe si falla el archivo.
            }
            catch (UnauthorizedAccessException)
            {
                // El combate continúa aunque no haya permisos.
            }
        }

        // Se conserva esta versión para no romper
        // posibles llamadas antiguas desde otras clases.
        public void GuardarHistorial(string ganador)
        {
            try
            {
                StringBuilder contenido =
                    new StringBuilder();

                contenido.AppendLine("==================================");
                contenido.AppendLine("         CHRONOS ARENA");
                contenido.AppendLine("==================================");
                contenido.AppendLine(
                    "Fecha: " +
                    DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));

                contenido.AppendLine(
                    "Ganador: " + ganador);

                contenido.AppendLine();
                contenido.AppendLine(
                    "No se proporcionaron los equipos de esta partida.");

                contenido.AppendLine();

                File.AppendAllText(
                    RutaRecord,
                    contenido.ToString(),
                    Encoding.UTF8);
            }
            catch (IOException)
            {
            }
            catch (UnauthorizedAccessException)
            {
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

            int dano =
                nucleo.EjecutarAtaque(atacante, defensor);

            string mensaje =
                atacante.Nombre + " ataca a " +
                defensor.Nombre + " e inflige " +
                dano + " de daño. Vida restante: " +
                defensor.Vida + ".";

            Registrar(mensaje);

            return mensaje;
        }
    }
}
