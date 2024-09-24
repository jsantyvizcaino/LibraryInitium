using AutoMapper;
using Bookstore.Application.DTOs.Book;
using Bookstore.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Bookstore.Application.Features.Books.Queries
{
    internal class BookQueryHandler : IRequestHandler<BookQuery, BookReadDto>
    {
        public readonly ILogger<BookQueryHandler> _logger;
        public readonly IBookRepository _repository;
        public readonly IMapper _mapper;

        public BookQueryHandler(ILogger<BookQueryHandler> logger, IBookRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BookReadDto> Handle(BookQuery request, CancellationToken cancellationToken)
        {
            var resultado = await _repository.GetById(request.Id);
            return _mapper.Map<BookReadDto>(resultado);
        }
    }
}
