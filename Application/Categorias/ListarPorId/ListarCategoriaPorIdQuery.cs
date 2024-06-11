using MediatR;
using ErrorOr;
using Application.Categorias.Common;
using System;

namespace Application.Categorias.ListarPorId
{
    public record ListarCategoriaPorIdQuery(Guid Id) : IRequest<ErrorOr<CategoriaResponse>>;
}
