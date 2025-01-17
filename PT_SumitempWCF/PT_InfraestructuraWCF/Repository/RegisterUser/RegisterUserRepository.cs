using Microsoft.Data.SqlClient;
using PT_InfraestructuraWCF.Entity;

namespace PT_InfraestructuraWCF.Repository.RegisterUser
{
    public class RegisterUserRepository
    {
        private readonly DataBaseRegisterUser _dbHelper;
        public RegisterUserRepository(DataBaseRegisterUser dbHelper)
        {
            _dbHelper = dbHelper;
        }

        // Insertar un Usuario
        public void InsertUsuario(Usuario usuario)
        {
            using var connection = _dbHelper.GetConnection();
            using var command = new SqlCommand("INSERT INTO Usuario (DocumentoIdentidad, Nombres, Apellidos, FechaNacimiento, Email, Email2, Telefono, Telefono2, Direccion, Direccion2) " +
                                               "VALUES (@DocumentoIdentidad, @Nombres, @Apellidos, @FechaNacimiento, @Email, @Email2, @Telefono, @Telefono2, @Direccion, @Direccion2)", connection);

            command.Parameters.AddWithValue("@DocumentoIdentidad", usuario.DocumentoIdentidad);
            command.Parameters.AddWithValue("@Nombres", usuario.Nopmbres);
            command.Parameters.AddWithValue("@Apellidos", usuario.Apellidos);
            command.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
            command.Parameters.AddWithValue("@Email", usuario.Email);
            command.Parameters.AddWithValue("@Email2", usuario.Email2);
            command.Parameters.AddWithValue("@Telefono", usuario.Telefono);
            command.Parameters.AddWithValue("@Telefono2", usuario.Telefono2);
            command.Parameters.AddWithValue("@Direccion", usuario.Direccion);
            command.Parameters.AddWithValue("@Direccion2", usuario.Direccion2);

            connection.Open();
            command.ExecuteNonQuery();
        }

        // Obtener un Usuario por DocumentoIdentidad
        public Usuario GetUsuarioByDocumento(string documentoIdentidad)
        {
            using var connection = _dbHelper.GetConnection();
            using var command = new SqlCommand("SELECT * FROM Usuario WHERE DocumentoIdentidad = @DocumentoIdentidad", connection);
            command.Parameters.AddWithValue("@DocumentoIdentidad", documentoIdentidad);

            connection.Open();
            using var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new Usuario
                {
                    DocumentoIdentidad = reader["DocumentoIdentidad"].ToString()!,
                    Nopmbres = reader["Nombres"].ToString()!,
                    Apellidos = reader["Apellidos"].ToString()!,
                    FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]),
                    Email = reader["Email"].ToString()!,
                    Email2 = reader["Email2"].ToString() ?? string.Empty,
                    Telefono = reader["Telefono"].ToString()!,
                    Telefono2 = reader["Telefono2"].ToString() ?? string.Empty,
                    Direccion = reader["Direccion"].ToString()!,
                    Direccion2 = reader["Direccion2"].ToString() ?? string.Empty
                };
            }

            return null!;
        }

        public List<Usuario> GetUsuarios()
        {
            var usuarios = new List<Usuario>();

            using var connection = _dbHelper.GetConnection();
            using var command = new SqlCommand("select * from Usuario", connection);
            connection.Open();

            using var reader = command.ExecuteReader();

            while (reader.Read()) // Iteramos sobre los resultados
            {
                var usuario = new Usuario
                {
                    DocumentoIdentidad = reader["DocumentoIdentidad"].ToString()!,
                    Nopmbres = reader["Nombres"].ToString()!,
                    Apellidos = reader["Apellidos"].ToString()!,
                    FechaNacimiento = reader.GetDateTime(reader.GetOrdinal("FechaNacimiento")),
                    Email = reader["Email"].ToString()!,
                    Email2 = reader["Email2"]?.ToString() ?? string.Empty,
                    Telefono = reader["Telefono"].ToString()!,
                    Telefono2 = reader["Telefono2"]?.ToString() ?? string.Empty,
                    Direccion = reader["Direccion"].ToString()!,
                    Direccion2 = reader["Direccion2"]?.ToString() ?? string.Empty
                };
                usuarios.Add(usuario);
            }

            return usuarios; // Devolvemos la lista completa de usuarios
        }
    }
}
