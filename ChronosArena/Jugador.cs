using System.Collections.Generic;

namespace ChronosArena
{
    public class Jugador
    {
        public string Nombre { get; set; }

        public List<Personaje> MazoSeleccionado { get; set; }

        public Personaje CartaActiva { get; set; }

        public Jugador(string nombre)
        {
            Nombre = nombre;
            MazoSeleccionado = new List<Personaje>();
        }

        public bool AgregarCartaAlMazo(Personaje carta)
        {
            if (carta == null || MazoSeleccionado.Count >= 5)
                return false;

            MazoSeleccionado.Add(carta);
            return true;
        }
    }
}