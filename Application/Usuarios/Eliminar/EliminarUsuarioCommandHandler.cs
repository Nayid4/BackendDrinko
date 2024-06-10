using Domain.Primitivos;
using Domain.Usuarios;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.Usuarios.Eliminar
{
    internal sealed class EliminarUsuarioCommandHandler : IRequestHandler<EliminarUsuarioCommand, ErrorOr<Unit>>
    {
        private readonly IRepositorioUsuario _repositorioUsuario;
        private readonly IUnitOfWork _unitOfWork;

        public EliminarUsuarioCommandHandler(IRepositorioUsuario repositorioUsuario, IUnitOfWork unitOfWork)
        {
            _repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }


        public async Task<ErrorOr<Unit>> Handle(EliminarUsuarioCommand command, CancellationToken cancellationToken)
        {
            if (await _repositorioUsuario.ListarPorId(new UsuarioId(command.Id)) is not Usuario usuario)
            {
                return Error.NotFound("Usuario.NoEncontrado", "No se encontró el usuario.");
            }

            _repositorioUsuario.Eliminar(usuario);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
