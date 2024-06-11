using Domain.CarritoDeCompras;
using Domain.Primitivos;
using Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CarritosDeCompras.Crear
{
    internal sealed class CrearCarritoDeComprasCommandHandler : IRequestHandler<CrearCarritoDeComprasCommand, ErrorOr<Unit>>
    {
        private readonly IRepositorioCarritoDeCompras _repositorioCarrito;
        private readonly IUnitOfWork _unitOfWork;

        public CrearCarritoDeComprasCommandHandler(IRepositorioCarritoDeCompras repositorioCarrito, IUnitOfWork unitOfWork)
        {
            _repositorioCarrito = repositorioCarrito ?? throw new ArgumentNullException(nameof(repositorioCarrito));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(CrearCarritoDeComprasCommand request, CancellationToken cancellationToken)
        {
            var carrito = CarritoDeCompra.Crear(new UsuarioId(request.UsuarioId));
            _repositorioCarrito.Crear(carrito);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
