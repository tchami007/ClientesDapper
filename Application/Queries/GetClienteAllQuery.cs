using ClientesDapper.Presentation.Dtos;
using MediatR;

namespace ClientesDapper.Application.Queries
{
    public record GetClienteAllQuery()
        : IRequest<List<ClienteDto>>;
}
