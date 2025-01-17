using PT_InfraestructuraWCF.Repository.RegisterUser;
using PT_SumitempWCF.Models;

namespace PT_SumitempWCF.Services
{
    public class RegisterUserService
    {
        public static RegisterUserRepository _UserRespository;
        public RegisterUserService(RegisterUserRepository userRepository)
        {
            _UserRespository = userRepository;
        }

        public bool CrearUsuario(UserDto user)
        {

            var resp = GetUserById(user.DocumentoIdentidad);
            if (resp == null)
            {
                var entity = UsuarioMapper.ToEntity(user);
                _UserRespository.InsertUsuario(entity);
                return true;
            }
            return false;
        }

        public UserDto? GetUserById(string documentoIdentidad)
        {
            var entity = _UserRespository.GetUsuarioByDocumento(documentoIdentidad);
            return entity == null ? null : UsuarioMapper.ToDto(entity);
        }

        public List<UserDto> GetUsers()
        {
            var entityList = _UserRespository.GetUsuarios(); // Obtienes la lista de Usuarios
            return entityList.Select(usuario => UsuarioMapper.ToDto(usuario)).ToList(); // Mapeas y devuelves la lista
        }

    }
}
