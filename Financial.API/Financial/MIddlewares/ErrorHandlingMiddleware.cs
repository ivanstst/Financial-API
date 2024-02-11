using System.Net;

namespace Financial.Web.MIddlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                Console.WriteLine("Middleware was here");
                await _next(context);
            }
            catch (Exception ex)
            {
                // Log the exception, set the status code, and return a generic error response
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync("An unexpected error occurred.");
                // Log the exception details for debugging
            }
        }
    }
}

