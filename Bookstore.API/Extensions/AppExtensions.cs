using Bookstore.API.Middlewares;

namespace Bookstore.API.Extensions
{
    public static class AppExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
