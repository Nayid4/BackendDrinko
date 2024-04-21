using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Usuarios.Crear
{
    public record CommandCrearUsuario(
        string Nombre,
        string Apellido,
        string Correo,
        string NumeroDeTelefono,
        string Pais,
        string Linea1,
        string Linea2,
        string Ciudad,
        string Estado,
        string CodigoPostal
    ) : IRequest<Unit>;
}
