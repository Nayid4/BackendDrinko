using Application.Productos.Common;
using Application.Productos.ListarTodos;
using Domain.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.Productos.ListarPorId
{
    internal sealed class ListarProductoPorIdQueryHandler : IRequestHandler<ListarProductoPorIdQuery, ErrorOr<ProductoResponse>>
    {
        private readonly IRepositorioProducto _repositorioProducto;

        public ListarProductoPorIdQueryHandler(IRepositorioProducto repositorioProducto)
        {
            _repositorioProducto = repositorioProducto ?? throw new ArgumentNullException(nameof(repositorioProducto));
        }

        public async Task<ErrorOr<ProductoResponse>> Handle(ListarProductoPorIdQuery request, CancellationToken cancellationToken)
        {
            if (await _repositorioProducto.ListarPorId(new ProductoId(request.Id)) is not Producto producto)
            {
                return Error.NotFound("Producto.NoEncontrado", "No se encontró el producto.");
            }

            var productoResponse = new ProductoResponse
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
            };

            return productoResponse;
        }
    }
}
