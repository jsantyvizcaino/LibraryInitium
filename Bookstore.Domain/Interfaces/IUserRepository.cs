﻿using Bookstore.Domain.Entities;

namespace Bookstore.Domain.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<Usuario> GetAllAsync();
        Task<Usuario?> GetById(int id);
    }
}
