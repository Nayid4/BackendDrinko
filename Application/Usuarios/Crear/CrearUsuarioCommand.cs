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
        string NumeroDeTelefono,
        HashSet<Direccion> Direcciones) : IRequest<UsuarioId>;
}
