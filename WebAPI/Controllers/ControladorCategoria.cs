using Application.categorias.ListarTodos;
using Application.Categorias.Actualizar;
using Application.Categorias.Crear;
using Application.Categorias.Eliminar;
using Application.Categorias.ListarPorId;
using Application.Categorias.VerificarExistencia;
using Application.Productos.Crear;
using Application.Productos.ListarTodos;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [Route("categorias")]
    //[Authorize]
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
            var resultado = await _mediator.Send(new ListarTodasLasCategoriasQuery());

            return resultado.Match(
                categorias => Ok(categorias),
                errors => Problem(errors)
            );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ListarPorId(Guid id)
        {
            var resultado = await _mediator.Send(new ListarCategoriaPorIdQuery(id));

            return resultado.Match(
                categoria => Ok(categoria),
                errors => Problem(errors)
            );
        }

        [HttpGet("verificar/{id}")]
        public async Task<IActionResult> VerificarExistencia(Guid id)
        {
            var resultado = await _mediator.Send(new VerificarExistenciaDeCategoriaQuery(id));

            return resultado.Match(
                existe => Ok(existe),
                errors => Problem(errors)
            );
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearCategoriaCommand command)
        {
            var resultado = await _mediator.Send(command);

            return resultado.Match(
                categoriaId => Ok(categoriaId),
                errors => Problem(errors)
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(Guid id, [FromBody] ActualizarCategoriaCommand command)
        {
            if (command.Id != id)
            {
                return BadRequest("El ID de la categoría en la URL no coincide con el ID en el cuerpo de la solicitud.");
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
            var resultado = await _mediator.Send(new EliminarCategoriaCommand(id));

            return resultado.Match(
                _ => NoContent(),
                errors => Problem(errors)
            );
        }
    }

}
