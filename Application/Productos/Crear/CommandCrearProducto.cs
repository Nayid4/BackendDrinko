using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Productos.Crear
{
    public record CommandCrearProducto(
        string Nombre,
        string IdCategoria,
        string Imagen,
        string Descripcion,
        int Mililitros,
        float GradosDeAlcohol,
        float calificacion,
        decimal Precio
    ) : IRequest<Unit>;
}
