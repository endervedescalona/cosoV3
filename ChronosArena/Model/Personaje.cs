using System;

namespace ChronosArena
{
    /// <summary>
    /// Clase base abstracta de todos los personajes.
    /// Centraliza atributos comunes y reglas compartidas del combate.
    /// </summary>
    public abstract class Personaje
    {
        public string Nombre { get; private set; }
        public string Faccion { get; private set; }
        public string Elemento { get; private set; }
        public string Clase { get; private set; }
        public int VidaMax { get; private set; }
        public int Vida { get; private set; }
        public int Ataque { get; private set; }
        public int Defensa { get; protected set; }
        public int DefensaBase { get; private set; }
        public int Energia { get; protected set; }
        public int Mana { get; private set; }
        public int Empatia { get; private set; }
        public string HabilidadEspecial { get; private set; }
        public string ImagenUrl { get; private set; }

        protected Personaje(
            string nombre,
            string faccion,
            string elemento,
            string clase,
            int vida,
            int ataque,
            int defensa,
            int energia,
            int mana,
            int empatia,
            string habilidad)
        {
            Nombre = nombre ?? String.Empty;
            Faccion = faccion ?? String.Empty;
            Elemento = elemento ?? String.Empty;
            Clase = clase ?? String.Empty;

            VidaMax = Math.Max(1, vida);
            Vida = VidaMax;
            Ataque = Math.Max(0, ataque);
            Defensa = Math.Max(0, defensa);
            DefensaBase = Defensa;
            Energia = Math.Max(0, Math.Min(100, energia));
            Mana = Math.Max(0, Math.Min(100, mana));
            Empatia = Math.Max(0, empatia);

            HabilidadEspecial = habilidad ?? String.Empty;
            ImagenUrl = String.Empty;
        }

        /// <summary>
        /// Cada subclase define su efecto especial: esto aplica polimorfismo.
        /// </summary>
        public abstract string EjecutarHabilidadEspecial(Personaje objetivo);

        public void EstablecerImagenUrl(string url)
        {
            ImagenUrl = String.IsNullOrWhiteSpace(url) ? String.Empty : url.Trim();
        }

        public bool PuedeAtacar()
        {
            return Vida > 0 && Energia >= 10;
        }

        public int Atacar(Personaje objetivo)
        {
            if (objetivo == null || objetivo.Vida <= 0 || !PuedeAtacar())
                return 0;

            int ataqueReal = Ataque;

            if ((Elemento == "Fuego" && objetivo.Elemento == "Aire") ||
                (Elemento == "Agua" && objetivo.Elemento == "Fuego") ||
                (Elemento == "Aire" && objetivo.Elemento == "Tierra") ||
                (Elemento == "Tierra" && objetivo.Elemento == "Agua"))
            {
                ataqueReal += 10;
            }

            // La defensa reduce el daño, pero nunca lo anula: cada ataque
            // normal debe producir una variación visible en la barra de vida.
            int dano = Math.Max(8, ataqueReal - objetivo.Defensa / 5);
            objetivo.RecibirDano(dano);
            Energia = Math.Max(0, Energia - 10);

            return dano;
        }

        public string UsarHabilidad(Personaje objetivo)
        {
            if (Mana < 20)
            {
                return Nombre + " no tiene suficiente maná (necesita 20).";
            }

            if (Vida <= 0)
            {
                return Nombre + " no puede actuar porque ha sido derrotado.";
            }

            Mana -= 20;
            return EjecutarHabilidadEspecial(objetivo);
        }

        /// <summary>
        /// La defensa es la acción de recuperación: restaura energía y maná,
        /// además de reforzar la protección sin permitir acumulaciones infinitas.
        /// </summary>
        public virtual void Defender()
        {
            if (Vida <= 0)
                return;

            AumentarDefensa(10);
            Energia = Math.Min(100, Energia + 25);
            Mana = Math.Min(100, Mana + 15);
        }

        protected void AumentarDefensa(int cantidad)
        {
            int limite = Math.Min(100, DefensaBase + 30);
            Defensa = Math.Min(limite, Defensa + Math.Max(0, cantidad));
        }

        public void Curar()
        {
            if (Vida <= 0 || Mana < 15)
                return;

            Mana -= 15;
            RecuperarVida(25);
        }

        protected int AplicarDanoEspecial(
            Personaje objetivo,
            int poder,
            int divisorDefensa)
        {
            if (objetivo == null || objetivo.Vida <= 0)
                return 0;

            int divisor = Math.Max(1, divisorDefensa);
            int dano = Math.Max(10, poder - objetivo.Defensa / divisor);
            objetivo.RecibirDano(dano);
            return dano;
        }

        protected int RecuperarVida(int cantidad)
        {
            int anterior = Vida;
            Vida = Math.Min(VidaMax, Vida + Math.Max(0, cantidad));
            return Vida - anterior;
        }

        internal void RecibirDano(int cantidad)
        {
            if (Vida <= 0)
                return;

            Vida = Math.Max(0, Vida - Math.Max(0, cantidad));
            Defensa = Math.Max(0, Defensa - 5);
        }

        public Personaje Clonar()
        {
            Personaje copia;

            switch (Clase)
            {
                case "Guerrero":
                    copia = new Guerrero(Nombre, Faccion, Elemento, Clase,
                        VidaMax, Ataque, Defensa, Energia, Mana, Empatia, HabilidadEspecial);
                    break;
                case "Mago":
                    copia = new Mago(Nombre, Faccion, Elemento, Clase,
                        VidaMax, Ataque, Defensa, Energia, Mana, Empatia, HabilidadEspecial);
                    break;
                case "Tanque":
                    copia = new Tanque(Nombre, Faccion, Elemento, Clase,
                        VidaMax, Ataque, Defensa, Energia, Mana, Empatia, HabilidadEspecial);
                    break;
                case "Healer":
                    copia = new Healer(Nombre, Faccion, Elemento, Clase,
                        VidaMax, Ataque, Defensa, Energia, Mana, Empatia, HabilidadEspecial);
                    break;
                default:
                    copia = new PersonajeComun(Nombre, Faccion, Elemento, Clase,
                        VidaMax, Ataque, Defensa, Energia, Mana, Empatia, HabilidadEspecial);
                    break;
            }

            copia.EstablecerImagenUrl(ImagenUrl);
            copia.Vida = Vida;
            copia.DefensaBase = DefensaBase;
            copia.Defensa = Defensa;
            copia.Energia = Energia;
            copia.Mana = Mana;
            return copia;
        }
    }
}
