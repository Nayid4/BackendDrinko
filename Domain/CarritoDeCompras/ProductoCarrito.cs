﻿using Domain.Primitivos;
using Domain.Productos;

namespace Domain.CarritoDeCompras
{
    public sealed class ProductoCarrito : AggregateRoot
    {
        public ProductoCarritoId Id { get; private set; }
        public CarritoDeComprasId CarritoDeComprasId { get; private set; }
        public ProductoId ProductoId { get; private set; }
        public int Cantidad { get; private set; }
        public decimal Precio { get; private set; }

        public ProductoCarrito()
        {
        }

        public ProductoCarrito(ProductoCarritoId id, CarritoDeComprasId carritoDeComprasId, ProductoId productoId, int cantidad, decimal precio)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            CarritoDeComprasId = carritoDeComprasId ?? throw new ArgumentNullException(nameof(carritoDeComprasId));
            ProductoId = productoId ?? throw new ArgumentNullException(nameof(productoId));
            Cantidad = cantidad > 0 ? cantidad : throw new ArgumentOutOfRangeException(nameof(cantidad));
            Precio = precio >= 0 ? precio : throw new ArgumentOutOfRangeException(nameof(precio));
        }
    }

}