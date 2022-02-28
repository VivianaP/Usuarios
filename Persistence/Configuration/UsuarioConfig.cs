using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("UsuariosPrueba");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nombre)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Email)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(p => p.Telefono)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(p => p.Username)
               .HasMaxLength(100)
               .IsRequired();

        }
    }
}
    