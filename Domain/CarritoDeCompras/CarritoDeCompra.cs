using Domain.Primitivos;
using Domain.Productos;
using Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.CarritoDeCompras
{
    public sealed class CarritoDeCompra : AggregateRoot
    {
        private readonly HashSet<ProductoCarrito> _productosCarrito = new HashSet<ProductoCarrito>();

        public CarritoDeComprasId Id { get; private set;  }
        public UsuarioId UsuarioId { get; private set; }
        public IReadOnlyCollection<ProductoCarrito> ProductoCarritos => _productosCarrito.ToList().AsReadOnly();

        private CarritoDeCompra(CarritoDeComprasId id, UsuarioId usuarioId)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            UsuarioId = usuarioId ?? throw new ArgumentNullException(nameof(usuarioId));
        }

        public static CarritoDeCompra Crear(UsuarioId usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));

            return new CarritoDeCompra(new CarritoDeComprasId(Guid.NewGuid()), usuario);
        }

        public void AgregarProducto(ProductoId producto, int cantidad, decimal precio)
        {
            if (producto == null)
                throw new ArgumentNullException(nameof(producto));

            if (cantidad <= 0)
                throw new ArgumentOutOfRangeException(nameof(cantidad), "La cantidad debe ser mayor que cero.");

            var productoCarrito = new ProductoCarrito(new ProductoCarritoId(Guid.NewGuid()),Id, producto, cantidad, precio);
            _productosCarrito.Add(productoCarrito);
        }

        public bool EliminarProducto(ProductoCarritoId productoCarritoId)
        {
            var productoCarrito = _productosCarrito.FirstOrDefault(pc => pc.Id == productoCarritoId);
            return productoCarrito != null && _productosCarrito.Remove(productoCarrito);
        }

        public bool ActualizarCantidadProducto(ProductoCarritoId productoCarritoId, int nuevaCantidad)
        {
            var productoCarrito = _productosCarrito.FirstOrDefault(pc => pc.Id == productoCarritoId);

            if (productoCarrito == null)
                return false;

            productoCarrito.ActualizarCantidad(nuevaCantidad);
            return true;
        }
    }
}
