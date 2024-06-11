using MediatR;
using ErrorOr;
using Domain.Categoria;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Categorias.VerificarExistencia
{
    public class VerificarExistenciaDeCategoriaQueryHandler : IRequestHandler<VerificarExistenciaDeCategoriaQuery, ErrorOr<bool>>
    {
        private readonly IRepositorioCategoria _repositorioCategoria;

        public VerificarExistenciaDeCategoriaQueryHandler(IRepositorioCategoria repositorioCategoria)
        {
            _repositorioCategoria = repositorioCategoria;
        }

        public async Task<ErrorOr<bool>> Handle(VerificarExistenciaDeCategoriaQuery request, CancellationToken cancellationToken)
        {
            if (!await _repositorioCategoria.VerificarExistencia(new CategoriaId(request.Id)))
            {
                return Error.NotFound("Categoria.NoEncontrada", "No se encontró la categoría.");
            }

            return true;
        }
    }
}
