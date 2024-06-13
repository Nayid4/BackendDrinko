using Application.CarritosDeCompras.Crear;
using Domain.CarritoDeCompras;
using Domain.Direcciones;
using Domain.Pedidos;
using Domain.Primitivos;
using Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pedidos.Crear
{
    internal sealed class CrearPedidoCommandHandler : IRequestHandler<CrearPedidoCommand, ErrorOr<Unit>>
    {
        private readonly IRepositorioPedido _repositorioPedido;
        private readonly IUnitOfWork _unitOfWork;

        public CrearPedidoCommandHandler(IRepositorioPedido repositorioPedido, IUnitOfWork unitOfWork)
        {
            _repositorioPedido = repositorioPedido ?? throw new ArgumentNullException(nameof(repositorioPedido));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(CrearPedidoCommand command, CancellationToken cancellationToken)
        {
            var carrito = Pedido.Crear(new UsuarioId(command.UsuarioId), new DireccionId(command.DireccionId));
            _repositorioPedido.Crear(carrito);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
