using Domain.CarritoDeCompras;
using Domain.Pedidos;
using Domain.Primitivos;
using Domain.Productos;
using Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pedidos.EliminarProducto
{
    internal sealed class EliminarProductoDePedidoCommandHandler : IRequestHandler<EliminarProductoDePedidoCommand, ErrorOr<bool>>
    {
        private readonly IRepositorioPedido _repositorioPedido;
        private readonly IUnitOfWork _unitOfWork;

        public EliminarProductoDePedidoCommandHandler(IRepositorioPedido repositorioPedido, IUnitOfWork unitOfWork)
        {
            _repositorioPedido = repositorioPedido ?? throw new ArgumentNullException(nameof(repositorioPedido));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<bool>> Handle(EliminarProductoDePedidoCommand command, CancellationToken cancellationToken)
        {
            if (await _repositorioPedido.ListarPorId(new PedidoId(command.PedidoId)) is not Pedido pedido)
            {
                return Error.NotFound("Pedido.NoEncontrado", "No se encontró el pedido.");
            }

            pedido.EliminarProducto(new ProductoPedidoId(command.ProductoPedidoId));

            _repositorioPedido.Actualizar(pedido);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
