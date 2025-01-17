using System.Runtime.Serialization;

namespace PT_SumitempWCF.Models
{
    [DataContract]
    public class UserWCFDto
    {
        [DataMember]
        public required string DocumentoIdentidad { get; set; }

        [DataMember]
        public required string Nombres { get; set; }

        [DataMember]
        public required string Apellidos { get; set; }

        [DataMember]
        public DateTime FechaNacimiento { get; set; }

        [DataMember]
        public List<int> Telefonos { get; set; } = new List<int>();

        [DataMember]
        public List<string> CorreoElectronico { get; set; } = new List<string>();

        [DataMember]
        public List<string> Direccion { get; set; } = new List<string>();
    }
}
