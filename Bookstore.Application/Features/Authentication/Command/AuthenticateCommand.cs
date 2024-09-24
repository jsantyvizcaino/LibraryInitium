using Bookstore.Application.DTOs.Authentication;
using Bookstore.Application.Wrappers;
using MediatR;

namespace Bookstore.Application.Features.Authentication.Command
{
    public class AuthenticateCommand : IRequest<Response<AuthenticationResponse>>
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? IpAddress { get; set; }

    }

    
}
