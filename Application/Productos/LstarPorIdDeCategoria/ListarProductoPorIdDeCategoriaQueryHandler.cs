using Application.Productos.Common;
using Application.Productos.ListarTodos;
using Domain.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.Productos.ListarPorIdDeCategoria
{
    internal sealed class ListarProductoPorIdDeCategoriaQueryHandler : IRequestHandler<ListarProductoPorIdDeCategoriaQuery, ErrorOr<IReadOnlyList<ProductoResponse>>>
    {
        private readonly IRepositorioProducto _repositorioProducto;

        public ListarProductoPorIdDeCategoriaQueryHandler(IRepositorioProducto repositorioProducto)
        {
            _repositorioProducto = repositorioProducto ?? throw new ArgumentNullException(nameof(repositorioProducto));
        }

        public async Task<ErrorOr<IReadOnlyList<ProductoResponse>>> Handle(ListarProductoPorIdDeCategoriaQuery request, CancellationToken cancellationToken)
        {
            var productos = await _repositorioProducto.ListarTodos();

            // Filtrar productos por el Id de la categoría
            var productosFiltrados = productos.Where(producto => producto.CategoriaId.Valor == request.CategoriaId).ToList();

            var productoResponses = productosFiltrados.Select(producto => new ProductoResponse
            {
                Id = producto.Id.Valor,
                Nombre = producto.Nombre,
                CategoriaId = producto.CategoriaId.Valor.ToString(),
                Imagen = producto.Imagen,
                Descripcion = producto.Descripcion,
                Mililitros = producto.Mililitros,
                GradosDeAlcohol = producto.GradosDeAlcohol,
                Calificacion = producto.Calificacion,
                Precio = producto.Precio
            }).ToList();

            return productoResponses;
        }
    
    }
}
