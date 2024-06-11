using MediatR;
using ErrorOr;
using Application.Categorias.Common;
using System;

namespace Application.Categorias.Crear
{
    public record CrearCategoriaCommand(
        string Nombre
    ) : IRequest<ErrorOr<CategoriaResponse>>;
}
