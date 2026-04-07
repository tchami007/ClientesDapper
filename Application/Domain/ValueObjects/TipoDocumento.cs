namespace ClientesDapper.Application.Domain.ValueObjects
{
    public class TipoDocumento
    {
        public string nombre { get; }


        public static TipoDocumento DNI => new TipoDocumento("DNI");
        public static TipoDocumento CUIL => new TipoDocumento("CUIL");

        private TipoDocumento(string nombre)
        {
            this.nombre = nombre;
        }

        public static TipoDocumento FromString(string nombre)
        {
            return nombre switch
            {
                "DNI" => DNI,
                "CUIL" => CUIL,
                _ => throw new ArgumentException($"Tipo de documento no válido: {nombre}")
            };
        }
    }
}
