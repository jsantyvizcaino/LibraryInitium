using Bookstore.Application.DTOs.Book;
using Bookstore.Application.Features.Books.Queries;
using Bookstore.Infrestructure.Controller;
using Bookstore.Infrestructure.Filters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

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
    }
}
