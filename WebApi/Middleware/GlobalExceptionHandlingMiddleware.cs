namespace WebApi.Middleware
{
    public class GlobalExceptionHandlingMiddleware(
        ILogger<GlobalExceptionHandlingMiddleware> logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, message: ex.Message);
                await context.Response.WriteAsync(ex.Message);
            }
        }
    }
}