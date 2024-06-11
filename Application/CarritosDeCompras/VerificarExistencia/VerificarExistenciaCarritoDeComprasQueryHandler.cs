using Application.CarritoDeCompras.Common;
using Application.Usuarios.Common;
using Domain.CarritoDeCompras;
using Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CarritosDeCompras.VerificarExistencia
{
    internal sealed class VerificarExistenciaCarritoDeComprasQueryHandler : IRequestHandler<VerificarExistenciaCarritoDeComprasQuery, ErrorOr<bool>>
    {

        private readonly IRepositorioCarritoDeCompras _repositorioCarritoDeCompras;

        public VerificarExistenciaCarritoDeComprasQueryHandler(IRepositorioCarritoDeCompras repositorioCarritoDeCompras)
        {
            _repositorioCarritoDeCompras = repositorioCarritoDeCompras ?? throw new ArgumentNullException(nameof(repositorioCarritoDeCompras));
        }

        public async Task<ErrorOr<bool>> Handle(VerificarExistenciaCarritoDeComprasQuery request, CancellationToken cancellationToken)
        {
            var carrito = await _repositorioCarritoDeCompras.VerificarExistencia(new CarritoDeComprasId(request.Id));
            if (carrito == false)
            {
                return Error.NotFound("CarritoDeCompra.NoEncontrado", "No se encontró el carrito de compras.");
            }

            

            return true;
        }
    }
}
