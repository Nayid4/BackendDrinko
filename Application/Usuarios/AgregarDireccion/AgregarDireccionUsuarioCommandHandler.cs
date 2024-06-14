using Application.Usuarios.Eliminar;
using Domain.Direcciones;
using Domain.Primitivos;
using Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Usuarios.AgregarDireccion
{
    internal sealed class AgregarDireccionUsuarioCommandHandler : IRequestHandler<AgregarDireccionUsuarioCommand, ErrorOr<bool>>
    {
        private readonly IRepositorioUsuario _repositorioUsuario;
        private readonly IUnitOfWork _unitOfWork;

        public AgregarDireccionUsuarioCommandHandler(IRepositorioUsuario repositorioUsuario, IUnitOfWork unitOfWork)
        {
            _repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }


        public async Task<ErrorOr<bool>> Handle(AgregarDireccionUsuarioCommand command, CancellationToken cancellationToken)
        {
            if (await _repositorioUsuario.ListarPorId(new UsuarioId(command.usuarioId)) is not Usuario usuario)
            {
                return Error.NotFound("Usuario.NoEncontrado", "No se encontró el usuario.");
            }

            usuario.AgregarDireccion(new Direccion(
                new DireccionId(Guid.NewGuid()),
                usuario.Id,
                command.Direccion.Linea1,
                command.Direccion.Linea2,
                command.Direccion.Ciudad,
                command.Direccion.Departamento,
                command.Direccion.CodigoPostal
                ));

            _repositorioUsuario.Actualizar(usuario);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
