using Application.Productos.Crear;
using Application.Productos.ListarTodos;
using Application.Usuarios.Crear;
using Application.Usuarios.ListarPorId;
using Application.Usuarios.ListarTodos;

namespace WebAPI.Controllers
{
    [Route("productos")]
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
            var ResultadosProductos = await _mediator.Send(new ListarTodosLosProductosQuery());

            return ResultadosProductos.Match(
                productos => Ok(productos),
                errors => Problem(errors)
            );

        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearProductoCommand command)
        {
            var resultadoCrear = await _mediator.Send(command);

            return resultadoCrear.Match(
                productoId => Ok(productoId),
                errors => Problem(errors)
            );
        }
    }
}
