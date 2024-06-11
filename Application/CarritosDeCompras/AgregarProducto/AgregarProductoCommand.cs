using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CarritosDeCompras.AgregarProducto
{
    public record AgregarProductoCommand(
        Guid IdCarrito,
        Guid ProductoId,
        int Cantidad,
        decimal Precio
        ) : IRequest<ErrorOr<bool>>;
}
