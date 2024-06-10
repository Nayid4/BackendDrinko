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
        public CategoriaId CategoriaId { get; private set; }
        public string Imagen { get; private set; } = string.Empty;
        public string Descripcion { get; private set; } = string.Empty;
        public int Mililitros { get; private set; }
        public float GradosDeAlcohol { get; private set; }
        public float Calificacion { get; private set; }
        public decimal Precio { get; private set; }


        public Producto()
        {
            
        }

        public Producto(ProductoId id, string nombre, CategoriaId categoriaId, string imagen, string descripcion, int mililitros, float gradosDeAlcohol, float calificacion, decimal precio)
        {
            Id = id;
            Nombre = nombre;
            CategoriaId = categoriaId;
            Imagen = imagen;
            Descripcion = descripcion;
            Mililitros = mililitros;
            GradosDeAlcohol = gradosDeAlcohol;
            Calificacion = calificacion;
            Precio = precio;
        }

    }


}
