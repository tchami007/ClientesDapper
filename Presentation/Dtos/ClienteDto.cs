namespace ClientesDapper.Presentation.Dtos
{
    public class ClienteDto
    {
        public int IdCliente { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; }
    }
}
