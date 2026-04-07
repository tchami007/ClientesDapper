using ClientesDapper.Application.Commands;
using ClientesDapper.Application.Domain.Entities;
using ClientesDapper.Application.Domain.Interfaces;
using MediatR;

namespace ClientesDapper.Application.Handler
{
    public class UpdateClienteCommandHandler
        : IRequestHandler<UpdateClienteCommand,bool>
    {
        private readonly IClienteRepository _repository;

        public UpdateClienteCommandHandler(IClienteRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            Cliente modificado = new Cliente
            {
                IdCliente = request.cliente.IdCliente,
                TipoDocumento = request.cliente.TipoDocumento,
                NumeroDocumento = request.cliente.NumeroDocumento,
                Apellidos = request.cliente.Apellidos,
                Nombres = request.cliente.Nombres,
                FechaNacimiento = request.cliente.FechaNacimiento,
                Genero = request.cliente.Genero
            };

            return _repository.UpdateCliente(modificado);
        }
    }
}
