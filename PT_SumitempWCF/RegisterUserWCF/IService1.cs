using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace RegisterUserWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]

        // TODO: agregue aquí sus operaciones de servicio
        string RegisterUser(UserWCFDto user);
    }

    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    // Puede agregar archivos XSD al proyecto. Después de compilar el proyecto, puede usar directamente los tipos de datos definidos aquí, con el espacio de nombres "RegisterUserWCF.ContractType".
    [DataContract]
    public class UserWCFDto
    {
        [DataMember]
        public string DocumentoIdentidad { get; set; }

        [DataMember]
        public string Nombres { get; set; }

        [DataMember]
        public string Apellidos { get; set; }

        [DataMember]
        public DateTime FechaNacimiento { get; set; }

        [DataMember]
        public List<string> Telefonos { get; set; } = new List<string>();

        [DataMember]
        public List<string> CorreoElectronico { get; set; } = new List<string>();

        [DataMember]
        public List<string> Direccion { get; set; } = new List<string>();
    }
}
