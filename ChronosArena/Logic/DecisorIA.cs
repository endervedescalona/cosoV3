using System;

namespace ChronosArena
{
    public enum AccionIA { Atacar, Especial, Curar, Defender, Relevar }

    /// <summary>
    /// Cerebro del modo VS IA. NO toca la interfaz ni modifica personajes:
    /// solo decide. FormBatalla ejecuta la accion elegida con NucleoBatalla.
    /// Costes reales del juego: Atacar = 10 energia, Especial = 20 mana,
    /// Curar = 15 mana (+25 vida), Defender = +25 energia, +15 mana, +10 def.
    /// </summary>
    public class DecisorIA
    {
        public const int CosteAtaque = 10;
        public const int CosteEspecial = 20;
        public const int CosteCuracion = 15;

        private readonly Random azar;

        public DecisorIA(Random azar)
        {
            this.azar = azar != null ? azar : new Random();
        }

        public AccionIA Decidir(Personaje ia, Personaje rival, bool puedeRelevar)
        {
            bool puedeAtacar  = ia.Energia >= CosteAtaque;
            bool puedeEspecial = ia.Mana >= CosteEspecial && ia.PuedeUsarEspecial();
            bool puedeCurar   = ia.Mana >= CosteCuracion;

            bool vidaBaja    = ia.Vida * 100 < ia.VidaMax * 35;
            bool vidaCritica = ia.Vida * 100 < ia.VidaMax * 15;

            // 1) Si el ataque normal remata al rival, se hace sin dudar.
            if (puedeAtacar && ia.EstimarDanoAtaque(rival) >= rival.Vida)
                return AccionIA.Atacar;

            // 2) Supervivencia: curarse o, como ultimo recurso, relevar.
            if (vidaBaja && puedeCurar)
                return AccionIA.Curar;

            if (vidaCritica && puedeRelevar)
                return AccionIA.Relevar;

            // 3) Gestion de recursos: con poca energia y mana, recuperar.
            if (!puedeAtacar && !puedeEspecial)
                return AccionIA.Defender;

            // 4) Ofensiva: el especial se prefiere si el rival tiene mucha defensa
            //    o con un 40 % de probabilidad (para no ser predecible).
            if (puedeEspecial && (rival.Defensa >= 40 || azar.Next(100) < 40))
                return AccionIA.Especial;

            if (puedeAtacar)
                return AccionIA.Atacar;

            return AccionIA.Especial; // sin energia pero con mana
        }
    }
}
