using ClientesDapper.Application.Domain.Entities;
using ClientesDapper.Application.Domain.Interfaces;
using ClientesDapper.Infraestructure.Context;
using Dapper;
using System.Collections.Immutable;

namespace ClientesDapper.Infraestructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IDapperContext _context;

        public ClienteRepository(IDapperContext context)
        {
            _context = context;
        }

        public Task<int> CreateCliente(Cliente cliente)
        {
            const string sql = "INSERT INTO Clientes (TipoDocumento, NumeroDocumento, Apellidos, Nombres, FechaNacimiento, Genero) " +
                               "VALUES (@TipoDocumento, @NumeroDocumento, @Apellidos, @Nombres, @FechaNacimiento, @Genero); " +
                               "SELECT CAST(SCOPE_IDENTITY() as int)";

            int Id = 0;
            try
            {
                Id = _context.Connection.QuerySingle<int>(
                    sql,
                    new
                    {
                        TipoDocumento = cliente.TipoDocumento,
                        NumeroDocumento = cliente.NumeroDocumento,
                        Apellidos = cliente.Apellidos,
                        Nombres = cliente.Nombres,
                        FechaNacimiento = cliente.FechaNacimiento,
                        Genero = cliente.Genero
                    },

                    transaction: _context.Transaction);
            }
            catch (Exception ex)
            {

                // Manejar la excepción según sea necesario
                Id = -1;
                return Task.FromResult(Id);
            }

            return Task.FromResult(Id);
        }

        public async Task<bool> DeleteCliente(int id)
        {
            const string sql= "DELETE FROM Clientes WHERE IdCliente = @IdCliente";

            var resultado = await _context.Connection.ExecuteAsync(sql, new { IdCliente = id }, transaction: _context.Transaction);

            return (resultado > 0);
        }

        public async Task<Cliente> GetClienteById(int Id)
        {
            const string sql = @"SELECT 
                IdCliente,
                TipoDocumento,
                NumeroDocumento,
                Apellidos,
                Nombres,
                FechaNacimiento,
                Genero 
                FROM Clientes
                WHERE
                IdCliente=@Id";

            var cliente = await _context.Connection.QueryFirstOrDefaultAsync<Cliente>(
                sql,
                new { Id = Id }, transaction: _context.Transaction);

            return cliente;
        }

        public async Task<List<Cliente>> GetClientesAll()
        {
            const string sql = @"SELECT 
                IdCliente,
                TipoDocumento,
                NumeroDocumento,
                Apellidos,
                Nombres,
                FechaNacimiento,
                Genero 
            FROM Clientes";

            var clientes = await _context.Connection.QueryAsync<Cliente>(sql, transaction: _context.Transaction);

            return clientes.ToList();
        }

        public async Task<bool> UpdateCliente(Cliente cliente)
        {
            const string sql = @"UPDATE Clientes SET 
                TipoDocumento = @TipoDocumento,
                NumeroDocumento = @NumeroDocumento,
                Apellidos = @Apellidos,
                Nombres = @Nombres,
                FechaNacimiento = @FechaNacimiento,
                Genero = @Genero
            WHERE IdCliente = @IdCliente";

            var resultado = await _context.Connection.ExecuteAsync(
                sql,
                new
                {
                    IdCliente = cliente.IdCliente,
                    TipoDocumento = cliente.TipoDocumento,
                    NumeroDocumento = cliente.NumeroDocumento,
                    Apellidos = cliente.Apellidos,
                    Nombres = cliente.Nombres,
                    FechaNacimiento = cliente.FechaNacimiento,
                    Genero = cliente.Genero
                },
                transaction: _context.Transaction);

            return (resultado > 0);
        }
    }
}
