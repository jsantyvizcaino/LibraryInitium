using Bookstore.Application.Features.Books.Commands;

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
