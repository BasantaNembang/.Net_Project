using Microsoft.AspNetCore.Diagnostics;
using MyApp.Application.Exceptions;

namespace MyApp.Api.Exceptions
{
    public class AppExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, 
            Exception exception, CancellationToken cancellationToken)
        {

            var StatusCode =  exception switch
            {
                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };


            httpContext.Response.StatusCode = StatusCode;
            httpContext.Response.ContentType = "application/json";

            var error = new ErrorDTO()
            {
                StatusCode = StatusCode,
                Message = exception.Message,
            };

            await httpContext.Response.WriteAsJsonAsync(error, cancellationToken);

            return true;

        }
    }
}



