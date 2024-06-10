using Application.Categorias.Common;
using Application.Productos.Common;
using Domain.Categoria;
using Domain.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.categorias.ListarTodos
{
    internal class ListarTodasLasCategoriasQueryHandler : IRequestHandler<ListarTodasLasCategoriasQuery, ErrorOr<IReadOnlyList<CategoriaResponse>>>
    {
        private readonly IRepositorioCategoria _repositorioCategoria;

        public ListarTodasLasCategoriasQueryHandler(IRepositorioCategoria repositorioCategoria)
        {
            _repositorioCategoria = repositorioCategoria;
        }

        public async Task<ErrorOr<IReadOnlyList<CategoriaResponse>>> Handle(ListarTodasLasCategoriasQuery request, CancellationToken cancellationToken)
        {
            var categorias = await _repositorioCategoria.ListarTodos();

            var categoriaResponses = categorias.Select(categoria => new CategoriaResponse(
                categoria.Id.Valor,
                categoria.Nombre)
                
            ).ToList();

            return categoriaResponses;
        }
    }
}
