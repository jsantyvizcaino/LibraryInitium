using Bookstore.Application.DTOs.Authentication;
using Bookstore.Application.Wrappers;

namespace Bookstore.Application.Features.Authentication.Contracts
{
    public interface IAccountService
    {
        Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddress);
    }
}
