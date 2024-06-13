using Application.CarritoDeCompras.Common;
using Application.Pedidos.Common;
using Domain.CarritoDeCompras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pedidos.Actualizar
{
    public record ActualizarPedidoCommand(
        Guid Id,
        Guid UsuarioId,
        Guid DireccionId,
        HashSet<ProductoPedidoResponse> Productos
    ) : IRequest<ErrorOr<Unit>>;
}
