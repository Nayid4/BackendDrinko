using Application.CarritosDeCompras.Actualizar;
using Application.CarritosDeCompras.AgregarProducto;
using Application.CarritosDeCompras.Crear;
using Application.CarritosDeCompras.Eliminar;
using Application.CarritosDeCompras.EliminarProducto;
using Application.CarritosDeCompras.ListarPorId;
using Application.CarritosDeCompras.ListarPorIdDeUsuario;
using Application.CarritosDeCompras.ListarTodos;
using Application.CarritosDeCompras.Vaciar;
using Application.CarritosDeCompras.VerificarExistencia;
using Application.Pedidos.Actualizar;
using Application.Pedidos.AgregarProducto;
using Application.Pedidos.Crear;
using Application.Pedidos.Eliminar;
using Application.Pedidos.EliminarProducto;
using Application.Pedidos.ListarPorId;
using Application.Pedidos.ListarPorIdDeUsuario;
using Application.Pedidos.ListarTodos;
using Application.Pedidos.VerificarExistencia;

namespace WebAPI.Controllers
{
    [Route("pedidos")]
    public class ControladorPedidos : ApiController
    {
        private readonly ISender _mediator;

        public ControladorPedidos(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            var resultado = await _mediator.Send(new ListarTodosLosPedidosQuery());

            return resultado.Match(
                pedidos => Ok(pedidos),
                errors => Problem(errors)
            );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ListarPorId(Guid id)
        {
            var resultado = await _mediator.Send(new ListarPedidoPorIdQuery(id));

            return resultado.Match(
                pedido => Ok(pedido),
                errors => Problem(errors)
            );
        }

        [HttpGet("pedidos-usuario/{id}")]
        public async Task<IActionResult> ListarPorIdDeUsuario(Guid id)
        {
            var resultado = await _mediator.Send(new ListarPedidosPorIdDeUsuarioQuery(id));

            return resultado.Match(
                pedidos => Ok(pedidos),
                errors => Problem(errors)
            );
        }

        [HttpGet("verificar/{id}")]
        public async Task<IActionResult> VerificarExistencia(Guid id)
        {
            var resultado = await _mediator.Send(new VerificarExistenciaPedidoQuery(id));

            return resultado.Match(
                existe => Ok(existe),
                errors => Problem(errors)
            );
        }

        [HttpPost("agregar-producto")]
        public async Task<IActionResult> AgregarProducto([FromBody] AgregarProductoPedidoCommand command)
        {
            var resultado = await _mediator.Send(command);

            return resultado.Match(
                pedidoId => Ok(pedidoId),
                errors => Problem(errors)
            );
        }

        [HttpPost("eliminar-producto")]
        public async Task<IActionResult> EliminarProducto([FromBody] EliminarProductoDePedidoCommand command)
        {
            var resultado = await _mediator.Send(command);

            return resultado.Match(
                pedidoId => Ok(pedidoId),
                errors => Problem(errors)
            );
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearPedidoCommand command)
        {
            var resultado = await _mediator.Send(command);

            return resultado.Match(
                pedidoId => Ok(pedidoId),
                errors => Problem(errors)
            );
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(Guid id, [FromBody] ActualizarPedidoCommand command)
        {
            if (command.Id != id)
            {
                return BadRequest("El ID del pedido en la URL no coincide con el ID en el cuerpo de la solicitud.");
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
            var resultado = await _mediator.Send(new EliminarPedidoCommand(id));

            return resultado.Match(
                _ => NoContent(),
                errors => Problem(errors)
            );
        }

        
    }
}
