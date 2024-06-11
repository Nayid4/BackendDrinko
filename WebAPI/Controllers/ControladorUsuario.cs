using Application.Usuarios.Actualizar;
using Application.Usuarios.Crear;
using Application.Usuarios.Eliminar;
using Application.Usuarios.ListarPorId;
using Application.Usuarios.ListarTodos;
using Application.Usuarios.VerificarExistencia;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [Route("usuarios")]
    //[Authorize]
    public class ControladorUsuario : ApiController
    {
        private readonly ISender _mediator;

        public ControladorUsuario(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            var ResultadosUsuarios = await _mediator.Send(new ListarTodosLosUsuariosQuery());

            return ResultadosUsuarios.Match(
                usuarios => Ok(usuarios),
                errors => Problem(errors)
            );

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ListarPorId(Guid id)
        {
            var resultadoUsuario = await _mediator.Send(new ListarUsuariosPorIdQuery(id));

            return resultadoUsuario.Match(
                customer => Ok(customer),
                errors => Problem(errors)
            );
        }

        [HttpGet("verificar/{id}")]
        public async Task<IActionResult> VerificarExistencia(Guid id)
        {
            var resultadoUsuario = await _mediator.Send(new VerificarExistenciaDelUsuarioQuery(id));

            return resultadoUsuario.Match(
                customer => Ok(customer),
                errors => Problem(errors)
            );
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearUsuarioCommand command)
        {
            var resultadoCrear = await _mediator.Send(command);

            return resultadoCrear.Match(
                usuarioId => Ok(usuarioId),
                errors => Problem(errors)
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(Guid id, [FromBody] ActualizarUsuarioCommand command)
        {
            if (command.Id != id)
            {
                List<Error> errors = new()
            {
                Error.Validation("Usuario.ActualizacionInvalida", "Ha fallado la actualizacion del usuario.")
            };
                return Problem(errors);
            }

            var resultadoActualizacion = await _mediator.Send(command);

            return resultadoActualizacion.Match(
                usuarioId => NoContent(),
                errors => Problem(errors)
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(Guid id)
        {
            var resultadoEliminacion = await _mediator.Send(new EliminarUsuarioCommand(id));

            return resultadoEliminacion.Match(
                usuarioId => NoContent(),
                errors => Problem(errors)
            );
        }

    }
}
