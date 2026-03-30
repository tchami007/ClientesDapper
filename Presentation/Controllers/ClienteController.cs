using ClientesDapper.Application.Domain.Entities;
using ClientesDapper.Application.Queries;
using ClientesDapper.Presentation.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClientesDapper.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClientes()
        {
            var solicitud = new GetClienteAllQuery();
            List<ClienteDto>? clientes = await _mediator.Send(solicitud);
            if (clientes == null)
                return NotFound();
            return Ok(clientes);
        }
    }
}
