using Bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Infrestructure.EFConfiguration
{
    internal class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC07514C56C5");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Username, "UQ__Usuario__536C85E43A514D54").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D105342DC1375B").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(150)
                .IsUnicode(false);
        }
    }
}
