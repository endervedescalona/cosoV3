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

            mazo.Add(CrearPersonaje(
                "Hanzo", "Homura", "Fuego", "Guerrero",
                110, 35, 40, 50, 30, 5, "Corte Flameante"));

            mazo.Add(CrearPersonaje(
                "Seraphyn", "Homura", "Fuego", "Mago",
                85, 18, 20, 20, 90, 10, "Ráfaga de Incendio"));

            mazo.Add(CrearPersonaje(
                "Magnus", "Homura", "Fuego", "Tanque",
                180, 22, 65, 40, 35, 5, "Escudo Magmático"));

            mazo.Add(CrearPersonaje(
                "Fiona", "Mizushiro", "Agua", "Guerrero",
                115, 40, 35, 45, 35, 8, "Estocada Torrencial"));

            mazo.Add(CrearPersonaje(
                "Elara", "Mizushiro", "Agua", "Mago",
                90, 16, 15, 15, 100, 15, "Prisión Helada"));

            mazo.Add(CrearPersonaje(
                "Ranmaru", "Mizushiro", "Agua", "Tanque",
                200, 20, 60, 35, 35, 10, "Marea Defensiva"));

            mazo.Add(CrearPersonaje(
                "Vessel", "Kazekiri", "Aire", "Tanque",
                160, 25, 58, 50, 35, 8, "Barrera de Viento"));

            mazo.Add(CrearPersonaje(
                "Ibuki", "Kazekiri", "Aire", "Mago",
                120, 12, 22, 20, 80, 40, "Soplido Sanador"));

            mazo.Add(CrearPersonaje(
                "Leo", "Kazekiri", "Aire", "Guerrero",
                105, 30, 45, 60, 35, 5, "Tornados Cruzados"));

            mazo.Add(CrearPersonaje(
                "Cedrid", "Daichi", "Tierra", "Tanque",
                240, 18, 70, 30, 35, 12, "Fortaleza Terrenal"));

            mazo.Add(CrearPersonaje(
                "Tobias", "Daichi", "Tierra", "Mago",
                135, 14, 25, 15, 85, 48, "Raíz del Bosque"));

            mazo.Add(CrearPersonaje(
                "Tessho", "Daichi", "Tierra", "Guerrero",
                100, 42, 32, 40, 35, 6, "Impacto Sólido"));

            CargarUrls(mazo);

            return mazo;
        }


        private static Personaje CrearPersonaje(
            string nombre, string faccion, string elemento, string clase,
            int vida, int ataque, int defensa, int energia, int mana,
            int empatia, string habilidad)
        {
            switch (clase)
            {
                case "Guerrero":
                    return new Guerrero(nombre, faccion, elemento, clase, vida,
                        ataque, defensa, energia, mana, empatia, habilidad);
                case "Mago":
                    return new Mago(nombre, faccion, elemento, clase, vida,
                        ataque, defensa, energia, mana, empatia, habilidad);
                case "Tanque":
                    return new Tanque(nombre, faccion, elemento, clase, vida,
                        ataque, defensa, energia, mana, empatia, habilidad);
                default:
                    return new Personaje(nombre, faccion, elemento, clase, vida,
                        ataque, defensa, energia, mana, empatia, habilidad);
            }
        }

        public static Dictionary<string, string> ObtenerUrls()
        {
            Dictionary<string, string> urls = new Dictionary<string, string>();
            // Recursos públicos del paquete gráfico Chronos Arena (GitHub).
            urls["fondo:menu"] = "https://raw.githubusercontent.com/VedzabethCortez/ART_PACK/main/pictures/MAIN_MENU.jpg";
            urls["fondo:modo"] = "https://raw.githubusercontent.com/VedzabethCortez/ART_PACK/main/pictures/GAME_MODE.jpg";
            urls["reverso:carta"] = "https://raw.githubusercontent.com/VedzabethCortez/ART_PACK/main/pictures/CARDBACK.jpeg";
            urls["fondo:batalla"] = "https://raw.githubusercontent.com/VedzabethCortez/ART_PACK/main/pictures/ARENA.jpeg";
            urls["fondo:clan:Mizushiro"] = "https://raw.githubusercontent.com/VedzabethCortez/ART_PACK/main/pictures/NEOMIZU.jpeg";
            urls["fondo:clan:Kazekiri"] = "https://raw.githubusercontent.com/VedzabethCortez/ART_PACK/main/pictures/OLIMPUS.jpeg";
            urls["fondo:clan:Homura"] = "https://raw.githubusercontent.com/VedzabethCortez/ART_PACK/main/pictures/VELLIGNIS.jpeg";
            urls["fondo:clan:Daichi"] = "https://raw.githubusercontent.com/VedzabethCortez/ART_PACK/main/pictures/BRANCHES.jpeg";
            urls["personaje:Cedrid"] = "https://raw.githubusercontent.com/VedzabethCortez/ART_PACK/main/pictures/DAICHI_CEDRID.jpg.jpeg";
            urls["personaje:Tessho"] = "https://raw.githubusercontent.com/VedzabethCortez/ART_PACK/main/pictures/DAICHI_TESSHO.jpeg";
            urls["personaje:Tobias"] = "https://raw.githubusercontent.com/VedzabethCortez/ART_PACK/main/pictures/DAICHI_TOBIAS.jpeg";
            urls["personaje:Hanzo"] = "https://raw.githubusercontent.com/VedzabethCortez/ART_PACK/main/pictures/HOMURA_HANZO.jpeg";
            urls["personaje:Magnus"] = "https://raw.githubusercontent.com/VedzabethCortez/ART_PACK/main/pictures/HOMURA_MAGNUS.jpeg";
            urls["personaje:Seraphyn"] = "https://raw.githubusercontent.com/VedzabethCortez/ART_PACK/main/pictures/HOMURA_SERAPHYN.jpg.jpeg";
            urls["personaje:Ibuki"] = "https://raw.githubusercontent.com/VedzabethCortez/ART_PACK/main/pictures/KAZEKIRI_IBUKI.jpeg";
            urls["personaje:Leo"] = "https://raw.githubusercontent.com/VedzabethCortez/ART_PACK/main/pictures/KAZEKIRI_LEO.jpeg";
            urls["personaje:Vessel"] = "https://raw.githubusercontent.com/VedzabethCortez/ART_PACK/main/pictures/KAZEKIRI_VESSEL.jpeg";
            urls["personaje:Elara"] = "https://raw.githubusercontent.com/VedzabethCortez/ART_PACK/main/pictures/MIZUSHIRO_ELARA.jpeg";
            urls["personaje:Fiona"] = "https://raw.githubusercontent.com/VedzabethCortez/ART_PACK/main/pictures/MIZUSHIRO_FIONA.jpeg";
            urls["personaje:Ranmaru"] = "https://raw.githubusercontent.com/VedzabethCortez/ART_PACK/main/pictures/MIZUSHIRO_RANMARU.jpeg";

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