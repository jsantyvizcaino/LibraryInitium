using Bookstore.Application.DTOs;
using Bookstore.Application.DTOs.Authentication;
using Bookstore.Application.Exceptions;
using Bookstore.Application.Wrappers;
using Bookstore.Application.Features.Authentication.Contracts;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Bookstore.Domain.Interfaces;
using Bookstore.Domain.Common;



namespace Shared.Services
{
    public class AccountService : IAccountService
    {
        private readonly AppSettings _configuration;
        private readonly IUserRepository _repository;

        public AccountService(IOptions<AppSettings> configuration, IUserRepository repository)
        {
            _configuration = configuration.Value;
            _repository = repository;
        }

        public async Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddress)
        {
            var user = await _repository.GetByUsername(request.Username);
            if (user == null) throw new ApiException($"Credenciales invalidas");
            string decryptedPassword = SecurityManager.DecryptPassword(user.Password, _configuration.EncryptionSettings.Key
               , _configuration.EncryptionSettings.IV);

            if (request.Password == decryptedPassword)
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
