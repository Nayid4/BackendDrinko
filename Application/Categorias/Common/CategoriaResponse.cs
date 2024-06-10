using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categorias.Common
{
    public record CategoriaResponse(
        Guid Id,
        string Nombre
    );
}
