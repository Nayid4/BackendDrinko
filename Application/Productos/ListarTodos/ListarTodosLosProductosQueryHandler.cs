using Application.Productos.Common;
using Domain.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Productos.ListarTodos
{
    internal sealed class ListarTodosLosProductosQueryHandler : IRequestHandler<ListarTodosLosProductosQuery, ErrorOr<IReadOnlyList<ProductoResponse>>>
    {
        private readonly IRepositorioProducto _repositorioProducto;

        public ListarTodosLosProductosQueryHandler(IRepositorioProducto repositorioProducto)
        {
            _repositorioProducto = repositorioProducto ?? throw new ArgumentNullException(nameof(repositorioProducto));
        }

        public async Task<ErrorOr<IReadOnlyList<ProductoResponse>>> Handle(ListarTodosLosProductosQuery request, CancellationToken cancellationToken)
        {
            var productos = await _repositorioProducto.ListarTodos();

            var productoResponses = productos.Select(producto => new ProductoResponse
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
