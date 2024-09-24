using Bookstore.Application.DTOs.User;
using Bookstore.Application.DTOs.User.Request;
using Bookstore.Application.Features.Users.Queries;
using Bookstore.Infrestructure.Controller;
using Bookstore.Infrestructure.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using System.Net;

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

        #region Get
        [HttpGet]
        [EnableQuery]
        [RespuestaOdataActionFilter]
        //[Authorize]
        public async Task<IActionResult> GetUsers(ODataQueryOptions<UserReadDto> filtros)
        {
            _logger.LogInformation("Getting items from {Methods} at {RunTime}", nameof(GetUsers), DateTime.Now);
            var resultado = await Mediator.Send(new UsersQuery(filtros));

            if (resultado.Any())
                return Ok(resultado);


            return NoContent();
        }

        [HttpGet("{id}")]

        //[Authorize]
        public async Task<IActionResult> GetUser(int id)
        {
            _logger.LogInformation("Getting item {Id} from {Methods} at {RunTime}", id, nameof(GetUser), DateTime.Now);
            var resultado = await Mediator.Send(new UserQuery(id));

            if (resultado != null)
                return Ok(resultado);

            _logger.LogWarning("Not found item {Id} from {Methods} at {RunTime}", id, nameof(GetUser), DateTime.Now);
            return NoContent();
        }
        #endregion


        #region Post
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserRequest request)
        {
            _logger.LogInformation("Call {Methods} at {RunTime}", nameof(CreateUser), DateTime.Now);
            var comando = request.ToCreate();
            var resultado = await Mediator.Send(comando);
            if (resultado.Succeeded)
                return StatusCode((int)HttpStatusCode.Created, resultado);

            
            return BadRequest(resultado);
        }
        #endregion
    }
}
