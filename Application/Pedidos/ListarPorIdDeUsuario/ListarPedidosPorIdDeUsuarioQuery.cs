using Application.CarritoDeCompras.Common;
using Application.Pedidos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pedidos.ListarPorIdDeUsuario
{
    public record ListarPedidosPorIdDeUsuarioQuery(Guid UsuarioId) : IRequest<ErrorOr<IReadOnlyList<PedidoResponse>>>;
}
