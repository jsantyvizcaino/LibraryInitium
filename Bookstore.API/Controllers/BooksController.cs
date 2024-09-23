using Bookstore.Infrestructure.Controller;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Bookstore.Application.DTOs.Book;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Bookstore.Infrestructure.Filters;
using Bookstore.Application.Features.Books.Queries;

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
        public async Task<IActionResult> ObtenerTodosAdminAccionRoleSamweb(ODataQueryOptions<BookReadDto> filtros)
        {
            var resultado = await Mediator.Send(new BooksQuery(filtros));

            if (resultado.Any())
                return Ok(resultado);

           
            return NoContent();
        }
    }
}
