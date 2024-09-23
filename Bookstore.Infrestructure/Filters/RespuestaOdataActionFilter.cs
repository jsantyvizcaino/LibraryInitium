using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.OData.Extensions;

namespace Bookstore.Infrestructure.Filters
{
    public class RespuestaOdataActionFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            context.HttpContext.Response.Headers.Add("RegistrosTotales",
                context.HttpContext.Request.ODataFeature()?.TotalCount?.ToString());
            base.OnActionExecuted(context);
        }
    }
}
