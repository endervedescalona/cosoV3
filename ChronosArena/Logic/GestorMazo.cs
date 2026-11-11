using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace ChronosArena
{
    public static class GestorMazo
    {
        private static string CarpetaDatos
        {
            get { return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data"); }
        }

        private static string ArchivoPersonajes
        {
            get { return Path.Combine(CarpetaDatos, "PersonajesChronos.txt"); }
        }

        private static string ArchivoImagenes
        {
            get { return Path.Combine(CarpetaDatos, "imagenes_chronos.txt"); }
        }

        public static List<Personaje> ObtenerMazoCompleto()
        {
            List<Personaje> mazo = CargarMazoDesdeArchivo();

            if (mazo.Count == 0)
            {
                mazo = CrearMazoPredeterminado();
                try { GuardarMazoCompleto(mazo); }
                catch (Exception) { /* El catálogo integrado sirve como respaldo. */ }
            }

            CargarUrls(mazo);
            return mazo;
        }

        private static List<Personaje> CrearMazoPredeterminado()
        {
            List<Personaje> mazo = new List<Personaje>();
            mazo.Add(CrearPersonaje("Hanzo", "Homura", "Fuego", "Guerrero", 110, 35, 40, 50, 30, 5, "Corte Flameante"));
            mazo.Add(CrearPersonaje("Seraphyn", "Homura", "Fuego", "Mago", 85, 18, 20, 20, 90, 10, "Ráfaga de Incendio"));
            mazo.Add(CrearPersonaje("Magnus", "Homura", "Fuego", "Tanque", 180, 22, 65, 40, 35, 5, "Escudo Magmático"));
            mazo.Add(CrearPersonaje("Fiona", "Mizushiro", "Agua", "Guerrero", 115, 40, 35, 45, 35, 8, "Estocada Torrencial"));
            mazo.Add(CrearPersonaje("Elara", "Mizushiro", "Agua", "Mago", 90, 16, 15, 15, 100, 15, "Prisión Helada"));
            mazo.Add(CrearPersonaje("Ranmaru", "Mizushiro", "Agua", "Tanque", 200, 20, 60, 35, 35, 10, "Marea Defensiva"));
            mazo.Add(CrearPersonaje("Vessel", "Kazekiri", "Aire", "Tanque", 160, 25, 58, 50, 35, 8, "Barrera de Viento"));
            mazo.Add(CrearPersonaje("Ibuki", "Kazekiri", "Aire", "Mago", 120, 12, 22, 20, 80, 40, "Soplido Sanador"));
            mazo.Add(CrearPersonaje("Leo", "Kazekiri", "Aire", "Guerrero", 105, 30, 45, 60, 35, 5, "Tornados Cruzados"));
            mazo.Add(CrearPersonaje("Cedrid", "Daichi", "Tierra", "Tanque", 240, 18, 70, 30, 35, 12, "Fortaleza Terrenal"));
            mazo.Add(CrearPersonaje("Tobias", "Daichi", "Tierra", "Mago", 135, 14, 25, 15, 85, 48, "Raíz del Bosque"));
            mazo.Add(CrearPersonaje("Tessho", "Daichi", "Tierra", "Guerrero", 100, 42, 32, 40, 35, 6, "Impacto Sólido"));
            return mazo;
        }

        private static List<Personaje> CargarMazoDesdeArchivo()
        {
            List<Personaje> mazo = new List<Personaje>();

            try
            {
                if (!File.Exists(ArchivoPersonajes))
                    return mazo;

                string[] lineas = File.ReadAllLines(ArchivoPersonajes, Encoding.UTF8);
                foreach (string linea in lineas)
                {
                    if (String.IsNullOrWhiteSpace(linea) || linea.TrimStart().StartsWith("#"))
                        continue;

                    string[] dato = linea.Split('|');
                    if (dato.Length != 11)
                        continue;

                    int vida, ataque, defensa, energia, mana, empatia;
                    if (!Int32.TryParse(dato[4], NumberStyles.Integer, CultureInfo.InvariantCulture, out vida) ||
                        !Int32.TryParse(dato[5], NumberStyles.Integer, CultureInfo.InvariantCulture, out ataque) ||
                        !Int32.TryParse(dato[6], NumberStyles.Integer, CultureInfo.InvariantCulture, out defensa) ||
                        !Int32.TryParse(dato[7], NumberStyles.Integer, CultureInfo.InvariantCulture, out energia) ||
                        !Int32.TryParse(dato[8], NumberStyles.Integer, CultureInfo.InvariantCulture, out mana) ||
                        !Int32.TryParse(dato[9], NumberStyles.Integer, CultureInfo.InvariantCulture, out empatia))
                        continue;

                    mazo.Add(CrearPersonaje(dato[0], dato[1], dato[2], dato[3],
                        vida, ataque, defensa, energia, mana, empatia, dato[10]));
                }
            }
            catch (IOException) { }
            catch (UnauthorizedAccessException) { }

            return mazo;
        }

        /// <summary>Escribe el catálogo en formato delimitado por |.</summary>
        public static void GuardarMazoCompleto(IList<Personaje> personajes)
        {
            if (personajes == null)
                throw new ArgumentNullException("personajes");

            Directory.CreateDirectory(CarpetaDatos);
            List<string> lineas = new List<string>();
            lineas.Add("# Nombre|Faccion|Elemento|Clase|Vida|Ataque|Defensa|Energia|Mana|Empatia|Habilidad");

            foreach (Personaje p in personajes)
            {
                if (p == null)
                    continue;

                string[] campos = new string[]
                {
                    LimpiarCampo(p.Nombre), LimpiarCampo(p.Faccion),
                    LimpiarCampo(p.Elemento), LimpiarCampo(p.Clase),
                    p.VidaMax.ToString(CultureInfo.InvariantCulture),
                    p.Ataque.ToString(CultureInfo.InvariantCulture),
                    p.Defensa.ToString(CultureInfo.InvariantCulture),
                    p.Energia.ToString(CultureInfo.InvariantCulture),
                    p.Mana.ToString(CultureInfo.InvariantCulture),
                    p.Empatia.ToString(CultureInfo.InvariantCulture),
                    LimpiarCampo(p.HabilidadEspecial)
                };
                lineas.Add(String.Join("|", campos));
            }

            File.WriteAllLines(ArchivoPersonajes, lineas.ToArray(), Encoding.UTF8);
        }

        private static string LimpiarCampo(string valor)
        {
            return (valor != null ? valor : String.Empty).Replace("|", "/").Replace("\r", " ").Replace("\n", " ").Trim();
        }

        private static Personaje CrearPersonaje(
            string nombre, string faccion, string elemento, string clase,
            int vida, int ataque, int defensa, int energia, int mana,
            int empatia, string habilidad)
        {
            switch (clase)
            {
                case "Guerrero":
                    return new Guerrero(nombre, faccion, elemento, clase, vida, ataque, defensa, energia, mana, empatia, habilidad);
                case "Mago":
                    return new Mago(nombre, faccion, elemento, clase, vida, ataque, defensa, energia, mana, empatia, habilidad);
                case "Tanque":
                    return new Tanque(nombre, faccion, elemento, clase, vida, ataque, defensa, energia, mana, empatia, habilidad);
                case "Healer":
                    return new Healer(nombre, faccion, elemento, clase, vida, ataque, defensa, energia, mana, empatia, habilidad);
                default:
                    return new PersonajeComun(nombre, faccion, elemento, clase, vida, ataque, defensa, energia, mana, empatia, habilidad);
            }
        }

        // Los equipos se guardan fuera de bin/Debug para que no se pierdan
        // al recompilar o cambiar la carpeta desde la que se ejecuta el juego.
        private static string ArchivoEquiposGuardados
        {
            get
            {
                string carpeta = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "ChronosArena", "Data");
                return Path.Combine(carpeta, "EquiposGuardados.txt");
            }
        }

        // Ruta antigua utilizada por la primera versión de esta función.
        private static string ArchivoEquiposAnterior
        {
            get { return Path.Combine(CarpetaDatos, "EquiposGuardados.txt"); }
        }

        public static string ObtenerRutaEquiposGuardados()
        {
            return ArchivoEquiposGuardados;
        }

        public static Dictionary<string, List<string>> ObtenerEquiposGuardados()
        {
            Dictionary<string, List<string>> equipos =
                new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

            CargarEquiposDesdeArchivo(ArchivoEquiposGuardados, equipos);

            // Importa automáticamente los equipos que ya se hubieran guardado
            // con la versión anterior dentro de la carpeta Data del programa.
            if (equipos.Count == 0 && File.Exists(ArchivoEquiposAnterior))
                CargarEquiposDesdeArchivo(ArchivoEquiposAnterior, equipos);

            return equipos;
        }

        private static void CargarEquiposDesdeArchivo(
            string archivo, Dictionary<string, List<string>> equipos)
        {
            try
            {
                if (!File.Exists(archivo)) return;

                foreach (string linea in File.ReadAllLines(archivo, Encoding.UTF8))
                {
                    if (String.IsNullOrWhiteSpace(linea) ||
                        linea.TrimStart().StartsWith("#")) continue;

                    string[] partes = linea.Split('|');
                    if (partes.Length != 2) continue;

                    string nombre = partes[0].Trim();
                    List<string> cartas = new List<string>();

                    foreach (string carta in partes[1].Split(';'))
                        if (!String.IsNullOrWhiteSpace(carta))
                            cartas.Add(carta.Trim());

                    if (nombre.Length > 0 && cartas.Count == 5)
                        equipos[nombre] = cartas;
                }
            }
            catch (IOException ex)
            {
                throw new IOException("No se pudo leer el archivo de equipos: " + archivo, ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new UnauthorizedAccessException(
                    "No hay permiso para leer el archivo de equipos: " + archivo, ex);
            }
        }

        public static void GuardarEquipo(string nombreJugador, IList<Personaje> equipo)
        {
            if (String.IsNullOrWhiteSpace(nombreJugador))
                throw new ArgumentException("Escribe el nombre del jugador.", "nombreJugador");

            if (equipo == null || equipo.Count != 5)
                throw new ArgumentException(
                    "El equipo debe tener exactamente cinco personajes.", "equipo");

            Dictionary<string, List<string>> equipos = ObtenerEquiposGuardados();
            List<string> nombres = new List<string>();

            foreach (Personaje personaje in equipo)
            {
                if (personaje == null)
                    throw new ArgumentException("El equipo contiene una carta vacía.");

                string nombreCarta = LimpiarCampo(personaje.Nombre);
                if (String.IsNullOrWhiteSpace(nombreCarta))
                    throw new ArgumentException("Una de las cartas no tiene nombre.");

                nombres.Add(nombreCarta);
            }

            equipos[nombreJugador.Trim()] = nombres;

            string carpeta = Path.GetDirectoryName(ArchivoEquiposGuardados);
            Directory.CreateDirectory(carpeta);

            List<string> lineas = new List<string>();
            lineas.Add("# Jugador|Cinco personajes separados por ;");

            foreach (KeyValuePair<string, List<string>> par in equipos)
                lineas.Add(LimpiarCampo(par.Key) + "|" +
                    String.Join(";", par.Value.ToArray()));

            // Escritura temporal para evitar dejar el archivo vacío si se
            // interrumpe la escritura.
            string temporal = ArchivoEquiposGuardados + ".tmp";
            File.WriteAllLines(temporal, lineas.ToArray(), Encoding.UTF8);

            if (File.Exists(ArchivoEquiposGuardados))
                File.Delete(ArchivoEquiposGuardados);

            File.Move(temporal, ArchivoEquiposGuardados);
        }

        public static Dictionary<string, string> ObtenerUrls()
        {
            Dictionary<string, string> urls = new Dictionary<string, string>();
            urls["fondo:menu"] = "MAIN_MENU.jpg";
            urls["fondo:modo"] = "GAME_MODE.jpg";
            urls["reverso:carta"] = "CARDBACK.jpeg";
            urls["fondo:batalla"] = "ARENA.jpeg";
            urls["fondo:clan:Mizushiro"] = "NEOMIZU.jpeg";
            urls["fondo:clan:Kazekiri"] = "OLIMPUS.jpeg";
            urls["fondo:clan:Homura"] = "VELLIGNIS.jpeg";
            urls["fondo:clan:Daichi"] = "BRANCHES.jpeg";
            urls["personaje:Cedrid"] = "DAICHI_CEDRID.jpg";
            urls["personaje:Tessho"] = "DAICHI_TESSHO.jpg";
            urls["personaje:Tobias"] = "DAICHI_TOBIAS.jpg";
            urls["personaje:Hanzo"] = "HOMURA_HANZO.jpg";
            urls["personaje:Magnus"] = "HOMURA_MAGNUS.jpg";
            urls["personaje:Seraphyn"] = "HOMURA_SERAPHYN.jpg";
            urls["personaje:Ibuki"] = "KAZEKIRI_IBUKI.jpg";
            urls["personaje:Leo"] = "KAZEKIRI_LEO.jpg";
            urls["personaje:Vessel"] = "KAZEKIRI_VESSEL.jpg";
            urls["personaje:Elara"] = "MIZUSHIRO_ELARA.jpg";
            urls["personaje:Fiona"] = "MIZUSHIRO_FIONA.jpg";
            urls["personaje:Ranmaru"] = "MIZUSHIRO_RANMARU.jpg";

            try
            {
                if (File.Exists(ArchivoImagenes))
                {
                    foreach (string linea in File.ReadAllLines(ArchivoImagenes, Encoding.UTF8))
                    {
                        int separador = linea.IndexOf('|');
                        if (separador > 0)
                        {
                            string clave = linea.Substring(0, separador).Trim();
                            string valor = linea.Substring(separador + 1).Trim();
                            urls[clave] = valor;
                        }
                    }
                }
            }
            catch (IOException) { }
            catch (UnauthorizedAccessException) { }

            return urls;
        }

        public static void GuardarUrls(Dictionary<string, string> urls)
        {
            if (urls == null)
                throw new ArgumentNullException("urls");

            Directory.CreateDirectory(CarpetaDatos);
            List<string> lineas = new List<string>();
            foreach (KeyValuePair<string, string> par in urls)
            {
                string valor = (par.Value != null ? par.Value : String.Empty).Replace("\r", "").Replace("\n", "");
                lineas.Add(par.Key + "|" + valor);
            }

            File.WriteAllLines(ArchivoImagenes, lineas.ToArray(), Encoding.UTF8);
        }

        private static void CargarUrls(List<Personaje> mazo)
        {
            Dictionary<string, string> urls = ObtenerUrls();
            foreach (Personaje p in mazo)
            {
                string clave = "personaje:" + p.Nombre;
                string url;
                if (urls.TryGetValue(clave, out url))
                    p.EstablecerImagenUrl(url);
            }
        }
    }
}
