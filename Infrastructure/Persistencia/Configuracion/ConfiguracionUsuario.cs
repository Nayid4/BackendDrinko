using Domain.ObjetosDeValor;
using Domain.Usuarios;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistencia.Configuracion
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
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Apellido)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Correo)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasIndex(u => u.Correo)
                .IsUnique();

            builder.Property(u => u.NumeroDeTelefono).HasConversion(
                numeroDeTelefono => numeroDeTelefono.Valor,
                valor => NumeroDeTelefono.Crear(valor)!)
                .IsRequired()
                .HasMaxLength(10);

            // Relación uno a muchos con Direccion
            builder.HasMany(u => u.Direcciones)
                .WithOne()
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
