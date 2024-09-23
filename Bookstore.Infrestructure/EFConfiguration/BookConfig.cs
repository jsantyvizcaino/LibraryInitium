using Bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Infrestructure.EFConfiguration
{
    internal class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property<int>("Id")
                         .ValueGeneratedOnAdd()
                         .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(builder.Property<int>("Id"));

            builder.Property<string>("Author")
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            builder.Property<string>("Genre")
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            builder.Property<int>("PublishedYear")
                .HasColumnType("int");

            builder.Property<string>("Title")
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            builder.HasKey("Id");

            builder.ToTable("Books");
        }
    }
}
