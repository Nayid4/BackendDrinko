using Application.Productos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Productos.ListarPorId
{
    public record ListarProductoPorIdQuery(Guid Id) : IRequest<ErrorOr<ProductoResponse>>;
}
