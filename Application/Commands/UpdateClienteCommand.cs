using ClientesDapper.Presentation.Dtos;
using MediatR;

namespace ClientesDapper.Application.Commands
{
    public record UpdateClienteCommand(int id,ClienteDto cliente)
        : IRequest<bool>;
}
