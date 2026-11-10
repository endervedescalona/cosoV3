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

        public string UltimoError { get; private set; }

        // true cuando la partida es Jugador 1 vs Jugador 2 (solo cambia los rótulos del TXT).
        public bool ModoPvP { get; set; }

        public static string ObtenerRutaHistorial()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BitacoraBatalla.txt");
        }

        public int LanzarDado()
        {
            return aleatorio.Next(1, 7);
        }

        public void Registrar(string texto)
        {
            if (String.IsNullOrWhiteSpace(texto))
                return;

            historial.Add(DateTime.Now.ToString("HH:mm:ss") + " - " + texto.Trim());
        }

        public bool GuardarHistorial(
            string ganador,
            IList<Personaje> equipoJugador,
            IList<Personaje> equipoIA)
        {
            try
            {
                StringBuilder contenido = new StringBuilder();
                contenido.AppendLine("==================================================");
                contenido.AppendLine("CHRONOS ARENA - REGISTRO DE PARTIDA");
                contenido.AppendLine("==================================================");
                contenido.AppendLine("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                contenido.AppendLine("Ganador: " + (ganador != null ? ganador : "Sin determinar"));
                contenido.AppendLine();
                contenido.AppendLine(ModoPvP ? "EQUIPO DEL JUGADOR 1:" : "EQUIPO DEL JUGADOR:");
                AgregarEquipo(contenido, equipoJugador);
                contenido.AppendLine();
                contenido.AppendLine(ModoPvP ? "EQUIPO DEL JUGADOR 2:" : "EQUIPO DE LA IA:");
                AgregarEquipo(contenido, equipoIA);
                contenido.AppendLine();
                contenido.AppendLine("ACCIONES DE LA PARTIDA:");

                if (historial.Count == 0)
                    contenido.AppendLine("No se registraron acciones.");
                else
                {
                    foreach (string evento in historial)
                        contenido.AppendLine(evento);
                }

                contenido.AppendLine();
                File.AppendAllText(ObtenerRutaHistorial(), contenido.ToString(), Encoding.UTF8);
                historial.Clear();
                UltimoError = String.Empty;
                return true;
            }
            catch (Exception ex)
            {
                UltimoError = ex.Message;
                return false;
            }
        }

        public void GuardarHistorial(string ganador)
        {
            GuardarHistorial(ganador, null, null);
        }

        private static void AgregarEquipo(StringBuilder contenido, IList<Personaje> equipo)
        {
            if (equipo == null || equipo.Count == 0)
            {
                contenido.AppendLine("- Sin datos");
                return;
            }

            for (int i = 0; i < equipo.Count; i++)
            {
                Personaje personaje = equipo[i];
                if (personaje != null)
                {
                    contenido.AppendLine("- " + personaje.Nombre +
                        " | Clase: " + personaje.Clase +
                        " | Vida final: " + personaje.Vida + "/" + personaje.VidaMax);
                }
            }
        }

        public string AtaqueBasico(Personaje atacante, Personaje defensor)
        {
            if (atacante == null || defensor == null)
                return "No se pudo realizar el ataque.";

            if (!nucleo.PuedeUsarEnergia(atacante, 10))
                return atacante.Nombre + " no tiene suficiente energía para atacar.";

            int dano = nucleo.EjecutarAtaque(atacante, defensor);
            string mensaje = atacante.Nombre + " ataca a " + defensor.Nombre +
                " e inflige " + dano + " de daño. Vida restante: " + defensor.Vida + ".";
            Registrar(mensaje);
            return mensaje;
        }
    }
}
