using Bookstore.Application.DTOs.Book;
using MediatR;

namespace Bookstore.Application.Features.Books.Queries
{
    public class BookQuery : IRequest<BookReadDto>
    {
        public int Id { get; set; }

        public BookQuery(int id)
        {
            Id = id;
        }
    }
}
