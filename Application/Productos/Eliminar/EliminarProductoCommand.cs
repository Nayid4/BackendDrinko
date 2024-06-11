using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Productos.Eliminar
{
    public record EliminarProductoCommand(Guid Id) : IRequest<ErrorOr<Unit>>;
}
