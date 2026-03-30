using ClientesDapper.Application.Domain.Entities;

namespace ClientesDapper.Application.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> GetClientesAll();
    }
}
