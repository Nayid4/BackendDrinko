using Domain.Usuarios;
using Domain.ObjetosDeValor;
using MediatR;
using ErrorOr;
using Application.Custom;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Usuarios.IniciarSesion
{
    public class IniciarSesionCommandHandler : IRequestHandler<IniciarSesionCommand, ErrorOr<IniciarSesionResult>>
    {
        private readonly IRepositorioUsuario _repositorioUsuario;
        private readonly Utilidades _utilidades;

        public IniciarSesionCommandHandler(IRepositorioUsuario repositorioUsuario, Utilidades utilidades)
        {
            _repositorioUsuario = repositorioUsuario;
            _utilidades = utilidades;
        }

        public async Task<ErrorOr<IniciarSesionResult>> Handle(IniciarSesionCommand request, CancellationToken cancellationToken)
        {
            var claveEncriptada = _utilidades.encriptarSHA256(request.Clave);
            var usuario = await _repositorioUsuario.ObtenerPorCorreoYClave(request.Correo, claveEncriptada);

            if (usuario == null)
            {
                return Error.Validation("IniciarSesion.Fallido", "Correo o clave incorrectos");
            }

            var token = _utilidades.generarJWT(usuario);
            return new IniciarSesionResult(token);
        }
    }
}
