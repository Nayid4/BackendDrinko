using Domain.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Productos.VerificarExistencia
{
    internal sealed class VerificarExistenciaDeProductoQueryHandler : IRequestHandler<VerificarExistenciaDeProductoQuery, ErrorOr<bool>>
    {
        private readonly IRepositorioProducto _repositorioProducto;

        public VerificarExistenciaDeProductoQueryHandler(IRepositorioProducto repositorioProducto)
        {
            _repositorioProducto = repositorioProducto ?? throw new ArgumentNullException(nameof(repositorioProducto));
        }

        public async Task<ErrorOr<bool>> Handle(VerificarExistenciaDeProductoQuery request, CancellationToken cancellationToken)
        {
            if (await _repositorioProducto.ListarPorId(new ProductoId(request.Id)) is not Producto producto)
            {
                return Error.NotFound("Producto.NoEncontrado", "No se encontró el producto.");
            }

            return true;
        }
    }
}
