using Application.Productos.Actualizar;
using Application.Productos.Crear;
using Application.Productos.Eliminar;
using Application.Productos.ListarPorId;
using Application.Productos.ListarTodos;
using Application.Productos.VerificarExistencia;
using Application.Usuarios.Crear;
using Application.Usuarios.ListarPorId;
using Application.Usuarios.ListarTodos;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [Route("productos")]
    [AllowAnonymous]
    public class ControladorProducto : ApiController
    {
        private readonly ISender _mediator;

        public ControladorProducto(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            var resultado = await _mediator.Send(new ListarTodosLosProductosQuery());

            return resultado.Match(
                productos => Ok(productos),
                errors => Problem(errors)
            );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ListarPorId(Guid id)
        {
            var resultado = await _mediator.Send(new ListarProductoPorIdQuery(id));

            return resultado.Match(
                producto => Ok(producto),
                errors => Problem(errors)
            );
        }

        [HttpGet("verificar/{id}")]
        public async Task<IActionResult> VerificarExistencia(Guid id)
        {
            var resultado = await _mediator.Send(new VerificarExistenciaDeProductoQuery(id));

            return resultado.Match(
                existe => Ok(existe),
                errors => Problem(errors)
            );
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearProductoCommand command)
        {
            var resultado = await _mediator.Send(command);

            return resultado.Match(
                productoId => Ok(productoId),
                errors => Problem(errors)
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(Guid id, [FromBody] ActualizarProductoCommand command)
        {
            if (command.Id != id)
            {
                return BadRequest("El ID del producto en la URL no coincide con el ID en el cuerpo de la solicitud.");
            }

            var resultado = await _mediator.Send(command);

            return resultado.Match(
                _ => NoContent(),
                errors => Problem(errors)
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(Guid id)
        {
            var resultado = await _mediator.Send(new EliminarProductoCommand(id));

            return resultado.Match(
                _ => NoContent(),
                errors => Problem(errors)
            );
        }
    }

}
