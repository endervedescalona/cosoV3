using System;
using System.Collections.Generic;
namespace ChronosArena
{
    public class CartaAmbiente
    {
        public string Nombre { get; set; }
        public string ImagenUrl { get; set; }
        public string Descripcion { get; set; }

        public CartaAmbiente(string nombre, string imagenUrl, string descripcion)
        {
            Nombre = nombre;
            ImagenUrl = imagenUrl;
            Descripcion = descripcion;
        }

        // Modifica el daño emitido según el ambiente y el clan del atacante
        public int CalcularDanoConAmbiente(int danoBase, string clanAtacante)
        {
            double multiplicador = 1.0;

            if (Nombre == "Tsunami")
            {
                if (clanAtacante == "Kazekiri") multiplicador -= 0.15; // -15% ATK
                else if (clanAtacante == "Daichi") multiplicador -= 0.08; // -8% ATK
                else if (clanAtacante == "Homura") multiplicador -= 0.04; // -4% ATK
            }
            else if (Nombre == "Huracán")
            {
                if (clanAtacante == "Kazekiri") multiplicador += 0.12; // +12% ATK
            }
            else if (Nombre == "Erupción Volcánica")
            {
                if (clanAtacante == "Homura") multiplicador += 0.15; // +15% ATK
                else if (clanAtacante == "Kazekiri") multiplicador += 0.08; // +8% ATK
            }
            else if (Nombre == "Deslave")
            {
                if (clanAtacante == "Homura") multiplicador -= 0.15; // -15% ATK
                else if (clanAtacante == "Mizushiro") multiplicador -= 0.07; // -7% ATK
                else if (clanAtacante == "Kazekiri") multiplicador -= 0.05; // -5% ATK
            }

            return Math.Max(1, (int)(danoBase * multiplicador));
        }

        // Obtiene la lista predefinida de los 4 ambientes del juego
        public static List<CartaAmbiente> ObtenerAmbientesPredefinidos()
        {
            return new List<CartaAmbiente>
            {
                new CartaAmbiente("Tsunami", "TSUNAMI.jpeg", "CLAN MIZUSHIRO: +15 HP y +10 DEF\nCLAN KAZEKIRI: -15% ATK y -10 DEF\nCLAN DAICHI: +7 HP, +5 DEF, -8% ATK\nCLAN HOMURA: -4% ATK y -3 DEF"),
                new CartaAmbiente("Huracán", "HURACAN.jpeg", "CLAN KAZEKIRI: +12% ATK y +5 DEF\nCLAN DAICHI: -15% DEF y -10 HP\nCLAN MIZUSHIRO: -4% DEF y -3 HP"),
                new CartaAmbiente("Erupción Volcánica", "ERUPCION_VOLCANICA.jpeg", "CLAN HOMURA: +15% ATK y +5 DEF\nCLAN MIZUSHIRO: -15% HP y -10 DEF\nCLAN KAZEKIRI: +8% ATK, +4 DEF, -8% HP\nCLAN DAICHI: -5% HP y -3 DEF"),
                new CartaAmbiente("Deslave", "DESLAVE.jpeg", "CLAN DAICHI: +20 DEF y +10 HP\nCLAN HOMURA: -15% ATK y -10 DEF\nCLAN MIZUSHIRO: +10 DEF, +5 HP, -7% ATK\nCLAN KAZEKIRI: -5% ATK y -3 DEF")
            };
        }
    }
}