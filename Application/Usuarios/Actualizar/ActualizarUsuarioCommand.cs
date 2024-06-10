using Domain.Direcciones;
using Domain.ObjetosDeValor;
using Domain.Usuarios;
using MediatR;
using System.Collections.Generic;

namespace Application.Usuarios.Actualizar
{
    public record ActualizarUsuarioCommand(
        Guid Id,
        string Nombre,
        string Apellido,
        string Correo,
        string NumeroDeTelefono,
        HashSet<Direccion> Direcciones) : IRequest<ErrorOr<Unit>>;
}
