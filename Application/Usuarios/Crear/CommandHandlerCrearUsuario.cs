﻿using Domain.Direcciones;
using Domain.ObjetosDeValor;
using Domain.Primitivos;
using Domain.Usuarios;
using Domain.Direcciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Usuarios.Crear
{
    internal sealed class CommandHandlerCrearUsuario : IRequestHandler<CommandCrearUsuario, Unit>
    {
        private readonly IRepositorioUsuario _repositorioUsuario;
        private readonly IUnitOfWork _unitOfWork;

        public CommandHandlerCrearUsuario(IRepositorioUsuario repositorioUsuario, IUnitOfWork unitOfWork)
        {
            _repositorioUsuario = repositorioUsuario ?? throw new ArgumentNullException(nameof(repositorioUsuario));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Unit> Handle(CommandCrearUsuario request, CancellationToken cancellationToken)
        {

            var usuarioId = new UsuarioId(Guid.NewGuid());

            if (NumeroDeTelefono.Crear(request.NumeroDeTelefono) is not NumeroDeTelefono numeroDeTelefono)
            {
                throw new ArgumentException(nameof(numeroDeTelefono));
            }

            var usuario = new Usuario(
                new UsuarioId(Guid.NewGuid()),
                request.Nombre,
                request.Apellido,
                request.Correo,
                numeroDeTelefono
            );

            _repositorioUsuario.Crear(usuario);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
