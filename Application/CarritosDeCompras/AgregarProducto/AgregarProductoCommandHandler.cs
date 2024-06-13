using Domain.CarritoDeCompras;
using Domain.Primitivos;
using Domain.Productos;
using Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.CarritosDeCompras.AgregarProducto
{
    internal sealed class AgregarProductoCommandHandler : IRequestHandler<AgregarProductoCommand, ErrorOr<bool>>
    {
        private readonly IRepositorioCarritoDeCompras _repositorioCarritoDeCompras;
        private readonly IUnitOfWork _unitOfWork;

        public AgregarProductoCommandHandler(IRepositorioCarritoDeCompras repositorioCarritoDeCompras, IUnitOfWork unitOfWork)
        {
            _repositorioCarritoDeCompras = repositorioCarritoDeCompras ?? throw new ArgumentNullException(nameof(repositorioCarritoDeCompras));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<bool>> Handle(AgregarProductoCommand command, CancellationToken cancellationToken)
        {
            if (await _repositorioCarritoDeCompras.ListarPorId(new CarritoDeComprasId(command.IdCarrito)) is not CarritoDeCompra carritoDeCompra)
            {
                return Error.NotFound("CarritoDeCompras.NoEncontrado", "No se encontró el carrito de compras.");
            }

            carritoDeCompra.AgregarProducto(new ProductoId(command.ProductoId), command.imagen, command.Cantidad, command.Precio);

            _repositorioCarritoDeCompras.Actualizar(carritoDeCompra);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
