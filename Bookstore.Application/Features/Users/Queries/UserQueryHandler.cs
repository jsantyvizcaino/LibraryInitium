using AutoMapper;
using Bookstore.Application.DTOs.User;
using Bookstore.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Bookstore.Application.Features.Users.Queries
{
    internal class UserQueryHandler : IRequestHandler<UserQuery, UserReadDto>
    {
        public readonly ILogger<UserQueryHandler> _logger;
        public readonly IUserRepository _repository;
        public readonly IMapper _mapper;

        public UserQueryHandler(ILogger<UserQueryHandler> logger, IUserRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        public  async Task<UserReadDto> Handle(UserQuery request, CancellationToken cancellationToken)
        {
            var resultado = await _repository.GetById(request.Id);
            return _mapper.Map<UserReadDto>(resultado);
        }
    }
}
