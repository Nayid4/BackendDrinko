using Application.CarritoDeCompras.Common;
using Application.Pedidos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pedidos.ListarPorId
{
    public record ListarPedidoPorIdQuery(Guid Id) : IRequest<ErrorOr<PedidoResponse>>;
}
