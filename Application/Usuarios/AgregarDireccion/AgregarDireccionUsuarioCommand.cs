using Application.Usuarios.Common;
using Domain.Direcciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Usuarios.AgregarDireccion
{
    public record AgregarDireccionUsuarioCommand(
        Guid usuarioId,
        DireccionCommand Direccion
        ) : IRequest<ErrorOr<bool>>;
}
