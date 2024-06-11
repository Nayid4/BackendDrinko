using MediatR;
using ErrorOr;
using System;

namespace Application.Categorias.Actualizar
{
    public record ActualizarCategoriaCommand(
        Guid Id,
        string Nombre
    ) : IRequest<ErrorOr<Unit>>;
}
