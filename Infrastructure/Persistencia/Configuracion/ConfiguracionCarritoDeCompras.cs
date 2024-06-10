using Domain.CarritoDeCompras;
using Domain.Usuarios;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistencia.Configuracion
{
    public class ConfiguracionCarritoDeCompras : IEntityTypeConfiguration<CarritoDeCompras>
    {
        public void Configure(EntityTypeBuilder<CarritoDeCompras> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasConversion(
                carritoDeComprasId => carritoDeComprasId.Valor,
                valor => new CarritoDeComprasId(valor));

            builder.Property(c => c.UsuarioId).HasConversion(
                usuarioId => usuarioId.Valor,
                valor => new UsuarioId(valor));

            // Relación uno a muchos con ProductoCarrito
            builder.HasMany(c => c.ProductoCarritos)
                .WithOne()
                .HasForeignKey(pc => pc.CarritoDeComprasId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
