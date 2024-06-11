using Application.Usuarios.Common;
using Domain.Direcciones;
using Domain.ObjetosDeValor;
using Domain.Usuarios;
using MediatR;
using System.Collections.Generic;

namespace Application.Usuarios.Crear
{
    public record CrearUsuarioCommand(
        string Nombre,
        string Apellido,
        string Correo,
        string Clave,
        string NumeroDeTelefono,
        RolUsuario Rol,
        List<DireccionCommand> Direcciones
    ) : IRequest<ErrorOr<Unit>>;
}
