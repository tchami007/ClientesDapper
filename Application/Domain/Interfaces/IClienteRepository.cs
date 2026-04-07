using ClientesDapper.Application.Domain.Entities;

namespace ClientesDapper.Application.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> GetClientesAll();
        Task<Cliente> GetClienteById(int Id);
        Task<int> CreateCliente(Cliente cliente);
        Task<bool> UpdateCliente(Cliente cliente);
        Task<bool> DeleteCliente(int id);
    }
}
