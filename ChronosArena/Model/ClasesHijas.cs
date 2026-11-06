namespace ChronosArena
{
    public class Guerrero : Personaje
    {
        public Guerrero(string nombre, string faccion, string elemento,
            string clase, int vida, int ataque, int defensa,
            int energia, int mana, int empatia, string habilidad)
            : base(nombre, faccion, elemento, clase, vida,
                ataque, defensa, energia, mana, empatia, habilidad)
        {
        }

        public override string EjecutarHabilidadEspecial(Personaje objetivo)
        {
            int dano = AplicarDanoEspecial(objetivo, Ataque + 20, 3);
            return Nombre + " ejecuta " + HabilidadEspecial +
                " e inflige " + dano + " de daño.";
        }
    }

    public class Mago : Personaje
    {
        public Mago(string nombre, string faccion, string elemento,
            string clase, int vida, int ataque, int defensa,
            int energia, int mana, int empatia, string habilidad)
            : base(nombre, faccion, elemento, clase, vida,
                ataque, defensa, energia, mana, empatia, habilidad)
        {
        }

        public override string EjecutarHabilidadEspecial(Personaje objetivo)
        {
            string habilidad = HabilidadEspecial.ToLowerInvariant();
            if (habilidad.Contains("sanador") ||
                habilidad.Contains("raíz") ||
                habilidad.Contains("raiz"))
            {
                int cura = RecuperarVida(35);
                return Nombre + " conjura " + HabilidadEspecial +
                    " y recupera " + cura + " puntos de vida.";
            }

            int dano = AplicarDanoEspecial(objetivo, Ataque + 30, 4);
            return Nombre + " conjura " + HabilidadEspecial +
                " e inflige " + dano + " de daño mágico.";
        }
    }

    public class Tanque : Personaje
    {
        public Tanque(string nombre, string faccion, string elemento,
            string clase, int vida, int ataque, int defensa,
            int energia, int mana, int empatia, string habilidad)
            : base(nombre, faccion, elemento, clase, vida,
                ataque, defensa, energia, mana, empatia, habilidad)
        {
        }

        public override string EjecutarHabilidadEspecial(Personaje objetivo)
        {
            AumentarDefensa(20);
            Energia = System.Math.Min(100, Energia + 10);
            return Nombre + " activa " + HabilidadEspecial +
                " y obtiene +20 de defensa y +10 de energía.";
        }
    }

    public class Healer : Personaje
    {
        public Healer(string nombre, string faccion, string elemento,
            string clase, int vida, int ataque, int defensa,
            int energia, int mana, int empatia, string habilidad)
            : base(nombre, faccion, elemento, clase, vida,
                ataque, defensa, energia, mana, empatia, habilidad)
        {
        }

        public override string EjecutarHabilidadEspecial(Personaje objetivo)
        {
            int cura = RecuperarVida(40);
            return Nombre + " utiliza " + HabilidadEspecial +
                " y recupera " + cura + " puntos de vida.";
        }
    }

    /// <summary>Tipo de respaldo para datos de personajes con clase personalizada.</summary>
    public class PersonajeComun : Personaje
    {
        public PersonajeComun(string nombre, string faccion, string elemento,
            string clase, int vida, int ataque, int defensa,
            int energia, int mana, int empatia, string habilidad)
            : base(nombre, faccion, elemento, clase, vida,
                ataque, defensa, energia, mana, empatia, habilidad)
        {
        }

        public override string EjecutarHabilidadEspecial(Personaje objetivo)
        {
            int dano = AplicarDanoEspecial(objetivo, Ataque + 15, 4);
            return Nombre + " utiliza " + HabilidadEspecial +
                " e inflige " + dano + " de daño.";
        }
    }
}
