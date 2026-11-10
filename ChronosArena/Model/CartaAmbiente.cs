using System;
using System.Collections.Generic;

namespace ChronosArena
{
    public class EfectosAmbiente
    {
        public int BonusVida { get; set; }
        public int BonusDefensa { get; set; }
        public int PorcentajeAtaque { get; set; }

        public EfectosAmbiente(int vida, int defensa, int ataque)
        {
            BonusVida = vida;
            BonusDefensa = defensa;
            PorcentajeAtaque = ataque;
        }
    }

    /// <summary>Una de las cuatro condiciones ambientales que modifican el combate.</summary>
    public class CartaAmbiente
    {
        public string Nombre { get; set; }
        public string ImagenUrl { get; set; }
        public string Descripcion { get; set; }
        public string Clave { get; private set; }

        public CartaAmbiente(string nombre, string imagenUrl, string descripcion)
        {
            Nombre = nombre != null ? nombre : String.Empty;
            ImagenUrl = imagenUrl != null ? imagenUrl : String.Empty;
            Descripcion = descripcion != null ? descripcion : String.Empty;
            Clave = Normalizar(nombre);
        }

        public string Resumen
        {
            get
            {
                if (Clave == "TSUNAMI") return "Las corrientes favorecen a Mizushiro y debilitan algunos ataques.";
                if (Clave == "HURACAN") return "Los vientos impulsan a Kazekiri y afectan la defensa rival.";
                if (Clave == "ERUPCIONVOLCANICA") return "El calor potencia a Homura y cambia el equilibrio del combate.";
                return "El terreno rocoso fortalece a Daichi y reduce algunos ataques.";
            }
        }

        public EfectosAmbiente ObtenerEfectos(string faccion)
        {
            string clan = Normalizar(faccion);
            if (Clave == "TSUNAMI")
            {
                if (clan == "MIZUSHIRO") return new EfectosAmbiente(15, 10, 0);
                if (clan == "KAZEKIRI") return new EfectosAmbiente(0, -10, -15);
                if (clan == "DAICHI") return new EfectosAmbiente(7, 5, -8);
                if (clan == "HOMURA") return new EfectosAmbiente(0, -3, -4);
            }
            else if (Clave == "HURACAN")
            {
                if (clan == "KAZEKIRI") return new EfectosAmbiente(0, 5, 12);
                if (clan == "DAICHI") return new EfectosAmbiente(-10, -15, 0);
                if (clan == "MIZUSHIRO") return new EfectosAmbiente(-3, -4, 0);
            }
            else if (Clave == "ERUPCIONVOLCANICA")
            {
                if (clan == "HOMURA") return new EfectosAmbiente(0, 5, 15);
                if (clan == "MIZUSHIRO") return new EfectosAmbiente(-15, -10, 0);
                if (clan == "KAZEKIRI") return new EfectosAmbiente(-8, 4, 8);
                if (clan == "DAICHI") return new EfectosAmbiente(-5, -3, 0);
            }
            else if (Clave == "DESLAVE")
            {
                if (clan == "DAICHI") return new EfectosAmbiente(10, 20, 0);
                if (clan == "HOMURA") return new EfectosAmbiente(0, -10, -15);
                if (clan == "MIZUSHIRO") return new EfectosAmbiente(5, 10, -7);
                if (clan == "KAZEKIRI") return new EfectosAmbiente(0, -3, -5);
            }
            return new EfectosAmbiente(0, 0, 0);
        }

        public void AplicarEfectosPasivos(Personaje personaje)
        {
            if (personaje == null) return;
            EfectosAmbiente efectos = ObtenerEfectos(personaje.Faccion);
            personaje.AplicarModificadoresAmbiente(efectos.BonusVida, efectos.BonusDefensa);
            personaje.AmbienteActivo = this;
        }

        public int CalcularDanoConAmbiente(int danoBase, string clanAtacante)
        {
            // La tabla de daño sigue el switch solicitado en el TXT. Se normaliza
            // el clan para que no dependa de mayúsculas, tildes o espacios.
            string clan = Normalizar(clanAtacante);
            double multiplicador = 1.0;

            switch (Clave)
            {
                case "TSUNAMI":
                    if (clan == "KAZEKIRI") multiplicador -= 0.15;
                    else if (clan == "DAICHI") multiplicador -= 0.08;
                    else if (clan == "HOMURA") multiplicador -= 0.04;
                    break;

                case "HURACAN":
                    if (clan == "KAZEKIRI") multiplicador += 0.12;
                    break;

                case "ERUPCIONVOLCANICA":
                    if (clan == "HOMURA") multiplicador += 0.15;
                    else if (clan == "KAZEKIRI") multiplicador += 0.08;
                    break;

                case "DESLAVE":
                    if (clan == "HOMURA") multiplicador -= 0.15;
                    else if (clan == "MIZUSHIRO") multiplicador -= 0.07;
                    else if (clan == "KAZEKIRI") multiplicador -= 0.05;
                    break;
            }

            return Math.Max(1, (int)Math.Round(danoBase * multiplicador, MidpointRounding.AwayFromZero));
        }

        public int CalcularAtaqueConAmbiente(int ataqueBase, string clanAtacante)
        {
            EfectosAmbiente efectos = ObtenerEfectos(clanAtacante);
            return Math.Max(0, (int)Math.Round(ataqueBase * (1.0 + efectos.PorcentajeAtaque / 100.0), MidpointRounding.AwayFromZero));
        }

        public static string Normalizar(string valor)
        {
            string s = (valor != null ? valor : String.Empty).Trim().ToUpperInvariant();
            s = s.Replace("Á", "A").Replace("É", "E").Replace("Í", "I").Replace("Ó", "O").Replace("Ú", "U");
            return s.Replace(" ", String.Empty).Replace("_", String.Empty);
        }

        public static CartaAmbiente ObtenerPorNombre(string nombre)
        {
            string clave = Normalizar(nombre);
            foreach (CartaAmbiente carta in ObtenerAmbientesPredefinidos())
                if (carta.Clave == clave) return carta;
            return null;
        }

        public static List<CartaAmbiente> ObtenerAmbientesPredefinidos()
        {
            return new List<CartaAmbiente>
            {
                new CartaAmbiente("Tsunami", "TSUNAMI.jpg", "CLAN MIZUSHIRO: +15 HP, +10 DEF\r\nCLAN KAZEKIRI: -15% ATK, -10 DEF\r\nCLAN DAICHI: +7 HP, +5 DEF, -8% ATK\r\nCLAN HOMURA: -4% ATK, -3 DEF"),
                new CartaAmbiente("Huracán", "HURACAN.jpg", "CLAN KAZEKIRI: +12% ATK, +5 DEF\r\nCLAN DAICHI: -15% DEF, -10 HP\r\nCLAN MIZUSHIRO: -4% DEF, -3 HP"),
                new CartaAmbiente("Erupción Volcánica", "ERUPCIONjpg.jpg", "CLAN HOMURA: +15% ATK, +5 DEF\r\nCLAN MIZUSHIRO: -15% HP, -10 DEF\r\nCLAN KAZEKIRI: +8% ATK, +4 DEF, -8% HP\r\nCLAN DAICHI: -5% HP, -3 DEF"),
                new CartaAmbiente("Deslave", "DESLAVE.jpg", "CLAN DAICHI: +20 DEF, +10 HP\r\nCLAN HOMURA: -15% ATK, -10 DEF\r\nCLAN MIZUSHIRO: +10 DEF, +5 HP, -7% ATK\r\nCLAN KAZEKIRI: -5% ATK, -3 DEF")
            };
        }
    }
}
