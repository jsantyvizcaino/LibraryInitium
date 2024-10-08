﻿using Bookstore.Domain.Entities;

namespace Bookstore.Domain.Interfaces
{
    public interface IBookRepository
    {
        IQueryable<Book> GetAllAsync();
        Task<Book?> GetById(int id);
        Task<IQueryable<Book>?> GetByUserId(int id);
        Task UpdateAsync(Book entity);
    }
}
