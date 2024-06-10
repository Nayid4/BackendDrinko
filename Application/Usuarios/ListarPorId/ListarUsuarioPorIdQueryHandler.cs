using Application.Usuarios.Common;
using Application.Usuarios.ListarTodos;
using Domain.Primitivos;
using Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
            if (await _repositorioUsuario.ListarPorId(new UsuarioId(request.Id)) is not Usuario usuario)
            {
                return Error.NotFound("Usuario.NoEncontrado", "No se encontró el usuario.");
            }

            return new UsuarioResponse(
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
                        direccion.CodigoPostal)).ToList());
        }
    }
}
