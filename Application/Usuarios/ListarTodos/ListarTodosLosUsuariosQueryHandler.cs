using Application.Usuarios.Common;
using Domain.Primitivos;
using Domain.Usuarios;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Usuarios.ListarTodos
{
    internal sealed class ListarTodosLosUsuariosQueryHandler : IRequestHandler<ListarTodosLosUsuariosQuery, ErrorOr<IReadOnlyList<UsuarioResponse>>>
    {
        private readonly IRepositorioUsuario _repositorioUsuario;
        private readonly IUnitOfWork _unitOfWork;

        public ListarTodosLosUsuariosQueryHandler(IRepositorioUsuario repositorioUsuario, IUnitOfWork unitOfWork)
        {
            _repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<IReadOnlyList<UsuarioResponse>>> Handle(ListarTodosLosUsuariosQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await _repositorioUsuario.ListarTodos();

            var usuariosResponse = usuarios.Select(usuario => new UsuarioResponse(
                usuario.Id.Valor,
                usuario.Nombre,
                usuario.Apellido,
                usuario.Correo,
                usuario.Clave,
                usuario.NumeroDeTelefono.Valor,
                usuario.Rol,
                usuario.Direcciones.Select(d => new DireccionResponse(
                    d.Id.Valor,
                    d.Linea1,
                    d.Linea2,
                    d.Ciudad,
                    d.Departamento,
                    d.CodigoPostal)).ToList())).ToList();

            return usuariosResponse;
        }
    }
}
