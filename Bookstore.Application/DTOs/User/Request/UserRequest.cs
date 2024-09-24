using Bookstore.Application.Features.Users.Commands;
using Bookstore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Application.DTOs.User.Request
{
    public class UserRequest
    {
        public UserCreateDto Usuario { get; set; }

        public UserRequest(UserCreateDto usuario)
        {
            Usuario = usuario;
        }

        public CreateUserCommand ToCreate()
        {
            return new CreateUserCommand(Usuario);
        }
    }
}
