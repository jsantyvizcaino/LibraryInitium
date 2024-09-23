using Bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrestructure
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options): base(options) 
        {
            
        }

        public DbSet<Book> Books { get; set; }
    }
}
