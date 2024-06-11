using Application.CarritosDeCompras.Actualizar;
using Application.CarritosDeCompras.AgregarProducto;
using Application.CarritosDeCompras.Crear;
using Application.CarritosDeCompras.Eliminar;
using Application.CarritosDeCompras.ListarPorId;
using Application.CarritosDeCompras.ListarTodos;
using Application.CarritosDeCompras.VerificarExistencia;
using Application.Productos.Actualizar;
using Application.Productos.Crear;
using Application.Productos.Eliminar;
using Application.Productos.ListarPorId;
using Application.Productos.ListarTodos;
using Application.Productos.VerificarExistencia;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [Route("carrito-de-compras")]
    //[Authorize]
    public class ControladorCarritoDeCompras : ApiController
    {
        private readonly ISender _mediator;

        public ControladorCarritoDeCompras(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            var resultado = await _mediator.Send(new ListarTodosLosCarritosDeComprasQuery());

            return resultado.Match(
                carritos => Ok(carritos),
                errors => Problem(errors)
            );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ListarPorId(Guid id)
        {
            var resultado = await _mediator.Send(new ListarCarritoDeComprasPorIdQuery(id));

            return resultado.Match(
                producto => Ok(producto),
                errors => Problem(errors)
            );
        }

        [HttpGet("verificar/{id}")]
        public async Task<IActionResult> VerificarExistencia(Guid id)
        {
            var resultado = await _mediator.Send(new VerificarExistenciaCarritoDeComprasQuery(id));

            return resultado.Match(
                existe => Ok(existe),
                errors => Problem(errors)
            );
        }

        [HttpPost("agregar-producto")]
        public async Task<IActionResult> AgregarProducto([FromBody] AgregarProductoCommand command)
        {
            var resultado = await _mediator.Send(command);

            return resultado.Match(
                carritoId => Ok(carritoId),
                errors => Problem(errors)
            );
        }

        [HttpPost("eliminar-producto")]
        public async Task<IActionResult> EliminarProducto([FromBody] AgregarProductoCommand command)
        {
            var resultado = await _mediator.Send(command);

            return resultado.Match(
                carritoId => Ok(carritoId),
                errors => Problem(errors)
            );
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearCarritoDeComprasCommand command)
        {
            var resultado = await _mediator.Send(command);

            return resultado.Match(
                carritoId => Ok(carritoId),
                errors => Problem(errors)
            );
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(Guid id, [FromBody] ActualizarCarritoDeComprasCommand command)
        {
            if (command.Id != id)
            {
                return BadRequest("El ID del carrito de compras en la URL no coincide con el ID en el cuerpo de la solicitud.");
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
            var resultado = await _mediator.Send(new EliminarCarritoDeComprasCommand(id));

            return resultado.Match(
                _ => NoContent(),
                errors => Problem(errors)
            );
        }


    }
}
