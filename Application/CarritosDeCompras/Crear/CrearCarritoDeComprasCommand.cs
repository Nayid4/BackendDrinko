using Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CarritosDeCompras.Crear
{
    public record CrearCarritoDeComprasCommand(Guid UsuarioId) : IRequest<ErrorOr<Unit>>;
}
