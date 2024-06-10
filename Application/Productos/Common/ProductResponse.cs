using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Productos.Common
{
    public record ProductoResponse
    {
        public Guid Id { get; init; }
        public string Nombre { get; init; }
        public string CategoriaId { get; init; }
        public string Imagen { get; init; }
        public string Descripcion { get; init; }
        public int Mililitros { get; init; }
        public float GradosDeAlcohol { get; init; }
        public float Calificacion { get; init; }
        public decimal Precio { get; init; }
    }
}
