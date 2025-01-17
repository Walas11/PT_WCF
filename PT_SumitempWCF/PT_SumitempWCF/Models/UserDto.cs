namespace PT_SumitempWCF.Models
{
    public class UserDto
    {
        public required string DocumentoIdentidad { get; set; }
        public required string Nombres { get; set; }
        public required string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public List<string> Telefonos { get; set; } = new List<string>();
        public List<string> CorreoElectronico { get; set; } = new List<string>();
        public List<string> Direccion { get; set; } = new List<string>();
    }
}