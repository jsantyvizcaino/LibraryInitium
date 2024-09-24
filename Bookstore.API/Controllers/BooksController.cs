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
        public async Task<IActionResult> ObtenerTodosAdminAccionRoleSamweb(ODataQueryOptions<BookReadDto> filtros)
        {
            var resultado = await Mediator.Send(new BooksQuery(filtros));

            if (resultado.Any())
                return Ok(resultado);


            return NoContent();
        }
    }
}
