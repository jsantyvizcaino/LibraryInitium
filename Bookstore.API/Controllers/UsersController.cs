using Bookstore.Application.DTOs.User;
using Bookstore.Application.Features.Users.Queries;
using Bookstore.Infrestructure.Controller;
using Bookstore.Infrestructure.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace Bookstore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ApiBaseController
    {
        private readonly ILogger<UsersController> _logger;
        public UsersController(ILogger<UsersController> logger,
            IMediator mediator) : base(mediator)
        {
            _logger = logger;
        }

        [HttpGet]
        [EnableQuery]
        [RespuestaOdataActionFilter]
        //[Authorize]
        public async Task<IActionResult> ObtenerTodosAdminAccionRoleSamweb(ODataQueryOptions<UserReadDto> filtros)
        {
            var resultado = await Mediator.Send(new UsersQuery(filtros));

            if (resultado.Any())
                return Ok(resultado);


            return NoContent();
        }
    }
}
