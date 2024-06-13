using System;
using System.Collections.Generic;
using System.Linq;
using Application.Productos.Common;

namespace Application.Pedidos.Common
{
    public record PedidoResponse(
        Guid Id,
        Guid UsuarioId,
        Guid DireccionId,
        IReadOnlyList<ProductoPedidoResponse> Productos
    );

    public record ProductoPedidoResponse(
        Guid Id,
        Guid ProductoId,
        string Imagen,
        int Cantidad,
        decimal Precio
    );

}
