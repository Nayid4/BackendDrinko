using Application.Usuarios.Crear;
using Application.Usuarios.IniciarSesion;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [Route("Acceso")]
    [AllowAnonymous]
    public class ControladorAcceso : ApiController
    {
        private readonly ISender _mediator;

        public ControladorAcceso(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        [Route("/registrarse")]
        public async Task<IActionResult> Crear([FromBody] CrearUsuarioCommand command)
        {
            var resultadoCrear = await _mediator.Send(command);

            return resultadoCrear.Match(
                usuarioId => Ok(usuarioId),
                errors => Problem(errors)
            );
        }

        [HttpPost]
        [Route("/iniciar-sesion")]
        public async Task<IActionResult> IniciarSesion([FromBody] IniciarSesionCommand command)
        {
            var resultadoIniciarSesion = await _mediator.Send(command);

            return resultadoIniciarSesion.Match<IActionResult>(
                iniciarSesionResult => Ok(new {
                    UsuarioId = iniciarSesionResult.Id,
                    NombreCompleto = iniciarSesionResult.NombreCompre,
                    Rol = iniciarSesionResult.Rol,
                    Correo = iniciarSesionResult.Correo,
                    Token = iniciarSesionResult.Token
                }),
                errors => Unauthorized(errors.First().Description)
            ); 
        }
    }
}
