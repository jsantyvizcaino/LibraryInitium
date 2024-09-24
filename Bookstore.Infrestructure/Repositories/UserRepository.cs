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

        public IQueryable<Usuario> GetAllAsync()
        {
            return _context.Set<Usuario>();
        }

        public Task<Usuario?> GetById(int id)
        {
            return _context.Set<Usuario>().FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
    }
}
