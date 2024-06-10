using Application.Categorias.Common;
using Application.Productos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.categorias.ListarTodos
{
    public record ListarTodasLasCategoriasQuery() : IRequest<ErrorOr<IReadOnlyList<CategoriaResponse>>>;
    
}
