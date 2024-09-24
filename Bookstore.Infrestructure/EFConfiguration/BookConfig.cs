using Bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Infrestructure.EFConfiguration
{
    internal class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK__Books__3214EC07046604E7");

            entity.Property(e => e.Author)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Genre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Books)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Books__UsuarioId__3B75D760");
        }
    }
}
