using Application.CarritoDeCompras.Common;
using Application.Pedidos.Common;
using Application.Usuarios.Common;
using Domain.CarritoDeCompras;
using Domain.Pedidos;
using Domain.Primitivos;
using Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pedidos.ListarPorIdDeUsuario
{
    internal sealed class ListarPedidosPorIdDeUsuarioQueryHandler : IRequestHandler<ListarPedidosPorIdDeUsuarioQuery, ErrorOr<IReadOnlyList<PedidoResponse>>>
    {

        private readonly IRepositorioPedido _repositorioPedido;

        public ListarPedidosPorIdDeUsuarioQueryHandler(IRepositorioPedido repositorioPedido, IUnitOfWork unitOfWork)
        {
            _repositorioPedido = repositorioPedido ?? throw new ArgumentNullException(nameof(repositorioPedido));
        }

        public async Task<ErrorOr<IReadOnlyList<PedidoResponse>>> Handle(ListarPedidosPorIdDeUsuarioQuery request, CancellationToken cancellationToken)
        {
            var pedidos = await _repositorioPedido.ListarTodos();

            // Filtrar los pedidos por el Id de Usuario
            var pedidosFiltrados = pedidos.Where(pedido => pedido.UsuarioId.Valor == request.UsuarioId).ToList();

            var pedidoResponses = pedidosFiltrados.Select(pedido => new PedidoResponse(
                pedido.Id.Valor,
                pedido.UsuarioId.Valor,
                pedido.DireccionId.Valor,
                pedido.ProductosPedido.Select(producto => new ProductoPedidoResponse(
                    producto.Id.Valor,
                    producto.PedidoId.Valor,
                    producto.Imagen,
                    producto.Cantidad,
                    producto.Precio
                )).ToList()
            )).ToList();

            return pedidoResponses;
        }
    }
}
