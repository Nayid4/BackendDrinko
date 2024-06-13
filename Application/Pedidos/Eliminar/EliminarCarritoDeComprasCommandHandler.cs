using Application.CarritoDeCompras.Common;
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

namespace Application.Pedidos.Eliminar
{
    internal sealed class EliminarPedidoCommandHandler : IRequestHandler<EliminarPedidoCommand, ErrorOr<bool>>
    {

        private readonly IRepositorioPedido _repositorioPedido;
        private readonly IUnitOfWork _unitOfWork;

        public EliminarPedidoCommandHandler(IRepositorioPedido repositorioPedido, IUnitOfWork unitOfWork)
        {
            _repositorioPedido = repositorioPedido ?? throw new ArgumentNullException(nameof(repositorioPedido));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<bool>> Handle(EliminarPedidoCommand command, CancellationToken cancellationToken)
        {
            var pedido = await _repositorioPedido.ListarPorId(new PedidoId(command.PedidoId));
            if (pedido is null)
            {
                return Error.NotFound("Pedido.NoEncontrado", "No se encontró el Pedido.");
            }

            _repositorioPedido.Eliminar(pedido);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
