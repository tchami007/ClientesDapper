using System.Data;
using System.Data.Common;
using Microsoft.Data.SqlClient;

namespace ClientesDapper.Shared
{
    public class SqlConnectionFactory : IDbConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public SqlConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbConnection CreateConnection()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
                throw new InvalidOperationException("Connection string 'DefaultConnection' no está configurado.");

            return new SqlConnection(connectionString);
        }

    }
}
