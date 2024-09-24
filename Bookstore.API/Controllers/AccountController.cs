using Bookstore.Application.DTOs.Authentication;
using Bookstore.Application.Features.Authentication.Command;
using Bookstore.Infrestructure.Controller;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AccountController : ApiBaseController
    {

        private readonly ILogger<BooksController> _logger;

        public AccountController(ILogger<BooksController> logger,
            IMediator mediator) : base(mediator)
        {
            _logger = logger;
        }

        [HttpPost("auth/login")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
        {
            _logger.LogInformation("Request to {Methods} at {RunTime}", nameof(AuthenticateAsync), DateTime.Now);
            return Ok(await Mediator.Send(new AuthenticateCommand
            {
                Username = request.Username,
                Password = request.Password,
                IpAddress = GenerateIpAddress()
            }));
        }


        private string GenerateIpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"]!;
            else
                return HttpContext.Connection.RemoteIpAddress!.MapToIPv4().ToString();
        }
    }
}
