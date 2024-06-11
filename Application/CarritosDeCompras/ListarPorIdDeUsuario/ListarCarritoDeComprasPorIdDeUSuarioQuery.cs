using Application.CarritoDeCompras.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CarritosDeCompras.ListarPorIdDeUsuario
{
    public record ListarCarritoDeComprasPorIdDeUsuarioQuery(Guid Id) : IRequest<ErrorOr<CarritoDeComprasResponse>>;
}
