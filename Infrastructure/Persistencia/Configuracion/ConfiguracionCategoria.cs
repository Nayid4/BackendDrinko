using Domain.Categoria;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistencia.Configuracion
{
    public class ConfiguracionCategoria : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).HasConversion(
                categoriaId => categoriaId.Valor,
                valor => new CategoriaId(valor));

            builder.Property(c => c.Nombre)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
