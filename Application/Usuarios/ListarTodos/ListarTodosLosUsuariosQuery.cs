using Application.Usuarios.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Usuarios.ListarTodos
{
    public record ListarTodosLosUsuariosQuery() : IRequest<ErrorOr<IReadOnlyList<UsuarioResponse>>>;
}
