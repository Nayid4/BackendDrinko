using Domain.ObjetosDeValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Usuarios.IniciarSesion
{
    public record IniciarSesionCommand(string Correo, string Clave) : IRequest<ErrorOr<IniciarSesionResult>>;
}
