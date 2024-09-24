using Bookstore.Application.DTOs.Book;
using MediatR;
using Microsoft.AspNetCore.OData.Query;

namespace Bookstore.Application.Features.Books.Queries
{
    public class BooksQuery : IRequest<IReadOnlyCollection<BookReadDto>>
    {
        public ODataQueryOptions<BookReadDto> Filtros { get; set; }

        public BooksQuery(ODataQueryOptions<BookReadDto> filtros)
        {
            Filtros = filtros;
        }
    }
}
