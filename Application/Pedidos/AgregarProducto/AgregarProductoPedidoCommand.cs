using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pedidos.AgregarProducto
{
    public record AgregarProductoPedidoCommand(
        Guid IdPedido,
        Guid ProductoId,
        string imagen,
        int Cantidad,
        decimal Precio
        ) : IRequest<ErrorOr<bool>>;
}
