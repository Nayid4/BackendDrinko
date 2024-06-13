using Domain.CarritoDeCompras;
using Domain.Productos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistencia.Configuracion
{
    public class ConfiguracionProductoCarrito : IEntityTypeConfiguration<ProductoCarrito>
    {
        public void Configure(EntityTypeBuilder<ProductoCarrito> builder)
        {
            builder.HasKey(pc => pc.Id);

            builder.Property(pc => pc.Id).HasConversion(
                productoCarritoId => productoCarritoId.Valor,
                valor => new ProductoCarritoId(valor));

            builder.Property(pc => pc.CarritoDeComprasId).HasConversion(
                carritoDeComprasId => carritoDeComprasId.Valor,
                valor => new CarritoDeComprasId(valor));

            builder.Property(pc => pc.ProductoId).HasConversion(
                productoId => productoId.Valor,
                valor => new ProductoId(valor));

            builder.Property(pc => pc.Imagen)
                .IsRequired();

            builder.Property(pc => pc.Cantidad)
                .IsRequired();

            builder.Property(pc => pc.Precio)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
        }
    }
}
