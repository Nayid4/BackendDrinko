using Application.CarritoDeCompras.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CarritosDeCompras.VerificarExistencia
{
    public record VerificarExistenciaCarritoDeComprasQuery(Guid Id) : IRequest<ErrorOr<bool>>;
}
