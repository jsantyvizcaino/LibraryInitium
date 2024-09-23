using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Bookstore.Infrestructure.Controller
{
    [ApiController]
    [Route("api/v{version:apiVersion}")]
    public class ApiBaseController : ODataController
    {

        private IMediator _mediator;

        protected IMediator Mediator => _mediator;

        public ApiBaseController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
