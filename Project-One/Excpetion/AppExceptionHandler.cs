using Microsoft.AspNetCore.Diagnostics;

namespace Project_One.Excpetion
{
    public class AppExceptionHandler(ILogger<AppExceptionHandler> logger) : IExceptionHandler{
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, 
            CancellationToken cancellationToken){

            logger.LogError(exception, exception.Message);

            var response = new
            {
                message = exception.Message,
                statusCode = StatusCodes.Status500InternalServerError
            };
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
            return true;
        }
    }
}
