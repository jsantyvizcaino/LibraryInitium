using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task UpdateAsync(Book entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        Task<Book?> IBookRepository.GetById(int id)
        {
            return _context.Set<Book>().FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<IQueryable<Book>?> GetByUserId(int id)
        {
            return await Task.FromResult(_context.Set<Book>().Where(x => x.UsuarioId.Equals(id)));
        }
    }
}
