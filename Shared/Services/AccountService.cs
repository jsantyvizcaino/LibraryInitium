using Bookstore.Application.DTOs;
using Bookstore.Application.DTOs.Authentication;
using Bookstore.Application.Exceptions;
using Bookstore.Application.Wrappers;
using Bookstore.Application.Features.Authentication.Contracts;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Shared.Services
{
    public class AccountService : IAccountService
    {
        private readonly AppSettings _configuration;

        public AccountService(IOptions<AppSettings> configuration)
        {
            _configuration = configuration.Value;
        }

        public async Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddress)
        {
            if (request.Email == "sapmax@kruger.com" && request.Password == "generarPassword")
            {
                JwtSecurityToken jwtSecurityToken = GenerateJWTToken();
                AuthenticationResponse response = new AuthenticationResponse();
                response.JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                return new Response<AuthenticationResponse>(response, $"Autenticacion exitosa");
            }

            throw new ApiException($"Credenciales invalidas");
        }

        private JwtSecurityToken GenerateJWTToken()
        {

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.JWT.Key));
            var signingCredential = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _configuration.JWT.Issuer,
                audience: _configuration.JWT.Audience,
                expires: DateTime.Now.AddMinutes(_configuration.JWT.DurationInMinutes),
                signingCredentials: signingCredential
                );

            return jwtSecurityToken;

        }
    }
}
