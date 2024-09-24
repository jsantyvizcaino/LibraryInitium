using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LibraryContext _context;

        public UserRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<Usuario> AddAsync(Usuario entity)
        {
            _context.Set<Usuario>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public IQueryable<Usuario> GetAllAsync()
        {
            return _context.Set<Usuario>();
        }

        public Task<Usuario?> GetById(int id)
        {
            return _context.Set<Usuario>().FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public Task<Usuario?> GetByUsername(string username)
        {
            return _context.Set<Usuario>().FirstOrDefaultAsync(x => x.Username.Equals(username));
        }
    }
}
