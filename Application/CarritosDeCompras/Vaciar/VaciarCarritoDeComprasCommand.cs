using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CarritosDeCompras.Vaciar
{
    public record VaciarCarritoDeComprasCommand(Guid CarritoId) : IRequest<ErrorOr<bool>>;
}
