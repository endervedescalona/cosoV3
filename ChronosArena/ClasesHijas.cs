namespace ChronosArena
{
    public class Guerrero : Personaje
    {
        public Guerrero(
            string nombre, string faccion, string elemento,
            string clase, int vida, int ataque, int defensa,
            int energia, int mana, int empatia, string habilidad)
            : base(nombre, faccion, elemento, clase, vida,
                   ataque, defensa, energia, mana, empatia, habilidad)
        {
        }

        public override string EjecutarHabilidadEspecial()
        {
            return Nombre + " ejecuta " + HabilidadEspecial + ".";
        }
    }

    public class Mago : Personaje
    {
        public Mago(
            string nombre, string faccion, string elemento,
            string clase, int vida, int ataque, int defensa,
            int energia, int mana, int empatia, string habilidad)
            : base(nombre, faccion, elemento, clase, vida,
                   ataque, defensa, energia, mana, empatia, habilidad)
        {
        }

        public override string EjecutarHabilidadEspecial()
        {
            return Nombre + " conjura " + HabilidadEspecial + ".";
        }
    }

    public class Healer : Personaje
    {
        public Healer(
            string nombre, string faccion, string elemento,
            string clase, int vida, int ataque, int defensa,
            int energia, int mana, int empatia, string habilidad)
            : base(nombre, faccion, elemento, clase, vida,
                   ataque, defensa, energia, mana, empatia, habilidad)
        {
        }

        public override string EjecutarHabilidadEspecial()
        {
            return Nombre + " utiliza " + HabilidadEspecial + ".";
        }
    }

    public class Tanque : Personaje
    {
        public Tanque(
            string nombre, string faccion, string elemento,
            string clase, int vida, int ataque, int defensa,
            int energia, int mana, int empatia, string habilidad)
            : base(nombre, faccion, elemento, clase, vida,
                   ataque, defensa, energia, mana, empatia, habilidad)
        {
        }

        public override string EjecutarHabilidadEspecial()
        {
            return Nombre + " activa " + HabilidadEspecial + ".";
        }
    }
}