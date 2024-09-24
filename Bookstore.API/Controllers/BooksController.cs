using Azure.Core;
using Bookstore.Application.DTOs.Book;
using Bookstore.Application.DTOs.Book.Request;
using Bookstore.Application.Features.Books.Queries;
using Bookstore.Infrestructure.Controller;
using Bookstore.Infrestructure.Filters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using System.Net;

namespace Bookstore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ApiBaseController
    {
        private readonly ILogger<BooksController> _logger;

        public BooksController(ILogger<BooksController> logger,
            IMediator mediator) : base(mediator)
        {
            _logger = logger;
        }

        #region GET
        [HttpGet]
        [EnableQuery]
        [RespuestaOdataActionFilter]
        //[Authorize]
        public async Task<IActionResult> GetBooks(ODataQueryOptions<BookReadDto> filtros)
        {
            _logger.LogInformation("Getting items from {Methods} at {RunTime}", nameof(GetBooks), DateTime.Now);
            var resultado = await Mediator.Send(new BooksQuery(filtros));

            if (resultado.Any())
                return Ok(resultado);

            _logger.LogWarning("Not found items from {Methods} at {RunTime}", nameof(GetBooks), DateTime.Now);
            return NoContent();
        }

        [HttpGet("{id}")]

        //[Authorize]
        public async Task<IActionResult> GetBook(int id)
        {
            _logger.LogInformation("Getting item {Id} from {Methods} at {RunTime}", id, nameof(GetBook), DateTime.Now);
            var resultado = await Mediator.Send(new BookQuery(id));

            if (resultado != null)
                return Ok(resultado);

            _logger.LogWarning("Not found item {Id} from {Methods} at {RunTime}", id, nameof(GetBook), DateTime.Now);
            return NoContent();
        }
        #endregion

        #region PUT
        [HttpPut]
        public async Task<IActionResult> UpdateBook(BookRequest request)
        {
            _logger.LogInformation("Call {Methods} at {RunTime}", nameof(UpdateBook), DateTime.Now);
            var comando = request.ToUpdate();
            var resultado = await Mediator.Send(comando);
            if (resultado.Succeeded)
                return StatusCode((int)HttpStatusCode.Created, resultado);


            return BadRequest(resultado);
        }
        #endregion

    }
}
