using MediatR;
using ErrorOr;
using Domain.Categoria;
using System.Threading;
using System.Threading.Tasks;
using Application.Categorias.Common;

namespace Application.Categorias.ListarPorId
{
    public class ListarCategoriaPorIdQueryHandler : IRequestHandler<ListarCategoriaPorIdQuery, ErrorOr<CategoriaResponse>>
    {
        private readonly IRepositorioCategoria _repositorioCategoria;

        public ListarCategoriaPorIdQueryHandler(IRepositorioCategoria repositorioCategoria)
        {
            _repositorioCategoria = repositorioCategoria;
        }

        public async Task<ErrorOr<CategoriaResponse>> Handle(ListarCategoriaPorIdQuery request, CancellationToken cancellationToken)
        {
            var categoria = await _repositorioCategoria.ListarPorId(new CategoriaId(request.Id));
            if (categoria is null)
            {
                return Error.NotFound("Categoria.NoEncontrada", "No se encontró la categoría.");
            }

            var categoriaResponse = new CategoriaResponse(
                categoria.Id.Valor,
                categoria.Nombre);

            return categoriaResponse;
        }
    }
}
