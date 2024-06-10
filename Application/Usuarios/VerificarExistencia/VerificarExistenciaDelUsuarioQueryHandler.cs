using Domain.Primitivos;
using Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Usuarios.VerificarExistencia
{
    internal sealed class VerificarExistenciaDelUsuarioQueryHandler : IRequestHandler<VerificarExistenciaDelUsuarioQuery, ErrorOr<bool>>
    {
        private readonly IRepositorioUsuario _repositorioUsuario;
        private readonly IUnitOfWork _unitOfWork;

        public VerificarExistenciaDelUsuarioQueryHandler(IRepositorioUsuario repositorioUsuario, IUnitOfWork unitOfWork)
        {
            _repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<bool>> Handle(VerificarExistenciaDelUsuarioQuery request, CancellationToken cancellationToken)
        {
            if (await _repositorioUsuario.ListarPorId(new UsuarioId(request.Id)) is not Usuario usuario)
            {
                return Error.NotFound("Usuario.NoEncontrado", "No se encontró el usuario.");
            }

            return true;
        }
    }
}
