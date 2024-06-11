using Domain.Direcciones;
using Domain.Usuarios;
using MediatR;
using System;
using System.Collections.Generic;

namespace Application.Usuarios.Actualizar
{
    public record ActualizarUsuarioCommand(
        Guid Id,
        string Nombre,
        string Apellido,
        string Correo,
        string Clave,
        string NumeroDeTelefono,
        RolUsuario Rol, // Agregar el campo Rol
        HashSet<Direccion> Direcciones) : IRequest<ErrorOr<Unit>>;
}
