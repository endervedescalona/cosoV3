using System;
using System.Collections.Generic;
using System.IO;

namespace ChronosArena
{
    public static class GestorMazo
    {
        private static string ArchivoImagenes
        {
            get
            {
                return Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "imagenes_chronos.txt");
            }
        }

        public static List<Personaje> ObtenerMazoCompleto()
        {
            List<Personaje> mazo = new List<Personaje>();

            mazo.Add(new Personaje(
                "Hanzo", "Homura", "Fuego", "Guerrero",
                110, 35, 40, 50, 30, 5, "Corte Flameante"));

            mazo.Add(new Personaje(
                "Seraphyn", "Homura", "Fuego", "Mago",
                85, 18, 20, 20, 90, 10, "Ráfaga de Incendio"));

            mazo.Add(new Personaje(
                "Magnus", "Homura", "Fuego", "Tanque",
                180, 22, 65, 40, 35, 5, "Escudo Magmático"));

            mazo.Add(new Personaje(
                "Fiona", "Mizushiro", "Agua", "Guerrero",
                115, 40, 35, 45, 35, 8, "Estocada Torrencial"));

            mazo.Add(new Personaje(
                "Elara", "Mizushiro", "Agua", "Mago",
                90, 16, 15, 15, 100, 15, "Prisión Helada"));

            mazo.Add(new Personaje(
                "Ranmaru", "Mizushiro", "Agua", "Tanque",
                200, 20, 60, 35, 35, 10, "Marea Defensiva"));

            mazo.Add(new Personaje(
                "Vessel", "Kazekiri", "Aire", "Tanque",
                160, 25, 58, 50, 35, 8, "Barrera de Viento"));

            mazo.Add(new Personaje(
                "Ibuki", "Kazekiri", "Aire", "Mago",
                120, 12, 22, 20, 80, 40, "Soplido Sanador"));

            mazo.Add(new Personaje(
                "Leo", "Kazekiri", "Aire", "Guerrero",
                105, 30, 45, 60, 35, 5, "Tornados Cruzados"));

            mazo.Add(new Personaje(
                "Cedrid", "Daichi", "Tierra", "Tanque",
                240, 18, 70, 30, 35, 12, "Fortaleza Terrenal"));

            mazo.Add(new Personaje(
                "Tobias", "Daichi", "Tierra", "Mago",
                135, 14, 25, 15, 85, 48, "Raíz del Bosque"));

            mazo.Add(new Personaje(
                "Tessho", "Daichi", "Tierra", "Guerrero",
                100, 42, 32, 40, 35, 6, "Impacto Sólido"));

            CargarUrls(mazo);

            return mazo;
        }

        public static Dictionary<string, string> ObtenerUrls()
        {
            Dictionary<string, string> urls =
                new Dictionary<string, string>();

            if (File.Exists(ArchivoImagenes))
            {
                foreach (string linea in File.ReadAllLines(ArchivoImagenes))
                {
                    int separador = linea.IndexOf('|');

                    if (separador > 0)
                    {
                        string clave = linea.Substring(0, separador);
                        string valor = linea.Substring(separador + 1);

                        urls[clave] = valor;
                    }
                }
            }

            return urls;
        }

        public static void GuardarUrls(
            Dictionary<string, string> urls)
        {
            List<string> lineas = new List<string>();

            foreach (KeyValuePair<string, string> par in urls)
            {
                string valor = par.Value ?? String.Empty;

                valor = valor.Replace("\r", "").Replace("\n", "");

                lineas.Add(par.Key + "|" + valor);
            }

            File.WriteAllLines(ArchivoImagenes, lineas.ToArray());
        }

        private static void CargarUrls(List<Personaje> mazo)
        {
            Dictionary<string, string> urls = ObtenerUrls();

            foreach (Personaje p in mazo)
            {
                string clave = "personaje:" + p.Nombre;

                if (urls.ContainsKey(clave))
                {
                    p.ImagenUrl = urls[clave];
                }
            }
        }
    }
}