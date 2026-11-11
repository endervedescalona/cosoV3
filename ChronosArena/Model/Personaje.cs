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
        public int CargasEspecial { get; private set; }
        public const int CargasRequeridas = 2;
        internal CartaAmbiente AmbienteActivo { get; set; }
        private bool efectosAmbienteAplicados;

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
            Nombre = nombre != null ? nombre : String.Empty;
            Faccion = faccion != null ? faccion : String.Empty;
            Elemento = elemento != null ? elemento : String.Empty;
            Clase = clase != null ? clase : String.Empty;

            VidaMax = Math.Max(1, vida);
            Vida = VidaMax;
            Ataque = Math.Max(0, ataque);
            Defensa = Math.Max(0, defensa);
            DefensaBase = Defensa;
            Energia = Math.Max(0, Math.Min(100, energia));
            Mana = Math.Max(0, Math.Min(100, mana));
            Empatia = Math.Max(0, empatia);

            HabilidadEspecial = habilidad != null ? habilidad : String.Empty;
            ImagenUrl = String.Empty;
            CargasEspecial = 0;
            AmbienteActivo = null;
            efectosAmbienteAplicados = false;
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

        
        public int EstimarDanoAtaque(Personaje objetivo)
        {
            int ataqueReal = Ataque;

            // Triángulo elemental (Bonus de facción/elemento)
            if ((Elemento == "Fuego" && objetivo.Elemento == "Aire") ||
                (Elemento == "Agua" && objetivo.Elemento == "Fuego") ||
                (Elemento == "Aire" && objetivo.Elemento == "Tierra") ||
                (Elemento == "Tierra" && objetivo.Elemento == "Agua"))
            {
                ataqueReal += 10;
            }

            // Fórmula racional de rendimientos decrecientes: Daño = Ataque * [ 50 / (50 + Defensa) ]
            double kConstante = 50.0;
            double factorMitigacion = kConstante / (kConstante + (double)objetivo.Defensa);
            int danoCalculado = (int)Math.Round(ataqueReal * factorMitigacion);
            return Math.Max(6, danoCalculado);
        }
        
        
        
       
        
        
        
        
        
        
        
        

        public int Atacar(Personaje objetivo)
        {
            return Atacar(objetivo, AmbienteActivo);
        }

        public int Atacar(Personaje objetivo, CartaAmbiente ambiente)
        {
            if (objetivo == null || objetivo.Vida <= 0 || !PuedeAtacar())
                return 0;

            int dano = EstimarDanoAtaque(objetivo);
            if (ambiente != null)
                dano = ambiente.CalcularDanoConAmbiente(dano, Faccion);
            objetivo.RecibirDano(dano);
            Energia = Math.Max(0, Energia - 10);
            return dano;
        }

        public void CargarEspecial()
        {
            CargasEspecial = Math.Min(CargasRequeridas, CargasEspecial + 1);
        }

        public bool PuedeUsarEspecial()
        {
            return CargasEspecial >= CargasRequeridas;
        }

        public void ConsumirCargaEspecial()
        {
            CargasEspecial = 0;
        }

        internal void AplicarModificadoresAmbiente(int bonusVida, int bonusDefensa)
        {
            if (efectosAmbienteAplicados)
                return;

            VidaMax = Math.Max(1, VidaMax + bonusVida);
            Vida = Math.Max(1, Math.Min(VidaMax, Vida + bonusVida));
            Defensa = Math.Max(0, Defensa + bonusDefensa);
            DefensaBase = Math.Max(0, DefensaBase + bonusDefensa);
            efectosAmbienteAplicados = true;
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
            if (AmbienteActivo != null)
                dano = AmbienteActivo.CalcularDanoConAmbiente(dano, Faccion);
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

        // El terremoto reduce vida y defensa por separado, sin aplicar
        // la penalización de defensa que normalmente produce un ataque.
        internal void RecibirTerremoto(int danoVida, int danoDefensa)
        {
            Vida = Math.Max(0, Vida - Math.Max(0, danoVida));
            Defensa = Math.Max(0, Defensa - Math.Max(0, danoDefensa));
            DefensaBase = Math.Max(0, DefensaBase - Math.Max(0, danoDefensa));
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
            copia.CargasEspecial = CargasEspecial;
            copia.AmbienteActivo = AmbienteActivo;
            copia.efectosAmbienteAplicados = efectosAmbienteAplicados;
            return copia;
        }
    }
}
