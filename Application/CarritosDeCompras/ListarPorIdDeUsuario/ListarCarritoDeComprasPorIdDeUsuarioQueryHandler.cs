using Application.CarritoDeCompras.Common;
using Application.Usuarios.Common;
using Domain.CarritoDeCompras;
using Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CarritosDeCompras.ListarPorIdDeUsuario
{
    internal sealed class ListarCarritoDeComprasPorIdDeUsuarioQueryHandler : IRequestHandler<ListarCarritoDeComprasPorIdDeUsuarioQuery, ErrorOr<CarritoDeComprasResponse>>
    {

        private readonly IRepositorioCarritoDeCompras _repositorioCarritoDeCompras;

        public ListarCarritoDeComprasPorIdDeUsuarioQueryHandler(IRepositorioCarritoDeCompras repositorioCarritoDeCompras)
        {
            _repositorioCarritoDeCompras = repositorioCarritoDeCompras ?? throw new ArgumentNullException(nameof(repositorioCarritoDeCompras));
        }

        public async Task<ErrorOr<CarritoDeComprasResponse>> Handle(ListarCarritoDeComprasPorIdDeUsuarioQuery request, CancellationToken cancellationToken)
        {
            var carrito = await _repositorioCarritoDeCompras.ListarPorIdDeUsuario(new UsuarioId(request.Id));
            if (carrito is null)
            {
                return Error.NotFound("CarritoDeCompra.NoEncontrado", "No se encontró el carrito de compras.");
            }

            var productos = carrito.ProductoCarritos.Select(p => new ProductoCarritoResponse(
                p.Id.Valor,
                p.ProductoId.Valor,
                p.Imagen,
                p.Cantidad,
                p.Precio
                )).ToList();

            var CarritoDeComprasResponse = new CarritoDeComprasResponse(
                carrito.Id.Valor,
                carrito.UsuarioId.Valor,
                productos);

            return CarritoDeComprasResponse;
        }
    }
}
