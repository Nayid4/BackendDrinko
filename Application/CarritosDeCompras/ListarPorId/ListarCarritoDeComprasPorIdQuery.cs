using Application.CarritoDeCompras.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CarritosDeCompras.ListarPorId
{
    public record ListarCarritoDeComprasPorIdQuery(Guid Id) : IRequest<ErrorOr<CarritoDeComprasResponse>>;
}
