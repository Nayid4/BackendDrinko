using Domain.Primitivos;
using Domain.Productos;
using Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CarritoDeCompras
{
    public sealed class CarritoDeCompras : AggregateRoot
    {
        private readonly HashSet<ProductoCarrito> _productosCarrito = new();
        public CarritoDeComprasId Id { get; private set; }
        public UsuarioId UsuarioId { get; private set; }
        public IReadOnlyCollection<ProductoCarrito> ProductoCarritos => _productosCarrito.ToList().AsReadOnly();

        private CarritoDeCompras(CarritoDeComprasId id, UsuarioId usuarioId)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            UsuarioId = usuarioId ?? throw new ArgumentNullException(nameof(usuarioId));
        }

        public static CarritoDeCompras Crear(Usuario usuario)
        {
            if (usuario == null) throw new ArgumentNullException(nameof(usuario));

            return new CarritoDeCompras(new CarritoDeComprasId(Guid.NewGuid()), usuario.Id);
        }

        public void AgregarProducto(Producto producto, int cantidad)
        {
            if(producto is null) throw new ArgumentNullException(nameof(producto));
            if(cantidad <= 0) throw new ArgumentNullException(nameof(cantidad));

            var productoCarrito = new ProductoCarrito(new ProductoCarritoId(Guid.NewGuid()), Id, producto.Id, cantidad, cantidad * producto.Precio);

            _productosCarrito.Add(productoCarrito);
        }

        public bool EliminarProducto(ProductoCarritoId productoCarritoId)
        {
            var productoCarrito = _productosCarrito.FirstOrDefault(pc => pc.Id == productoCarritoId);

            if (productoCarrito is null)
            {
                return false;
            }

            _productosCarrito.Remove(productoCarrito);

            return true;
        }

        public bool ActualizarCantidadProducto(ProductoCarritoId productoCarritoId, int nuevaCantidad)
        {
            var productoCarrito = _productosCarrito.FirstOrDefault(pc => pc.Id == productoCarritoId);

            if(productoCarrito is null)
            {
                return false;
            }

            _productosCarrito.Remove(productoCarrito);
            var productoActualizado = new ProductoCarrito(
                    productoCarrito.Id,
                    productoCarrito.CarritoDeComprasId,
                    productoCarrito.ProductoId,
                    nuevaCantidad,
                    nuevaCantidad * productoCarrito.Precio / productoCarrito.Cantidad // Recalcula el precio total
                );
            _productosCarrito.Add(productoActualizado);

            return true;
        }
    }

}
