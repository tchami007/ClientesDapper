using MediatR;

namespace ClientesDapper.Application.Commands
{
    public record DeleteClienteCommand(int Id)
        :IRequest<bool>;
}
