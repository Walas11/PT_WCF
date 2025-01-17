using System;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Threading.Tasks;

namespace RegisterUserWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código y en el archivo de configuración a la vez.
    public class Service1 : IService1, IMetadataExchange
    {
        public string RegisterUser(UserWCFDto user)
        {
            // Validaciones
            if (!IsValidAlphanumeric(user.DocumentoIdentidad))
                return "El documento de identidad debe ser alfanumérico.";

            if (!IsValidName(user.Nombres) || !IsValidName(user.Apellidos))
                return "Los nombres y apellidos deben contener solo caracteres del alfabeto latino.";

            if (user.Telefonos.Any(t => !t.All(char.IsDigit) || long.Parse(t) <= 0))
                return "El teléfono debe contener solo números positivos.";

            // Aquí llamas al repositorio para guardar el usuario en la base de datos
            bool result = SaveUserToDatabase(user);
            return result ? "Usuario registrado exitosamente." : "Error al registrar el usuario.";
        }

        // Implementación de IMetadataExchange para exponer metadatos
        public Message Get(Message request)
        {
            return null;
        }

        // Métodos asincrónicos de IMetadataExchange (implementación trivial)
        public IAsyncResult BeginGet(Message request, AsyncCallback callback, object state)
        {
            return Task<Message>.Factory.StartNew(() => Get(request)); // Hacemos una operación sincrónica dentro de una tarea asincrónica
        }

        public Message EndGet(IAsyncResult result)
        {
            return ((Task<Message>)result).Result; // Finalizamos la operación asincrónica y obtenemos el resultado
        }

        private bool SaveUserToDatabase(UserWCFDto user)
        {
            // Simula la lógica para guardar el usuario (reemplaza con tu código real).
            return true;
        }

        private bool IsValidAlphanumeric(string input)
        {
            return !string.IsNullOrWhiteSpace(input) && input.All(char.IsLetterOrDigit);
        }

        private bool IsValidName(string input)
        {
            return !string.IsNullOrWhiteSpace(input) && input.All(c => char.IsLetter(c) || c == ' ');
        }
    }
}
