using Application.CarritoDeCompras.Common;
using Application.Usuarios.Common;
using Domain.CarritoDeCompras;
using Domain.Primitivos;
using Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CarritosDeCompras.Eliminar
{
    internal sealed class EliminarCarritoDeComprasCommandHandler : IRequestHandler<EliminarCarritoDeComprasCommand, ErrorOr<bool>>
    {

        private readonly IRepositorioCarritoDeCompras _repositorioCarritoDeCompras;
        private readonly IUnitOfWork _unitOfWork;

        public EliminarCarritoDeComprasCommandHandler(IRepositorioCarritoDeCompras repositorioCarritoDeCompras, IUnitOfWork unitOfWork)
        {
            _repositorioCarritoDeCompras = repositorioCarritoDeCompras ?? throw new ArgumentNullException(nameof(repositorioCarritoDeCompras));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<bool>> Handle(EliminarCarritoDeComprasCommand request, CancellationToken cancellationToken)
        {
            var carrito = await _repositorioCarritoDeCompras.ListarPorId(new CarritoDeComprasId(request.Id));
            if (carrito is null)
            {
                return Error.NotFound("CarritoDeCompra.NoEncontrado", "No se encontró el carrito de compras.");
            }

            _repositorioCarritoDeCompras.Eliminar(carrito);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
