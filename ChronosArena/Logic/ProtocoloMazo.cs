using System;
using System.Collections.Generic;
using System.Linq;

namespace ChronosArena
{
    /// <summary>
    /// Empaqueta/desempaqueta el mazo para enviarlo por GestorRed.
    /// Formato del mensaje:   MAZO|Hanzo#Elara#Magnus#Fiona#Vessel
    /// Solo viajan los NOMBRES (en orden = orden de relevos); el receptor
    /// reconstruye cada carta desde SU catalogo (.txt), por eso las dos PCs
    /// deben tener el mismo PersonajesChronos.txt.
    /// </summary>
    public static class ProtocoloMazo
    {
        public const string TipoMensaje = "MAZO";
        private const char SeparadorNombres = '#';

        public static string Serializar(IList<Personaje> mazo)
        {
            return String.Join(SeparadorNombres.ToString(),
                mazo.Select(p => p.Nombre).ToArray());
        }

        public static bool TryDeserializar(
            string datos, out List<Personaje> mazo, out string error)
        {
            mazo = null;
            error = null;

            string[] nombres = (datos != null ? datos : String.Empty).Split(SeparadorNombres);

            if (nombres.Length != PartidaConfig.TamanoMazo)
            {
                error = "El mazo del rival no tiene " + PartidaConfig.TamanoMazo + " cartas.";
                return false;
            }

            if (nombres.Select(n => n.Trim().ToLowerInvariant()).Distinct().Count() != nombres.Length)
            {
                error = "El mazo del rival tiene cartas repetidas.";
                return false;
            }

            List<Personaje> catalogo = GestorMazo.ObtenerMazoCompleto();
            List<Personaje> resultado = new List<Personaje>();

            foreach (string nombre in nombres)
            {
                string buscado = nombre.Trim();
                Personaje carta = catalogo.FirstOrDefault(p =>
                    String.Equals(p.Nombre, buscado, StringComparison.OrdinalIgnoreCase));

                if (carta == null)
                {
                    error = "El rival eligio \"" + buscado + "\", que no existe en tu catalogo. " +
                            "Los dos equipos deben tener el mismo PersonajesChronos.txt.";
                    return false;
                }

                resultado.Add(carta.Clonar());
            }

            mazo = resultado;
            return true;
        }
    }
}
