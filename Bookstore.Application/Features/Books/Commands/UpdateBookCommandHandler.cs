using AutoMapper;
using Bookstore.Application.Exceptions;
using Bookstore.Application.Features.Users.Queries;
using Bookstore.Application.Wrappers;
using Bookstore.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Bookstore.Application.Features.Books.Commands
{
    internal class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Response<int>>
    {
        public readonly ILogger<UpdateBookCommandHandler> _logger;
        public readonly IBookRepository _repository;
        private readonly IMediator _mediator;
        public readonly IMapper _mapper;

        public UpdateBookCommandHandler(ILogger<UpdateBookCommandHandler> logger, IBookRepository repository, IMapper mapper
            , IMediator mediator)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<Response<int>> Handle(UpdateBookCommand command, CancellationToken cancellationToken)
        {
            var entityToUpdate = command.Book;
            if (entityToUpdate.UsuarioId is null) throw new ApiException("It is necesary send the User ID");
            var entity = await _repository.GetById(entityToUpdate.Id);
            if (entity == null) throw new KeyNotFoundException($"Book Not Found");
      
            if (!await UserExcist((int)entityToUpdate.UsuarioId)) throw new KeyNotFoundException($"User Not Found");

            if(await NumLibrosByUser((int)entityToUpdate.UsuarioId)>=3) throw new ApiException("User can't have more that 3 books");


            entity.UsuarioId=entityToUpdate.UsuarioId;
            await _repository.UpdateAsync(entity);

            _logger.LogInformation(($"Entity {entityToUpdate} successfully edited."));
            return new Response<int>(entityToUpdate.Id, "Entity successfully edited.");
        }


        private async Task<bool> UserExcist(int id)
        {
            var existe = await _mediator.Send(new UserQuery(id));
            return existe is not null?true:false;
        } 

        private async Task<int> NumLibrosByUser(int id)
        {
            var libros = await _repository.GetByUserId(id);
            return libros == null ? 0 : libros.Count();
        }

    }
}
