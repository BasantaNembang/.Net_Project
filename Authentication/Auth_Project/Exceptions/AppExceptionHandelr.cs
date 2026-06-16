using Auth_Project.DTO;
using Microsoft.AspNetCore.Diagnostics;

namespace Auth_Project.Exceptions
{
    public class AppExceptionHandelr : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, 
            CancellationToken cancellationToken)
        {

            var StatusCode = exception switch
            {
                RefreshTokenNotFoundException => StatusCodes.Status401Unauthorized,
                RefreshTokenExpiredException => StatusCodes.Status401Unauthorized,
                RefreshTokenDeletionFailedException => StatusCodes.Status500InternalServerError,
                UserNotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            httpContext.Response.StatusCode = StatusCode;
            httpContext.Response.ContentType = "application/json";

            var ErrorResponse = new ErrorDTO()
            {
                Message = exception.Message,
                StatusCode = StatusCode,
            };

            await httpContext.Response.WriteAsJsonAsync(ErrorResponse, cancellationToken);

            return true;
        }
    }
}





