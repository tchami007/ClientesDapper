using ClientesDapper.Application.Commands;
using ClientesDapper.Application.Domain.Entities;
using ClientesDapper.Application.Domain.Interfaces;
using MediatR;

namespace ClientesDapper.Application.Handler
{
    public class CreateClienteCommandHandler
        : IRequestHandler<CreateClienteCommand, int>
    {
        private readonly IClienteRepository _clienteRepository;

        public CreateClienteCommandHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<int> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            Cliente nuevo = new Cliente
            {
                TipoDocumento = request.cliente.TipoDocumento,
                NumeroDocumento = request.cliente.NumeroDocumento,
                Apellidos = request.cliente.Apellidos,
                Nombres = request.cliente.Nombres,
                FechaNacimiento = request.cliente.FechaNacimiento,
                Genero = request.cliente.Genero
            };

            return await _clienteRepository.CreateCliente(nuevo);
        }
    }
}
