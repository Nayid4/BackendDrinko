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

namespace Application.Pedidos.VerificarExistencia
{
    internal sealed class VerificarExistenciaPedidoQueryHandler : IRequestHandler<VerificarExistenciaPedidoQuery, ErrorOr<bool>>
    {

        private readonly IRepositorioPedido _repositorioPedido;

        public VerificarExistenciaPedidoQueryHandler(IRepositorioPedido repositorioPedido, IUnitOfWork unitOfWork)
        {
            _repositorioPedido = repositorioPedido ?? throw new ArgumentNullException(nameof(repositorioPedido));
        }

        public async Task<ErrorOr<bool>> Handle(VerificarExistenciaPedidoQuery request, CancellationToken cancellationToken)
        {
            var pedido = await _repositorioPedido.VerificarExistencia(new PedidoId(request.Id));
            if (pedido == false)
            {
                return Error.NotFound("Pedido.NoEncontrado", "No se encontró el pedido.");
            }

            

            return true;
        }
    }
}
