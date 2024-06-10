using Domain.Direcciones;
using Domain.ObjetosDeValor;
using Domain.Primitivos;
using Domain.Usuarios;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Usuarios.Crear
{
    internal sealed class CrearUsuarioCommandHandler : IRequestHandler<CrearUsuarioCommand, UsuarioId>
    {
        private readonly IRepositorioUsuario _repositorioUsuario;
        private readonly IUnitOfWork _unitOfWork;

        public CrearUsuarioCommandHandler(IRepositorioUsuario repositorioUsuario, IUnitOfWork unitOfWork)
        {
            _repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<UsuarioId> Handle(CrearUsuarioCommand request, CancellationToken cancellationToken)
        {
            if (NumeroDeTelefono.Crear(request.NumeroDeTelefono) is not NumeroDeTelefono numeroDeTelefono)
            {
                throw new ArgumentException(nameof(numeroDeTelefono));
            }

            var usuario = new Usuario(
                new UsuarioId(Guid.NewGuid()),
                request.Nombre,
                request.Apellido,
                request.Correo,
                numeroDeTelefono,
                request.Direcciones
            );

            _repositorioUsuario.Crear(usuario);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return usuario.Id;
        }
    }
}
