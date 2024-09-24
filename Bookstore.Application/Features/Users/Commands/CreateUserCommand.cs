using Bookstore.Application.DTOs.User;
using Bookstore.Application.Wrappers;
using Bookstore.Domain.Entities;
using MediatR;

namespace Bookstore.Application.Features.Users.Commands
{
    public class CreateUserCommand : IRequest<Response<int>>
    {
        public UserCreateDto Usuario { get; set; }

        public CreateUserCommand(UserCreateDto usuario)
        {
            Usuario = usuario;
        }
    }
}
