using Domain.Categoria;
using Domain.Primitivos;
using Domain.Productos;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Categorias.Crear
{
    internal sealed class CrearProductoCommandHandler : IRequestHandler<CrearCategoriaCommand, ErrorOr<Unit>>
    {
        private readonly IRepositorioCategoria _repositorioCategoria;
        private readonly IUnitOfWork _unitOfWork;

        public CrearProductoCommandHandler(IRepositorioCategoria repositorioCategoria, IUnitOfWork unitOfWork)
        {
            _repositorioCategoria = repositorioCategoria ?? throw new ArgumentNullException(nameof(repositorioCategoria));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(CrearCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoria = new Categoria(
                new CategoriaId(Guid.NewGuid()),
                request.Nombre
            );

            _repositorioCategoria.Crear(categoria);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
