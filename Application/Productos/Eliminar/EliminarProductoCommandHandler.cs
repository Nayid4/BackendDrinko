using Application.Usuarios.Eliminar;
using Domain.Primitivos;
using Domain.Productos;
using Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Productos.Eliminar
{
    internal sealed class EliminarProductoCommandHandler : IRequestHandler<EliminarProductoCommand, ErrorOr<Unit>>
    {
        private readonly IRepositorioProducto _repositorioProducto;
        private readonly IUnitOfWork _unitOfWork;

        public EliminarProductoCommandHandler(IRepositorioProducto repositorioProducto, IUnitOfWork unitOfWork)
        {
            _repositorioProducto = repositorioProducto ?? throw new ArgumentNullException(nameof(repositorioProducto));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }


        public async Task<ErrorOr<Unit>> Handle(EliminarProductoCommand command, CancellationToken cancellationToken)
        {
            if (await _repositorioProducto.ListarPorId(new ProductoId(command.Id)) is not Producto producto)
            {
                return Error.NotFound("Producto.NoEncontrado", "No se encontró el producto.");
            }

            _repositorioProducto.Eliminar(producto);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
