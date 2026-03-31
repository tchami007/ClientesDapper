using ClientesDapper.Application.Domain.Interfaces;
using ClientesDapper.Application.Queries;
using ClientesDapper.Presentation.Dtos;
using MediatR;

namespace ClientesDapper.Application.Handler
{
    public class GetClienteByIdQueryHandler
        : IRequestHandler<GetClienteByIdQuery,ClienteDto>
    {
        private readonly IClienteRepository _repository;

        public GetClienteByIdQueryHandler(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<ClienteDto> Handle(GetClienteByIdQuery request, CancellationToken cancellationToken)
        {
            var cliente = await _repository.GetClienteById(request.Id);

            var resultado = new ClienteDto
            {
                IdCliente = cliente.IdCliente,
                TipoDocumento = cliente.TipoDocumento,
                NumeroDocumento = cliente.NumeroDocumento,
                Apellidos = cliente.Apellidos,
                Nombres = cliente.Nombres,
                FechaNacimiento = cliente.FechaNacimiento,
                Genero = cliente.Genero
            };

            return resultado;
        }
    }
}
