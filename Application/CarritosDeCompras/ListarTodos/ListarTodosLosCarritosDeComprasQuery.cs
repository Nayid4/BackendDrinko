using Application.CarritoDeCompras.Common;
using Application.Categorias.Common;
using Application.Productos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CarritosDeCompras.ListarTodos
{
    public record ListarTodosLosCarritosDeComprasQuery() : IRequest<ErrorOr<IReadOnlyList<CarritoDeComprasResponse>>>;
    
}
