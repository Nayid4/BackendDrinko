using Domain.Categoria;
using Domain.Primitivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Productos
{
    public sealed class Producto : AggregateRoot
    {
        public ProductoId Id { get; private set; }
        public string Nombre { get; private set; } = string.Empty;
        public string Descripcion { get; private set; } = string.Empty;
        public CategoriaId CategoriaId { get; private set; } 
        public int Mililitros { get; private set; }
        public decimal Precio { get; private set; }
        public float GradosDeAlcohol { get; private set; }
        public float Calificacion { get; private set; }


        public Producto()
        {
        }

        public Producto(ProductoId id, string nombre, string descripcion, CategoriaId categoriaId, int mililitros, decimal precio, float gradosDeAlcohol, float calificacion)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Nombre = !string.IsNullOrEmpty(nombre) ? nombre : throw new ArgumentNullException(nameof(nombre));
            Descripcion = !string.IsNullOrEmpty(descripcion) ? descripcion : throw new ArgumentNullException(nameof(descripcion));
            CategoriaId = categoriaId ?? throw new ArgumentNullException(nameof(categoriaId));
            Mililitros = mililitros > 0 ? mililitros : throw new ArgumentOutOfRangeException(nameof(mililitros));
            Precio = precio > 0 ? precio : throw new ArgumentOutOfRangeException(nameof(precio));
            GradosDeAlcohol = gradosDeAlcohol >= 0 ? gradosDeAlcohol : throw new ArgumentOutOfRangeException(nameof(gradosDeAlcohol));
            Calificacion = calificacion >= 0 ? calificacion : throw new ArgumentOutOfRangeException(nameof(calificacion));
        }

    }


}
