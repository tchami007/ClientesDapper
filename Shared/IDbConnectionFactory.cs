using System.Data.Common;

namespace ClientesDapper.Shared
{
    public interface IDbConnectionFactory
    {
        public DbConnection CreateConnection();
    }
}
