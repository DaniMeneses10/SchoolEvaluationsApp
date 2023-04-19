using System.ComponentModel.DataAnnotations;
using System.Net;

namespace sosty.api.Helpers
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate request;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            this.request = next;
        }

        public Task Invoke(HttpContext context) => this.InvokeAsync(context);

        async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await this.request(context);
            }
            catch (Exception exception)
            {
                switch (exception)
                {
                    case var _ when exception is ValidationException:
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        // writes / returns error model to the response
                        await context.Response.WriteAsync(exception.Message);
                        break;
                    default:
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        await context.Response.WriteAsync($"{exception.Message} {exception.StackTrace}");
                        break;
                }
                context.Response.ContentType = "application/json";
                context.Response.Headers.Clear();
            }
        }
    }
}

