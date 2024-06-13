using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pedidos.Crear
{
    public record CrearPedidoCommand(
        Guid UsuarioId,
        Guid DireccionId
    ): IRequest<ErrorOr<Unit>>;
}
