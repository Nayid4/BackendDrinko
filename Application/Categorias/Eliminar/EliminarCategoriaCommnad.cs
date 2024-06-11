using MediatR;
using ErrorOr;
using System;

namespace Application.Categorias.Eliminar
{
    public record EliminarCategoriaCommand(Guid Id) : IRequest<ErrorOr<Unit>>;
}
