using Domain.CarritoDeCompras;
using Domain.Primitivos;
using Domain.Productos;
using Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CarritosDeCompras.EliminarProducto
{
    internal sealed class EliminarProductoCommandHandler : IRequestHandler<EliminarProductoCommand, ErrorOr<bool>>
    {
        private readonly IRepositorioCarritoDeCompras _repositorioCarritoDeCompras;
        private readonly IUnitOfWork _unitOfWork;

        public EliminarProductoCommandHandler(IRepositorioCarritoDeCompras repositorioCarritoDeCompras, IUnitOfWork unitOfWork)
        {
            _repositorioCarritoDeCompras = repositorioCarritoDeCompras ?? throw new ArgumentNullException(nameof(repositorioCarritoDeCompras));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<bool>> Handle(EliminarProductoCommand command, CancellationToken cancellationToken)
        {
            if (await _repositorioCarritoDeCompras.ListarPorId(new CarritoDeComprasId(command.IdCarrito)) is not CarritoDeCompra carritoDeCompra)
            {
                return Error.NotFound("CarritoDeCompras.NoEncontrado", "No se encontró el carrito de compras.");
            }

            carritoDeCompra.EliminarProducto(new ProductoCarritoId(command.Id));

            _repositorioCarritoDeCompras.Actualizar(carritoDeCompra);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
