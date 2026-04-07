namespace ClientesDapper.Application.Domain.ValueObjects
{
    public class Genero
    {
        public string nombre { get; }

        public static Genero M => new Genero("M");
        public static Genero F => new Genero("F");
        public static Genero O => new Genero("O");

        public Genero(string nombre)
        {
            this.nombre = nombre;
        }

        public static Genero FromString(string str)
        {
            return str switch
            {
                "M" => M,
                "F" => F,
                "O" => O,
                _ => throw new ArgumentException($"Género no válido: {str}")
            };
        }

    }
}
