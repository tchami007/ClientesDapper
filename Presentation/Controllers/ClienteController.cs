using ClientesDapper.Application.Commands;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClienteById(int id)
        {
            var solicitud = new GetClienteByIdQuery(id);
            var resultado = await _mediator.Send(solicitud);
            if (resultado == null)
                return NotFound();
            return Ok(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCliente([FromBody] CreateClienteDto clienteDto)
        {
            var solicitud = new CreateClienteCommand(clienteDto);
            int Id = await _mediator.Send(solicitud);
            if (Id <= 0)
                return BadRequest("No se pudo crear el cliente.");
            return Ok(Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(int id, [FromBody] ClienteDto clienteDto)
        {
            var solicitud = new UpdateClienteCommand(id, clienteDto);
            bool resultado = await _mediator.Send(solicitud);
            if (!resultado)
                return NotFound("No se encontró el cliente para actualizar.");
            return Ok("Cliente actualizado exitosamente.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id) 
        {
            var solicitud = new DeleteClienteCommand(id);
            bool resultado = await _mediator.Send(solicitud);
            if (!resultado)
                return NotFound();
            return Ok();   
        }

    }
}
