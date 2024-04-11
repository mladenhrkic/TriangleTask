namespace WebApi.Middleware
{
    public class GlobalExceptionHandlingMiddleware(
        ILogger<GlobalExceptionHandlingMiddleware> logger) : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger = logger;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, message: ex.Message);
                await context.Response.WriteAsync(ex.Message);
            }
        }
    }
}