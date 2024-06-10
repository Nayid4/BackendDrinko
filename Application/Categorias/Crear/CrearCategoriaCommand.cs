using Domain.Primitivos;
using MediatR;
using System;
using System.Collections.Generic;

namespace Application.Categorias.Crear
{
    public record CrearCategoriaCommand(
        string Nombre
        ) : IRequest<ErrorOr<Unit>>;
}
