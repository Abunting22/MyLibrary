using System.Data;
using Microsoft.Data.SqlClient;
using MyLibrary.Server.Interfaces;

namespace MyLibrary.Server.Repositories
{
    public class BaseRepository(IConfiguration configuration) : IBaseRepository
    {
        private readonly string _connectionString = configuration.GetConnectionString("DefaultConnection")!;

        public IDbConnection GetConnection()
        {
            try
            {
                return new SqlConnection(_connectionString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetConnection: {ex.Message}");
                throw new Exception("Error establishing connection.");
            }
        }
    }
}
