﻿using Bookstore.Application.DTOs.User;
using Bookstore.Application.Features.Books.Queries;
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
    }
}
