using Domain.CarritoDeCompras;
using Domain.Primitivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CarritosDeCompras.Vaciar
{
    internal sealed class VaciarCarritoDeComprasCommandHandler : IRequestHandler<VaciarCarritoDeComprasCommand, ErrorOr<bool>>
    {
        private readonly IRepositorioCarritoDeCompras _repositorioCarritoDeCompras;
        private readonly IUnitOfWork _unitOfWork;

        public VaciarCarritoDeComprasCommandHandler(IRepositorioCarritoDeCompras repositorioCarritoDeCompras, IUnitOfWork unitOfWork)
        {
            _repositorioCarritoDeCompras = repositorioCarritoDeCompras ?? throw new ArgumentNullException(nameof(repositorioCarritoDeCompras));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<bool>> Handle(VaciarCarritoDeComprasCommand request, CancellationToken cancellationToken)
        {
            var carrito = await _repositorioCarritoDeCompras.ListarPorId(new CarritoDeComprasId(request.CarritoId));
            if (carrito is null)
            {
                return Error.NotFound("CarritoDeCompra.NoEncontrado", "No se encontró el carrito de compras.");
            }

            carrito.Vaciar();

            _repositorioCarritoDeCompras.Actualizar(carrito);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
