using Application.Usuarios.Common;
using Domain.Primitivos;
using Domain.Usuarios;
using ErrorOr;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Usuarios.ListarPorId
{
    internal sealed class ListarUsuarioPorIdQueryHandler : IRequestHandler<ListarUsuariosPorIdQuery, ErrorOr<UsuarioResponse>>
    {
        private readonly IRepositorioUsuario _repositorioUsuario;
        private readonly IUnitOfWork _unitOfWork;

        public ListarUsuarioPorIdQueryHandler(IRepositorioUsuario repositorioUsuario, IUnitOfWork unitOfWork)
        {
            _repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<UsuarioResponse>> Handle(ListarUsuariosPorIdQuery request, CancellationToken cancellationToken)
        {
            var usuario = await _repositorioUsuario.ListarPorId(new UsuarioId(request.Id));
            if (usuario is null)
            {
                return Error.NotFound("Usuario.NoEncontrado", "No se encontró el usuario.");
            }

            var direcciones = usuario.Direcciones.Select(d => new DireccionResponse(
                d.Id.Valor,
                d.Linea1,
                d.Linea2,
                d.Ciudad,
                d.Departamento,
                d.CodigoPostal)).ToList();

            var usuarioResponse = new UsuarioResponse(
                usuario.Id.Valor,
                usuario.Nombre,
                usuario.Apellido,
                usuario.Correo,
                usuario.Clave,
                usuario.NumeroDeTelefono.Valor,
                usuario.Rol,
                direcciones);

            return usuarioResponse;
        }
    }
}