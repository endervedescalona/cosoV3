using System;

namespace ChronosArena
{
    public class Personaje
    {
        public string Nombre { get; set; }
        public string Faccion { get; set; }
        public string Elemento { get; set; }
        public string Clase { get; set; }
        public int VidaMax { get; set; }
        public int Vida { get; set; }
        public int Ataque { get; set; }
        public int Defensa { get; set; }
        public int Energia { get; set; }
        public int Mana { get; set; }
        public int Empatia { get; set; }
        public string HabilidadEspecial { get; set; }
        public string ImagenUrl { get; set; }

        public Personaje(
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
            Nombre = nombre;
            Faccion = faccion;
            Elemento = elemento;
            Clase = clase;

            VidaMax = vida;
            Vida = vida;
            Ataque = ataque;
            Defensa = defensa;
            Energia = energia;
            Mana = mana;
            Empatia = empatia;

            HabilidadEspecial = habilidad;
            ImagenUrl = String.Empty;
        }

        public virtual string EjecutarHabilidadEspecial()
        {
            return Nombre + " utiliza " + HabilidadEspecial + ".";
        }

        public Personaje Clonar()
        {
            Personaje p;

            switch (Clase)
            {
                case "Guerrero":
                    p = new Guerrero(Nombre, Faccion, Elemento, Clase,
                        VidaMax, Ataque, Defensa, Energia, Mana, Empatia, HabilidadEspecial);
                    break;
                case "Mago":
                    p = new Mago(Nombre, Faccion, Elemento, Clase,
                        VidaMax, Ataque, Defensa, Energia, Mana, Empatia, HabilidadEspecial);
                    break;
                case "Tanque":
                    p = new Tanque(Nombre, Faccion, Elemento, Clase,
                        VidaMax, Ataque, Defensa, Energia, Mana, Empatia, HabilidadEspecial);
                    break;
                default:
                    p = new Personaje(Nombre, Faccion, Elemento, Clase,
                        VidaMax, Ataque, Defensa, Energia, Mana, Empatia, HabilidadEspecial);
                    break;
            }

            p.ImagenUrl = ImagenUrl;
            p.Vida = Vida;
            return p;
        }

        public int Atacar(Personaje objetivo)
        {
            if (objetivo == null)
                return 0;

            int ataqueReal = Ataque;

            if ((Elemento == "Fuego" && objetivo.Elemento == "Aire") ||
                (Elemento == "Agua" && objetivo.Elemento == "Fuego") ||
                (Elemento == "Aire" && objetivo.Elemento == "Tierra") ||
                (Elemento == "Tierra" && objetivo.Elemento == "Agua"))
            {
                ataqueReal += 10;
            }

            int dano = Math.Max(5, ataqueReal - objetivo.Defensa / 3);

            objetivo.Vida = Math.Max(0, objetivo.Vida - dano);
            objetivo.Defensa = Math.Max(0, objetivo.Defensa - 5);
            Energia = Math.Max(0, Energia - 10);

            return dano;
        }

        public string UsarHabilidad(Personaje objetivo)
        {
            if (Mana < 20)
            {
                return Nombre +
                    " no tiene suficiente maná (necesita 20).";
            }

            Mana -= 20;

            int dano = Math.Max(
                10,
                Ataque + 15 - (objetivo == null ? 0 : objetivo.Defensa / 4));

            if (Clase == "Tanque")
            {
                Defensa += 20;

                return EjecutarHabilidadEspecial() +
                    " y obtiene +20 de defensa.";
            }

            string habilidad = HabilidadEspecial.ToLowerInvariant();

            if (habilidad.Contains("sanador") ||
                habilidad.Contains("sanador") ||
                habilidad.Contains("raíz") ||
                habilidad.Contains("sanador"))
            {
                int cura = Math.Min(30, VidaMax - Vida);
                Vida += cura;

                return EjecutarHabilidadEspecial() +
                    " y recupera " + cura + " de vida.";
            }

            if (objetivo != null)
            {
                objetivo.Vida = Math.Max(0, objetivo.Vida - dano);
            }

            return EjecutarHabilidadEspecial() +
                " e inflige " + dano + " de daño especial.";
        }

        public void Defender()
        {
            Defensa += 15;
            Energia = Math.Min(100, Energia + 10);
        }

        public void Curar()
        {
            if (Mana >= 15)
            {
                Mana -= 15;
                Vida = Math.Min(VidaMax, Vida + 25);
            }
        }
    }
}