using MediatR;
using ErrorOr;
using Domain.Categoria;
using System.Threading;
using System.Threading.Tasks;
using Domain.Primitivos;

namespace Application.Categorias.Actualizar
{
    public class ActualizarCategoriaCommandHandler : IRequestHandler<ActualizarCategoriaCommand, ErrorOr<Unit>>
    {
        private readonly IRepositorioCategoria _repositorioCategoria;
        private readonly IUnitOfWork _unitOfWork;

        public ActualizarCategoriaCommandHandler(IRepositorioCategoria repositorioCategoria, IUnitOfWork unitOfWork)
        {
            _repositorioCategoria = repositorioCategoria;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<Unit>> Handle(ActualizarCategoriaCommand request, CancellationToken cancellationToken)
        {
            if (!await _repositorioCategoria.VerificarExistencia(new CategoriaId(request.Id)))
            {
                return Error.NotFound("Categoria.NoEncontrada", "No se encontró la categoría.");
            }

            var categoria = new Categoria(new CategoriaId(request.Id), request.Nombre);
            _repositorioCategoria.Actualizar(categoria);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
