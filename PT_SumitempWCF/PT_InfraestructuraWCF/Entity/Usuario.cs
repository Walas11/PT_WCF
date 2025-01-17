using System.ComponentModel.DataAnnotations;

namespace PT_InfraestructuraWCF.Entity
{
    public class Usuario
    {
        [Key]
        public required string DocumentoIdentidad { get; set; }
        public required string Nopmbres { get; set; }
        public required string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public required string Email { get; set; }
        public string Email2 { get; set; } = string.Empty;
        public required string Telefono { get; set; }
        public string Telefono2 { get; set; } = string.Empty;
        public required string Direccion { get; set; }
        public string Direccion2 { get; set; } = string.Empty;
    }
}
