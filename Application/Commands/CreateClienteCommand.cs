using ClientesDapper.Presentation.Dtos;
using MediatR;

namespace ClientesDapper.Application.Commands
{
    public record CreateClienteCommand(CreateClienteDto cliente)
        : IRequest<int>;
}
