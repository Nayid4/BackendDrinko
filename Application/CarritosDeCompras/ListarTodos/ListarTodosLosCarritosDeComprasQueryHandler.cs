using Application.CarritoDeCompras.Common;
using Application.Categorias.Common;
using Application.Productos.Common;
using Domain.CarritoDeCompras;
using Domain.Categoria;
using Domain.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CarritosDeCompras.ListarTodos
{
    internal class ListarTodosLosCarritoDeComprasQueryHandler : IRequestHandler<ListarTodosLosCarritosDeComprasQuery, ErrorOr<IReadOnlyList<CarritoDeComprasResponse>>>
    {
        private readonly IRepositorioCarritoDeCompras _repositorioCarritoDeCompras;

        public ListarTodosLosCarritoDeComprasQueryHandler(IRepositorioCarritoDeCompras repositorioCarritoDeCompras)
        {
            _repositorioCarritoDeCompras = repositorioCarritoDeCompras ?? throw new ArgumentNullException(nameof(repositorioCarritoDeCompras));
        }

        public async Task<ErrorOr<IReadOnlyList<CarritoDeComprasResponse>>> Handle(ListarTodosLosCarritosDeComprasQuery request, CancellationToken cancellationToken)
        {
            var carritosDeCompras = await _repositorioCarritoDeCompras.ListarTodos();

            var carritoDeComprasResponses = carritosDeCompras.Select(carrito => new CarritoDeComprasResponse(
                carrito.Id.Valor,
                carrito.UsuarioId.Valor,
                carrito.ProductoCarritos.Select(producto => new ProductoCarritoResponse(
                    producto.Id.Valor,
                    producto.CarritoDeComprasId.Valor,
                    producto.Imagen,
                    producto.Cantidad,
                    producto.Precio
                    )).ToList())).ToList();

            return carritoDeComprasResponses;
        }
    }
}
