using ClientesDapper.Application.Domain.Entities;
using ClientesDapper.Application.Domain.Interfaces;
using ClientesDapper.Application.Queries;
using ClientesDapper.Presentation.Dtos;
using MediatR;

namespace ClientesDapper.Application.Handler
{
    public class GetClienteAllQueryHandler
        : IRequestHandler<GetClienteAllQuery, List<ClienteDto>?>
    {

        private readonly IClienteRepository _repository;

        public GetClienteAllQueryHandler(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ClienteDto>> Handle(GetClienteAllQuery request, CancellationToken cancellationToken)
        {
            var clientes = await _repository.GetClientesAll();

            var result = clientes.Select(c => new ClienteDto
            {
                IdCliente = c.IdCliente,
                TipoDocumento = c.TipoDocumento,
                NumeroDocumento = c.NumeroDocumento,
                Nombres = c.Nombres,
                Apellidos = c.Apellidos,
                FechaNacimiento =c.FechaNacimiento,
                Genero=c.Genero
            }
                );

            return result.ToList();
        }
    }
}
