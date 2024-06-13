using Application.CarritoDeCompras.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pedidos.VerificarExistencia
{
    public record VerificarExistenciaPedidoQuery(Guid Id) : IRequest<ErrorOr<bool>>;
}
