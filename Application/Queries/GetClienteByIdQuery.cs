using ClientesDapper.Presentation.Dtos;
using MediatR;

namespace ClientesDapper.Application.Queries
{
    public record GetClienteByIdQuery(int Id)
        : IRequest<ClienteDto>;
    
}
