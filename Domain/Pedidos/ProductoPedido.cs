using Domain.Primitivos;
using Domain.Productos;

namespace Domain.Pedidos
{
    public sealed class ProductoPedido : AggregateRoot
    {
        public ProductoPedidoId Id { get; private set; }
        public PedidoId PedidoId { get; private set; }
        public ProductoId ProductoId { get; private set; }
        public int Cantidad { get; private set; }
        public decimal Precio { get; private set; }

        public ProductoPedido(ProductoPedidoId id, PedidoId pedidoId, ProductoId productoId, int cantidad, decimal precio)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            PedidoId = pedidoId ?? throw new ArgumentNullException(nameof(pedidoId));
            ProductoId = productoId ?? throw new ArgumentNullException(nameof(productoId));
            Cantidad = cantidad > 0 ? cantidad : throw new ArgumentOutOfRangeException(nameof(cantidad));
            Precio = precio >= 0 ? precio : throw new ArgumentOutOfRangeException(nameof(precio));
        }
    }
}
