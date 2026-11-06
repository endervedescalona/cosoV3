using System.Collections.Generic;

namespace ChronosArena
{
    public class Jugador
    {
        public string Nombre { get; private set; }
        public List<Personaje> MazoSeleccionado { get; private set; }
        public Personaje CartaActiva { get; private set; }

        public Jugador(string nombre)
        {
            Nombre = nombre ?? "Jugador";
            MazoSeleccionado = new List<Personaje>();
        }

        public bool AgregarCartaAlMazo(Personaje carta)
        {
            if (carta == null || MazoSeleccionado.Count >= 5)
                return false;

            foreach (Personaje existente in MazoSeleccionado)
            {
                if (existente.Nombre == carta.Nombre)
                    return false;
            }

            MazoSeleccionado.Add(carta);
            if (CartaActiva == null)
                CartaActiva = carta;

            return true;
        }

        public void EstablecerCartaActiva(Personaje carta)
        {
            if (carta != null && MazoSeleccionado.Contains(carta) && carta.Vida > 0)
                CartaActiva = carta;
        }
    }
}
