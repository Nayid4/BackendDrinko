using Domain.CarritoDeCompras;
using Domain.Primitivos;
using Domain.Productos;
using Domain.Usuarios;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CarritosDeCompras.Actualizar
{
    internal sealed class ActualizarCarritoDeComprasCommandHandler : IRequestHandler<ActualizarCarritoDeComprasCommand, ErrorOr<Unit>>
    {
        private readonly IRepositorioCarritoDeCompras _repositorioCarritoDeCompras;
        private readonly IUnitOfWork _unitOfWork;

        public ActualizarCarritoDeComprasCommandHandler(IRepositorioCarritoDeCompras repositorioCarritoDeCompras, IUnitOfWork unitOfWork)
        {
            _repositorioCarritoDeCompras = repositorioCarritoDeCompras ?? throw new ArgumentNullException(nameof(repositorioCarritoDeCompras));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(ActualizarCarritoDeComprasCommand request, CancellationToken cancellationToken)
        {
            if (!await _repositorioCarritoDeCompras.VerificarExistencia(new CarritoDeComprasId(request.Id)))
            {
                return Error.NotFound("CarritoDeCompras.NoEncontrado", "No se encontró el carrito de compras.");
            }

            var productosCarrito = request.Productos.Select(p =>
                new ProductoCarrito(
                    new ProductoCarritoId(Guid.NewGuid()),
                    new CarritoDeComprasId(request.Id),
                    new ProductoId(p.ProductoId),
                    p.Imagen,
                    p.Cantidad,
                    p.Precio))
                .ToHashSet();

            var carritoDeCompras = CarritoDeCompra.Crear(new UsuarioId(request.UsuarioId));
            foreach (var productoCarrito in productosCarrito)
            {
                carritoDeCompras.AgregarProducto(productoCarrito.ProductoId, productoCarrito.Imagen, productoCarrito.Cantidad, productoCarrito.Precio);
            }


            _repositorioCarritoDeCompras.Actualizar(carritoDeCompras);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
