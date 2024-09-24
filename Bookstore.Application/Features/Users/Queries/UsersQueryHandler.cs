using AutoMapper;
using AutoMapper.AspNet.OData;
using Bookstore.Application.DTOs.User;
using Bookstore.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Bookstore.Application.Features.Users.Queries
{
    internal class UsersQueryHandler : IRequestHandler<UsersQuery, IReadOnlyCollection<UserReadDto>>
    {
        public readonly ILogger<UsersQueryHandler> _logger;
        public readonly IUserRepository _repository;
        public readonly IMapper _mapper;

        public UsersQueryHandler(ILogger<UsersQueryHandler> logger, IUserRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyCollection<UserReadDto>> Handle(UsersQuery request, CancellationToken cancellationToken)
        {
            var resultado = await _repository.GetAllAsync().GetQueryAsync(_mapper, request.Filtros);

            return await resultado.ToListAsync();
        }
    }
}
