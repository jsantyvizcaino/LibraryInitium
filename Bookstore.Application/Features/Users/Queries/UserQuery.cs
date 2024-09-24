using Bookstore.Application.DTOs.User;
using MediatR;

namespace Bookstore.Application.Features.Users.Queries
{
    public class UserQuery : IRequest<UserReadDto>
    {
        public int Id { get; set; }

        public UserQuery(int id)
        {
            Id = id;
        }
    }
}
