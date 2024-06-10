using Application.Usuarios.Common;
using Domain.Primitivos;
using Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            IReadOnlyList<Usuario> usuarios = await _repositorioUsuario.ListarTodos();

            return usuarios.Select(usuario => new UsuarioResponse(
                    usuario.Id.Valor,
                    usuario.Nombre,
                    usuario.Apellido,
                    usuario.Correo,
                    usuario.NumeroDeTelefono.Valor,
                    usuario.Direcciones.Select(direccion => new DireccionResponse(
                        direccion.Id.Valor,
                        direccion.Linea1,
                        direccion.Linea2,
                        direccion.Ciudad,
                        direccion.Departamento,
                        direccion.CodigoPostal)).ToList())
                    ).ToList();
        }
    }
}
