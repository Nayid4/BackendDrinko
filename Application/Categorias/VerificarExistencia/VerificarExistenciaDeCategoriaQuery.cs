using MediatR;
using ErrorOr;
using System;

namespace Application.Categorias.VerificarExistencia
{
    public record VerificarExistenciaDeCategoriaQuery(Guid Id) : IRequest<ErrorOr<bool>>;
}
