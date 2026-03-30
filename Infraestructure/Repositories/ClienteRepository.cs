using ClientesDapper.Application.Domain.Entities;
using ClientesDapper.Application.Domain.Interfaces;
using ClientesDapper.Infraestructure.Context;
using Dapper;

namespace ClientesDapper.Infraestructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IDapperContext _context;

        public ClienteRepository(IDapperContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> GetClientesAll()
        {
            const string sql = "SELECT IdCliente,TipoDocumento,NumeroDocumento,Apellidos,Nombres,FechaNacimiento,Genero FROM Clientes";

            var clientes = await _context.Connection.QueryAsync<Cliente>(sql, transaction: _context.Transaction);

            return clientes.ToList();
        }
    }
}
