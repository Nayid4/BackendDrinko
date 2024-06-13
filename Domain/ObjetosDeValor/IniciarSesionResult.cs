using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ObjetosDeValor
{
    public record IniciarSesionResult(Guid Id, string NombreCompre, string Rol,string Correo, string Token);
}
