using AutoMapper;
using AutoMapper.AspNet.OData;
using Bookstore.Application.DTOs.Book;
using Bookstore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Bookstore.Application.Features.Books.Queries
{
    internal class BooksQueryHandler : IRequestHandler<BooksQuery, IReadOnlyCollection<BookReadDto>>
    {

        public readonly ILogger<BooksQueryHandler> _logger;
        public readonly IBookRepository _repository;
        public readonly IMapper _mapper;

        public BooksQueryHandler(ILogger<BooksQueryHandler> logger, IBookRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyCollection<BookReadDto>> Handle(BooksQuery request, CancellationToken cancellationToken)
        {

            var resultado = await _repository.GetAllAsync().GetQueryAsync(_mapper, request.Filtros);

            return await resultado.ToListAsync();
        }
    }
}
