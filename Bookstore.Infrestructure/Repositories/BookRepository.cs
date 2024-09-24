using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces;

namespace Bookstore.Infrestructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;
        public BookRepository(LibraryContext context )
        {
            _context = context;
        }
        

        public IQueryable<Book> GetAllAsync()
        {
            return _context.Set<Book>();
        }
       
    }
}
