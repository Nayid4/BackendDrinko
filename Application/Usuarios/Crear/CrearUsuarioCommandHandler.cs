using Application.Custom;
using Domain.Direcciones;
using Domain.ObjetosDeValor;
using Domain.Primitivos;
using Domain.Usuarios;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Usuarios.Crear
{
    internal sealed class CrearUsuarioCommandHandler : IRequestHandler<CrearUsuarioCommand, ErrorOr<Unit>>
    {
        private readonly IRepositorioUsuario _repositorioUsuario;
        private readonly IUnitOfWork _unitOfWork;
        private readonly Utilidades _utilidades;

        public CrearUsuarioCommandHandler(IRepositorioUsuario repositorioUsuario, IUnitOfWork unitOfWork, Utilidades utilidades)
        {
            _repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _utilidades = utilidades ?? throw new ArgumentNullException(nameof(utilidades));
        }

        public async Task<ErrorOr<Unit>> Handle(CrearUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuarioId = new UsuarioId(Guid.NewGuid());

            // Crear una lista de direcciones a partir de los comandos recibidos
            var direcciones = request.Direcciones.Select(d =>
                new Direccion(
                    new DireccionId(Guid.NewGuid()),
                    usuarioId,
                    d.Linea1,
                    d.Linea2,
                    d.Ciudad,
                    d.Departamento,
                    d.CodigoPostal))
                .ToList(); // Convertir a lista para permitir la modificación

            if (NumeroDeTelefono.Crear(request.NumeroDeTelefono) is not NumeroDeTelefono numeroDeTelefono)
            {
                throw new ArgumentException(nameof(numeroDeTelefono));
            }

            // Crear una instancia de usuario con las direcciones
            var usuario = new Usuario(
                usuarioId,
                request.Nombre,
                request.Apellido,
                request.Correo,
                _utilidades.encriptarSHA256(request.Clave),
                numeroDeTelefono,
                direcciones.ToHashSet(), // Convertir la lista de direcciones a un HashSet
                request.Rol
            );

            _repositorioUsuario.Crear(usuario);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
