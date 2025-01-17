using PT_InfraestructuraWCF.Entity;
using PT_SumitempWCF.Models;

namespace PT_SumitempWCF.Services
{
    public class UsuarioMapper
    {
        public static UserDto ToDto(Usuario entity)
        {
            return new UserDto
            {
                DocumentoIdentidad = entity.DocumentoIdentidad,
                Nombres = entity.Nopmbres,
                Apellidos = entity.Apellidos,
                FechaNacimiento = entity.FechaNacimiento,
                Telefonos = new List<string>
                {
                    entity.Telefono,
                    entity.Telefono2
                }.Where(e => !string.IsNullOrEmpty(e)).ToList(),
                CorreoElectronico = new List<string>
                {
                    entity.Email,
                    entity.Email2
                }.Where(e => !string.IsNullOrEmpty(e)).ToList(),
                Direccion = new List<string>
                {
                    entity.Direccion,
                    entity.Direccion2
                }.Where(e => !string.IsNullOrEmpty(e)).ToList(),
            };
        }

        public static Usuario ToEntity(UserDto dto)
        {
            return new Usuario
            {
                DocumentoIdentidad = dto.DocumentoIdentidad,
                Nopmbres = dto.Nombres,
                Apellidos = dto.Apellidos,
                FechaNacimiento = dto.FechaNacimiento,
                Email = dto.CorreoElectronico.ElementAtOrDefault(0) ?? string.Empty,
                Email2 = dto.CorreoElectronico.ElementAtOrDefault(1) ?? string.Empty,
                Telefono = dto.Telefonos.ElementAtOrDefault(0) ?? string.Empty,
                Telefono2 = dto.Telefonos.ElementAtOrDefault(1) ?? string.Empty,
                Direccion = dto.Direccion.ElementAtOrDefault(0) ?? string.Empty,
                Direccion2 = dto.Direccion.ElementAtOrDefault(1) ?? string.Empty
            };
        }
    }
}
