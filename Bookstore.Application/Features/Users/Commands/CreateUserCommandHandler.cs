using AutoMapper;
using Bookstore.Application.Wrappers;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using Bookstore.Domain.Common;
using Bookstore.Application.DTOs;
using Microsoft.Extensions.Options;

namespace Bookstore.Application.Features.Users.Commands
{
    internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response<int>>
    {
        private readonly ILogger<CreateUserCommandHandler> _logger;
        public readonly IUserRepository _repository;
        public readonly IMapper _mapper;
        private readonly AppSettings _configuration;

        public CreateUserCommandHandler(ILogger<CreateUserCommandHandler> logger, IUserRepository repository, IMapper mapper,
            IOptions<AppSettings> configuration)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
            _configuration = configuration.Value;

        }

        public async Task<Response<int>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var newObject = _mapper.Map<Usuario>(command.Usuario);
            
            string encryptedPassword = SecurityManager.EncryptPassword(newObject.Password, _configuration.EncryptionSettings.Key
                , _configuration.EncryptionSettings.IV);
            newObject.Password= encryptedPassword;
            var entityGenerate = await _repository.AddAsync(newObject);

            _logger.LogInformation(($"Entity {entityGenerate} successfully created."));
            return new Response<int>(entityGenerate.Id, "User successfully created.");
        }
    }
}
