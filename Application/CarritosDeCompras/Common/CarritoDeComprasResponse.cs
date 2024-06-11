using System;
using System.Collections.Generic;
using System.Linq;
using Application.Productos.Common;

namespace Application.CarritoDeCompras.Common
{
    public record CarritoDeComprasResponse(
        Guid Id,
        Guid UsuarioId,
        IReadOnlyList<ProductoCarritoResponse> Productos
    );

    public record ProductoCarritoResponse(
        Guid Id,
        Guid ProductoId,
        int Cantidad,
        decimal Precio
    );

}
