using Microsoft.Data.SqlClient;

namespace PT_InfraestructuraWCF.Repository.RegisterUser
{
    public class DataBaseRegisterUser
    {
        private readonly string _connectionString;
        public DataBaseRegisterUser(string connectionString)
        {
            _connectionString = connectionString;
        }
        public SqlConnection GetConnection()
        {
            var connection = new SqlConnection(_connectionString);
            try
            {
                connection.Open();
                Console.WriteLine("Conexión exitosa a la base de datos.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al conectar a la base de datos: {ex.Message}");
            }

            return new SqlConnection(_connectionString);
        }
    }
}