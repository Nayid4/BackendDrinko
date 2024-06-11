using MediatR;
using ErrorOr;
using Domain.Categoria;
using System.Threading;
using System.Threading.Tasks;
using Domain.Primitivos;

namespace Application.Categorias.Eliminar
{
    public class EliminarCategoriaCommandHandler : IRequestHandler<EliminarCategoriaCommand, ErrorOr<Unit>>
    {
        private readonly IRepositorioCategoria _repositorioCategoria;
        private readonly IUnitOfWork _unitOfWork;

        public EliminarCategoriaCommandHandler(IRepositorioCategoria repositorioCategoria, IUnitOfWork unitOfWork)
        {
            _repositorioCategoria = repositorioCategoria;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<Unit>> Handle(EliminarCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoria = await _repositorioCategoria.ListarPorId(new CategoriaId(request.Id));

            if (categoria is null)
            {
                return Error.NotFound("Categoria.NoEncontrada", "No se encontró la categoría.");
            }

            _repositorioCategoria.Eliminar(categoria);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
