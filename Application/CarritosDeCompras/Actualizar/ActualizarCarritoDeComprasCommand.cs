using Application.CarritoDeCompras.Common;
using Domain.CarritoDeCompras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CarritosDeCompras.Actualizar
{
    public record ActualizarCarritoDeComprasCommand(
        Guid Id,
        Guid UsuarioId,
        HashSet<ProductoCarritoResponse> Productos
    ) : IRequest<ErrorOr<Unit>>;
}
