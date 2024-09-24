using Bookstore.Application.DTOs.Authentication;
using Bookstore.Application.Wrappers;
using Bookstore.Application.Features.Authentication.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Application.Features.Authentication.Command
{
    public class AuthenticateCommand : IRequest<Response<AuthenticationResponse>>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? IpAddress { get; set; }

    }

    
}
