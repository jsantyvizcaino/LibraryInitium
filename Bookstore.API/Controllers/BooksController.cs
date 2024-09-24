using Bookstore.Application.DTOs.Book;
using Bookstore.Application.Features.Books.Queries;
using Bookstore.Infrestructure.Controller;
using Bookstore.Infrestructure.Filters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
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
        public async Task<IActionResult> ObtenerBooks(ODataQueryOptions<BookReadDto> filtros)
        {
            var resultado = await Mediator.Send(new BooksQuery(filtros));

            if (resultado.Any())
                return Ok(resultado);


            return NoContent();
        }

        [HttpGet("{id}")]
        
        //[Authorize]
        public async Task<IActionResult> ObtenerBook(int id)
        {
            var resultado = await Mediator.Send(new BookQuery(id));

            if (resultado != null)
                return Ok(resultado);


            return NoContent();
        }
    }
}
