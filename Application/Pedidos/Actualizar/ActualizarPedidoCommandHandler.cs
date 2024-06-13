using Domain.CarritoDeCompras;
using Domain.Direcciones;
using Domain.Pedidos;
using Domain.Primitivos;
using Domain.Productos;
using Domain.Usuarios;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Pedidos.Actualizar
{
    internal sealed class ActualizarPedidoCommandHandler : IRequestHandler<ActualizarPedidoCommand, ErrorOr<Unit>>
    {
        private readonly IRepositorioPedido _repositorioPedido;
        private readonly IUnitOfWork _unitOfWork;

        public ActualizarPedidoCommandHandler(IRepositorioPedido repositorioPedido, IUnitOfWork unitOfWork)
        {
            _repositorioPedido = repositorioPedido ?? throw new ArgumentNullException(nameof(repositorioPedido));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(ActualizarPedidoCommand command, CancellationToken cancellationToken)
        {
            if (!await _repositorioPedido.VerificarExistencia(new PedidoId(command.Id)))
            {
                return Error.NotFound("Pedido.NoEncontrado", "No se encontró el Pedido.");
            }

            var productosPedido = command.Productos.Select(p =>
                new ProductoPedido(
                    new ProductoPedidoId(Guid.NewGuid()),
                    new PedidoId(command.Id),
                    new ProductoId(p.ProductoId),
                    p.Imagen,
                    p.Cantidad,
                    p.Precio))
                .ToHashSet();

            var pedido = Pedido.Crear(new UsuarioId(command.UsuarioId), new DireccionId(command.DireccionId));
            foreach (var producto in productosPedido)
            {
                pedido.AgregarProducto(producto.ProductoId, producto.Imagen, producto.Cantidad, producto.Precio);
            }


            _repositorioPedido.Actualizar(pedido);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
