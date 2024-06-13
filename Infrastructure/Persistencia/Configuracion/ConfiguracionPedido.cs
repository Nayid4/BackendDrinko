using Domain.Direcciones;
using Domain.Pedidos;
using Domain.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistencia.Configuracion
{
    public class ConfiguracionPedido : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasConversion(
                pedidoId => pedidoId.Valor,
                valor => new PedidoId(valor));

            builder.Property(p => p.UsuarioId).HasConversion(
                usuarioId => usuarioId.Valor,
                valor => new UsuarioId(valor));

            builder.Property(p => p.DireccionId).HasConversion(
                direccionId => direccionId.Valor,
                valor => new DireccionId(valor));


            // Relación uno a muchos con ProductoPedido
            builder.HasMany(p => p.ProductosPedido)
                .WithOne()
                .HasForeignKey(pp => pp.PedidoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
