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

namespace Application.Pedidos.ListarPorId
{
    internal sealed class ListarPedidoPorIdQueryHandler : IRequestHandler<ListarPedidoPorIdQuery, ErrorOr<PedidoResponse>>
    {

        private readonly IRepositorioPedido _repositorioPedido;

        public ListarPedidoPorIdQueryHandler(IRepositorioPedido repositorioPedido, IUnitOfWork unitOfWork)
        {
            _repositorioPedido = repositorioPedido ?? throw new ArgumentNullException(nameof(repositorioPedido));
        }

        public async Task<ErrorOr<PedidoResponse>> Handle(ListarPedidoPorIdQuery request, CancellationToken cancellationToken)
        {
            var pedido = await _repositorioPedido.ListarPorId(new PedidoId(request.Id));
            if (pedido is null)
            {
                return Error.NotFound("Pedido.NoEncontrado", "No se encontró el pedido.");
            }

            var productos = pedido.ProductosPedido.Select(p => new ProductoPedidoResponse(
                p.Id.Valor,
                p.ProductoId.Valor,
                p.Imagen,
                p.Cantidad,
                p.Precio
                )).ToList();

            var PedidoResponse = new PedidoResponse(
                pedido.Id.Valor,
                pedido.UsuarioId.Valor,
                pedido.DireccionId.Valor,
                productos);

            return PedidoResponse;
        }
    }
}
