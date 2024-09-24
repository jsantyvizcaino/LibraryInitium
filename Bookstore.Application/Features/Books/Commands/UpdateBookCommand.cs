using Bookstore.Application.DTOs.Book;
using Bookstore.Application.Wrappers;
using MediatR;

namespace Bookstore.Application.Features.Books.Commands
{
    public class UpdateBookCommand : IRequest<Response<int>>
    {
        public BookUpdateDto Book { get; set; }

        public UpdateBookCommand(BookUpdateDto book)
        {
            Book = book;
        }
    }

}
