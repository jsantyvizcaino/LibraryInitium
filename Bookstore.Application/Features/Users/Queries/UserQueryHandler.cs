using AutoMapper;
using Bookstore.Application.DTOs.Book;
using Bookstore.Application.DTOs.User;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.Extensions.Logging;

namespace Bookstore.Application.Features.Users.Queries
{
    internal class UserQueryHandler : IRequestHandler<UserQuery, UserReadDto>
    {
        public readonly ILogger<UserQueryHandler> _logger;
        public readonly IUserRepository _repository;
        public readonly IBookRepository _repositoryBook;
        public readonly IMapper _mapper;

        public UserQueryHandler(ILogger<UserQueryHandler> logger, IUserRepository repository, IMapper mapper
            , IBookRepository repositoryBook)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
            _repositoryBook = repositoryBook;
        }

        public  async Task<UserReadDto> Handle(UserQuery request, CancellationToken cancellationToken)
        {
            var resultado = await _repository.GetById(request.Id);
            var salida = _mapper.Map<UserReadDto>(resultado);
            var libros = await _repositoryBook.GetByUserId(salida.Id);
            if (libros is not null && libros.Count() > 0)
                salida.Books = _mapper.Map<ICollection<BookReadDto>>(libros);
            return salida;
        }

        
        
    }
}
