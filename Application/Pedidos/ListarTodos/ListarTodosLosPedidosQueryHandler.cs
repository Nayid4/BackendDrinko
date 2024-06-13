using Application.CarritoDeCompras.Common;
using Application.Categorias.Common;
using Application.Pedidos.Common;
using Application.Productos.Common;
using Domain.CarritoDeCompras;
using Domain.Categoria;
using Domain.Pedidos;
using Domain.Primitivos;
using Domain.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pedidos.ListarTodos
{
    internal class ListarTodosLosPedidosQueryHandler : IRequestHandler<ListarTodosLosPedidosQuery, ErrorOr<IReadOnlyList<PedidoResponse>>>
    {
        private readonly IRepositorioPedido _repositorioPedido;

        public ListarTodosLosPedidosQueryHandler(IRepositorioPedido repositorioPedido, IUnitOfWork unitOfWork)
        {
            _repositorioPedido = repositorioPedido ?? throw new ArgumentNullException(nameof(repositorioPedido));
        }

        public async Task<ErrorOr<IReadOnlyList<PedidoResponse>>> Handle(ListarTodosLosPedidosQuery request, CancellationToken cancellationToken)
        {
            var pedidos = await _repositorioPedido.ListarTodos();

            var pedidoResponses = pedidos.Select(pedido => new PedidoResponse(
                pedido.Id.Valor,
                pedido.UsuarioId.Valor,
                pedido.DireccionId.Valor,
                pedido.ProductosPedido.Select(producto => new ProductoPedidoResponse(
                    producto.Id.Valor,
                    producto.PedidoId.Valor,
                    producto.Imagen,
                    producto.Cantidad,
                    producto.Precio
                    )).ToList())).ToList();

            return pedidoResponses;
        }
    }
}
