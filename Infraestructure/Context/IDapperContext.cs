using System.Data;

namespace ClientesDapper.Infraestructure.Context
{
    public interface IDapperContext
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }

        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
