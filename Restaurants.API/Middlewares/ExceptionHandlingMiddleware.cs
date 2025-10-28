
namespace Restaurants.API.Middlewares
{
    public class ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch(Exception ex)
            {
                logger.LogError(ex, ex.Message);

                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something went wrong!");

                context.Response.ContentType = "application/json";
                var response = new
                {
                    Message = "An unexpected error occurred. Please try again later."
                };
                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
