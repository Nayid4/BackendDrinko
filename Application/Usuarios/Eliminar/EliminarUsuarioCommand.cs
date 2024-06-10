using Domain.Usuarios;
using MediatR;

namespace Application.Usuarios.Eliminar
{
    public record EliminarUsuarioCommand(Guid Id) : IRequest<ErrorOr<Unit>>;
}
