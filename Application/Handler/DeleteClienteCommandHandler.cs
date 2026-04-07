using ClientesDapper.Application.Commands;
using ClientesDapper.Application.Domain.Interfaces;
using MediatR;

namespace ClientesDapper.Application.Handler
{
    public class DeleteClienteCommandHandler
        : IRequestHandler<DeleteClienteCommand,bool>
    {
        private readonly IClienteRepository _repository;
        public DeleteClienteCommandHandler(IClienteRepository repository)
        {
            _repository = repository;
        }


        public async Task<bool> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            var resultado = await _repository.DeleteCliente(request.Id);

            return resultado;
        }
    }
}
