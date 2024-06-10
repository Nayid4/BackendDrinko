using Application.Usuarios.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Usuarios.VerificarExistencia
{
    public record VerificarExistenciaDelUsuarioQuery(Guid Id) : IRequest<ErrorOr<bool>>;
}
