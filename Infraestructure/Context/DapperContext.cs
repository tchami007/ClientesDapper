using ClientesDapper.Shared;
using System.Data;

namespace ClientesDapper.Infraestructure.Context
{
    public class DapperContext : IDapperContext, IDisposable
    {

        private readonly IDbConnectionFactory _connectionFactory;
        public IDbConnection Connection { get; private set; }

        public IDbTransaction Transaction { get; private set; }

        public DapperContext(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
            Connection = _connectionFactory.CreateConnection();
            Connection.Open();
        }

        public void BeginTransaction()
        {
            if (Transaction != null)
            {
                throw new InvalidOperationException("Ya existe una transaccion activa"); 
            }

            Transaction = Connection.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                Transaction?.Commit();
            }
            finally
            {
                DisposeTransaction();
            }
        }

        public void Rollback()
        {
            try
            {
                Transaction?.Rollback();
            }
            finally
            {
                DisposeTransaction();
            }
        }

        private void DisposeTransaction() 
        {
            Transaction?.Dispose();
            Transaction = null;
        }

        public void Dispose()
        {
            try
            {
                if (Transaction != null)
                {
                    Transaction.Rollback();
                }
            }
            finally
            {
                DisposeTransaction();
                Connection?.Dispose();
            }
        }
    }
}
