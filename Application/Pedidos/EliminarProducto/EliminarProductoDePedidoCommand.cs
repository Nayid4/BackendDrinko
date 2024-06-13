using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pedidos.EliminarProducto
{
    public record EliminarProductoDePedidoCommand(
        Guid PedidoId,
        Guid ProductoPedidoId
        ) : IRequest<ErrorOr<bool>>;
}
