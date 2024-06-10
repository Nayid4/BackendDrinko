using Domain.Categoria;
using Domain.Productos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistencia.Configuracion
{
    public class ConfiguracionProducto : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasConversion(
                productoId => productoId.Valor,
                valor => new ProductoId(valor));

            builder.Property(p => p.Nombre)
                .HasMaxLength(100);

            builder.Property(p => p.CategoriaId).HasConversion(
                categoriaId => categoriaId.Valor,
                valor => new CategoriaId(valor));

            builder.Property(p => p.Imagen);

            builder.Property(p => p.Descripcion);

            builder.Property(p => p.Mililitros);

            builder.Property(p => p.GradosDeAlcohol);

            builder.Property(p => p.Calificacion);

            builder.Property(p => p.Precio)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
        }
    }
}
