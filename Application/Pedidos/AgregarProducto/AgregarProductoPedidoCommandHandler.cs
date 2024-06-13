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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.Pedidos.AgregarProducto
{
    internal sealed class AgregarProductoPedidoCommandHandler : IRequestHandler<AgregarProductoPedidoCommand, ErrorOr<bool>>
    {
        private readonly IRepositorioPedido _repositorioPedido;
        private readonly IUnitOfWork _unitOfWork;

        public AgregarProductoPedidoCommandHandler(IRepositorioPedido repositorioPedido, IUnitOfWork unitOfWork)
        {
            _repositorioPedido = repositorioPedido ?? throw new ArgumentNullException(nameof(repositorioPedido));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<bool>> Handle(AgregarProductoPedidoCommand command, CancellationToken cancellationToken)
        {
            if (await _repositorioPedido.ListarPorId(new PedidoId(command.IdPedido)) is not Pedido pedido)
            {
                return Error.NotFound("Pedido.NoEncontrado", "No se encontró el Pedido.");
            }

            pedido.AgregarProducto(new ProductoId(command.ProductoId), command.imagen, command.Cantidad, command.Precio);

            _repositorioPedido.Actualizar(pedido);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
