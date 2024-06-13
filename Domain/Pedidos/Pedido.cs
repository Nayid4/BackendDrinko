using Domain.CarritoDeCompras;
using Domain.Direcciones;
using Domain.Primitivos;
using Domain.Productos;
using Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Pedidos
{
    public sealed class Pedido : AggregateRoot
    {
        private readonly HashSet<ProductoPedido> _productosPedido = new HashSet<ProductoPedido>();
        public PedidoId Id { get; private set; }
        public UsuarioId UsuarioId { get; private set; }
        public DireccionId DireccionId { get; private set; }
        public ICollection<ProductoPedido> ProductosPedido => _productosPedido.ToList();

        private Pedido(PedidoId id, UsuarioId usuarioId, DireccionId direccionId)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            UsuarioId = usuarioId ?? throw new ArgumentNullException(nameof(usuarioId));
            DireccionId = direccionId ?? throw new ArgumentNullException(nameof(direccionId));
            
        }

        public static Pedido Crear(UsuarioId usuarioId, DireccionId direccionId)
        {
            if (usuarioId == null) throw new ArgumentNullException(nameof(usuarioId));
            if (direccionId == null) throw new ArgumentNullException(nameof(direccionId));

            return new Pedido(new PedidoId(Guid.NewGuid()), usuarioId, direccionId);
        }

        public void AgregarProducto(ProductoId producto, string imagen, int cantidad, decimal precio)
        {
            if (producto == null) throw new ArgumentNullException(nameof(producto));
            if (cantidad <= 0) throw new ArgumentOutOfRangeException(nameof(cantidad));

            var productoPedido = new ProductoPedido(new ProductoPedidoId(Guid.NewGuid()), Id, producto, imagen,  cantidad, cantidad * precio);

            _productosPedido.Add(productoPedido);
        }

        public bool EliminarProducto(ProductoPedidoId productoPedidoId)
        {
            var productoCarrito = _productosPedido.FirstOrDefault(pc => pc.Id == productoPedidoId);
            return productoCarrito != null && _productosPedido.Remove(productoCarrito);
        }

        public decimal CalcularTotalPedido()
        {
            return _productosPedido.Sum(pp => pp.Precio);
        }


    }
}
