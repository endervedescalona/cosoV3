using System;
using System.Collections.Generic;
using System.Linq;

namespace ChronosArena
{
    /// <summary>
    /// Núcleo de reglas de Chronos Arena. Mantiene la lógica del combate
    /// separada de los formularios de Windows Forms.
    /// </summary>
    public class NucleoBatalla
    {
        public int DuracionTurnoSegundos { get; private set; }

        public NucleoBatalla()
        {
            DuracionTurnoSegundos = 30;
        }

        public int EjecutarAtaque(Personaje atacante, Personaje objetivo)
        {
            ValidarPersonajes(atacante, objetivo);
            if (!PuedeUsarEnergia(atacante, 10))
                return 0;

            return atacante.Atacar(objetivo);
        }

        public string EjecutarHabilidad(Personaje usuario, Personaje objetivo)
        {
            if (usuario == null) throw new ArgumentNullException("usuario");
            if (usuario.Mana < 20)
                return usuario.Nombre + " no tiene suficiente maná (necesita 20).";
            return usuario.UsarHabilidad(objetivo);
        }

        public void EjecutarDefensa(Personaje personaje)
        {
            if (personaje == null) throw new ArgumentNullException("personaje");
            personaje.Defender();
        }

        public int EjecutarCuracion(Personaje personaje)
        {
            if (personaje == null) throw new ArgumentNullException("personaje");
            int vidaAnterior = personaje.Vida;
            personaje.Curar();
            return personaje.Vida - vidaAnterior;
        }

        public bool PuedeUsarEnergia(Personaje personaje, int coste)
        {
            return personaje != null && coste >= 0 && personaje.Energia >= coste;
        }

        public bool PuedeUsarMana(Personaje personaje, int coste)
        {
            return personaje != null && coste >= 0 && personaje.Mana >= coste;
        }

        public bool EstaDerrotado(Personaje personaje)
        {
            return personaje == null || personaje.Vida <= 0;
        }

        public string ObtenerGanador(IList<Personaje> equipoJugador, IList<Personaje> equipoIA)
        {
            bool jugadorDerrotado = equipoJugador == null || equipoJugador.All(p => p == null || p.Vida <= 0);
            bool iaDerrotada = equipoIA == null || equipoIA.All(p => p == null || p.Vida <= 0);
            if (jugadorDerrotado && iaDerrotada) return "Empate";
            if (jugadorDerrotado) return "IA";
            if (iaDerrotada) return "Jugador";
            return String.Empty;
        }

        private static void ValidarPersonajes(Personaje atacante, Personaje objetivo)
        {
            if (atacante == null) throw new ArgumentNullException("atacante");
            if (objetivo == null) throw new ArgumentNullException("objetivo");
            if (atacante.Vida <= 0) throw new InvalidOperationException("El atacante está derrotado.");
            if (objetivo.Vida <= 0) throw new InvalidOperationException("El objetivo ya está derrotado.");
        }
    }
}
