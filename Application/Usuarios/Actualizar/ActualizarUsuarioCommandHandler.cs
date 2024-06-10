using Domain.Direcciones;
using Domain.ObjetosDeValor;
using Domain.Primitivos;
using Domain.Usuarios;
using ErrorOr;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.Usuarios.Actualizar
{
    internal sealed class ActualizarUsuarioCommandHandler : IRequestHandler<ActualizarUsuarioCommand, ErrorOr<Unit>>
    {
        private readonly IRepositorioUsuario _repositorioUsuario;
        private readonly IUnitOfWork _unitOfWork;

        public ActualizarUsuarioCommandHandler(IRepositorioUsuario repositorioUsuario, IUnitOfWork unitOfWork)
        {
            _repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(ActualizarUsuarioCommand request, CancellationToken cancellationToken)
        {
            if (!await _repositorioUsuario.VerificarExistencia(new UsuarioId(request.Id)))
            {
                return Error.NotFound("Usuario.NoEcontrado", "No se encontro el usuario.");
            }


            if (NumeroDeTelefono.Crear(request.NumeroDeTelefono) is not NumeroDeTelefono numeroDeTelefono)
            {
                return Error.Validation("Usuaruo.NumeroDeTelefono", "Formato de numero de telefono incorrecto.");
            }

            
            Usuario usuario = Usuario.ActualizarUsuario(request.Id, request.Nombre, request.Apellido, request.Correo, numeroDeTelefono, request.Direcciones);
            _repositorioUsuario.Actualizar(usuario);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
