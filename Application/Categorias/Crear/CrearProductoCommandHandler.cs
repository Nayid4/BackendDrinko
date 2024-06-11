using MediatR;
using ErrorOr;
using Domain.Categoria;
using System.Threading;
using System.Threading.Tasks;
using Application.Categorias.Common;
using Domain.Primitivos;

namespace Application.Categorias.Crear
{
    public class CrearCategoriaCommandHandler : IRequestHandler<CrearCategoriaCommand, ErrorOr<CategoriaResponse>>
    {
        private readonly IRepositorioCategoria _repositorioCategoria;
        private readonly IUnitOfWork _unitOfWork;

        public CrearCategoriaCommandHandler(IRepositorioCategoria repositorioCategoria, IUnitOfWork unitOfWork)
        {
            _repositorioCategoria = repositorioCategoria;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<CategoriaResponse>> Handle(CrearCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoriaId = new CategoriaId(Guid.NewGuid());

            var categoria = new Categoria(categoriaId, request.Nombre);

            _repositorioCategoria.Crear(categoria);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var categoriaResponse = new CategoriaResponse(categoria.Id.Valor, categoria.Nombre);

            return categoriaResponse;
        }
    }
}
