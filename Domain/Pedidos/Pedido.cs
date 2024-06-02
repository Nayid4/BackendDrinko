using Domain.CarritoDeCompras;
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
        private readonly HashSet<ProductoPedido> _productosPedido = new();
        public PedidoId Id { get; private set; }
        public UsuarioId UsuarioId { get; private set; }
        public IReadOnlyCollection<ProductoPedido> ProductosPedido => _productosPedido.ToList().AsReadOnly();

        private Pedido(PedidoId id, UsuarioId usuarioId)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            UsuarioId = usuarioId ?? throw new ArgumentNullException(nameof(usuarioId));
        }

        public static Pedido Crear(Usuario usuario, PedidoId pedidoId)
        {
            if (usuario == null) throw new ArgumentNullException(nameof(usuario));
            if (pedidoId == null) throw new ArgumentNullException(nameof(pedidoId));

            return new Pedido(pedidoId, usuario.Id);
        }

        public void AgregarProducto(Producto producto, int cantidad)
        {
            if (producto == null) throw new ArgumentNullException(nameof(producto));
            if (cantidad <= 0) throw new ArgumentOutOfRangeException(nameof(cantidad));

            var productoPedido = new ProductoPedido(new ProductoPedidoId(Guid.NewGuid()), Id, producto.Id, cantidad, cantidad * producto.Precio);

            _productosPedido.Add(productoPedido);
        }

        public decimal CalcularTotalPedido()
        {
            return _productosPedido.Sum(pp => pp.Precio);
        }


    }
}
