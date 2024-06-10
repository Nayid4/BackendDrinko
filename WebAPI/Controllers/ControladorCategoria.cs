using Application.categorias.ListarTodos;
using Application.Categorias.Crear;
using Application.Productos.Crear;
using Application.Productos.ListarTodos;

namespace WebAPI.Controllers
{
    [Route("categorias")]
    public class ControladorCategoria : ApiController
    {
        private readonly ISender _mediator;

        public ControladorCategoria(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            var ResultadosCategorias = await _mediator.Send(new ListarTodasLasCategoriasQuery());

            return ResultadosCategorias.Match(
                categorias => Ok(categorias),
                errors => Problem(errors)
            );

        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearCategoriaCommand command)
        {
            var resultadoCrear = await _mediator.Send(command);

            return resultadoCrear.Match(
                categoriaId => Ok(categoriaId),
                errors => Problem(errors)
            );
        }
    }
}
