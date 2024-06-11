using MediatR;
using ErrorOr;
using Domain.Categoria;
using Domain.Productos;
using System.Threading;
using System.Threading.Tasks;
using Domain.Primitivos;

namespace Application.Productos.Actualizar
{
    internal sealed class ActualizarProductoCommandHandler : IRequestHandler<ActualizarProductoCommand, ErrorOr<Unit>>
    {
        private readonly IRepositorioProducto _repositorioProducto;
        private readonly IRepositorioCategoria _repositorioCategoria;
        private readonly IUnitOfWork _unitOfWork;

        public ActualizarProductoCommandHandler(IRepositorioProducto repositorioProducto, IRepositorioCategoria repositorioCategoria,  IUnitOfWork unitOfWork)
        {
            _repositorioProducto = repositorioProducto ?? throw new ArgumentNullException(nameof(repositorioProducto));
            _repositorioCategoria = repositorioCategoria ?? throw new ArgumentNullException(nameof(repositorioCategoria));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(ActualizarProductoCommand request, CancellationToken cancellationToken)
        {
            if (!await _repositorioProducto.VerificarExistencia(new ProductoId(request.Id)))
            {
                return Error.NotFound("Producto.NoEncontrado", "No se encontró el producto.");
            }

            if (!await _repositorioCategoria.VerificarExistencia(new CategoriaId(request.CategoriaId)))
            {
                return Error.NotFound("Categoria.NoEncontrada", "No se encontró la categoría.");
            }

            var producto = new Producto(
                new ProductoId(request.Id),
                request.Nombre,
                new CategoriaId(request.CategoriaId),
                request.Imagen,
                request.Descripcion,
                request.Mililitros,
                request.GradosDeAlcohol,
                request.Calificacion,
                request.Precio
            );

            _repositorioProducto.Actualizar(producto);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
