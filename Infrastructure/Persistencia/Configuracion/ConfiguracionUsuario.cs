using Domain.ObjetosDeValor;
using Domain.Usuarios;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infractructure.Persistencia.Configuracion
{
    public class ConfiguracionUsuario : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id).HasConversion(
                usuarioId => usuarioId.Valor,
                valor => new UsuarioId(valor));

            builder.Property(u => u.Nombre)
                .HasMaxLength(100);

            builder.Property(u => u.Apellido)
                .HasMaxLength(100);

            builder.Property(u => u.Correo)
                .HasMaxLength(255);

            builder.HasIndex(u => u.Correo)
                .IsUnique();

            builder.Property(u => u.NumeroDeTelefono).HasConversion(
                numeroDeTelefono => numeroDeTelefono.Valor,
                valor => NumeroDeTelefono.Crear(valor)!)
                .HasMaxLength(10);

            builder.OwnsOne(u => u.Direccion, direccionBuilder =>
            {
                direccionBuilder.Property(d => d.Pais)
                    .HasMaxLength(50);

                direccionBuilder.Property(d => d.Linea1)
                    .HasMaxLength(50);

                direccionBuilder.Property(d => d.Linea2)
                    .HasMaxLength(50)
                    .IsRequired(false);

                direccionBuilder.Property(d => d.Ciudad)
                    .HasMaxLength(50);

                direccionBuilder.Property(d => d.Estado)
                    .HasMaxLength(50);

                direccionBuilder.Property(d => d.CodigoPostal)
                    .HasMaxLength(10);
            });

        }
    }
}
