using Application.Usuarios.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Usuarios.ListarPorId
{
    public record ListarUsuariosPorIdQuery(Guid Id) : IRequest<ErrorOr<UsuarioResponse>>;
}
