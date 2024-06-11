using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CarritosDeCompras.EliminarProducto
{
    public record EliminarProductoCommand(
        Guid Id,
        Guid IdCarrito
        ) : IRequest<ErrorOr<bool>>;
}
