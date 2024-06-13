using Domain.Pedidos;
using Domain.Productos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistencia.Configuracion
{
    public class ConfiguracionProductoPedido : IEntityTypeConfiguration<ProductoPedido>
    {
        public void Configure(EntityTypeBuilder<ProductoPedido> builder)
        {
            builder.HasKey(pp => pp.Id);

            builder.Property(pp => pp.Id).HasConversion(
                productoPedidoId => productoPedidoId.Valor,
                valor => new ProductoPedidoId(valor));

            builder.Property(pp => pp.PedidoId).HasConversion(
                pedidoId => pedidoId.Valor,
                valor => new PedidoId(valor));

            builder.Property(pp => pp.ProductoId).HasConversion(
                productoId => productoId.Valor,
                valor => new ProductoId(valor));

            builder.Property(pp => pp.Imagen)
                .IsRequired();

            builder.Property(pp => pp.Cantidad)
                .IsRequired();

            builder.Property(pp => pp.Precio)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
        }
    }
}
