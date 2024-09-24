using Bookstore.Application.Features.Books.Commands;
using Bookstore.Application.Features.Users.Commands;
using Bookstore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Application.DTOs.Book.Request
{
    public class BookRequest
    {
        public BookUpdateDto Book { get; set; }

        public BookRequest(BookUpdateDto book)
        {
            Book = book;
        }

        public UpdateBookCommand ToUpdate()
        {
            return new UpdateBookCommand(Book);
        }
    }
}
