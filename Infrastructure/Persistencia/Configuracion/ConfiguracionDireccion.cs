using Domain.Direcciones;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistencia.Configuracion
{
    public class ConfiguracionDireccion : IEntityTypeConfiguration<Direccion>
    {
        public void Configure(EntityTypeBuilder<Direccion> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id).HasConversion(
                direccionId => direccionId.Valor,
                valor => new DireccionId(valor));


            builder.Property(d => d.Linea1)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(d => d.Linea2)
                .HasMaxLength(255);

            builder.Property(d => d.Ciudad)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(d => d.Departamento)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(d => d.CodigoPostal)
                .IsRequired();

        }
    }
}
