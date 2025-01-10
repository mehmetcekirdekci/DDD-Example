using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace DDD_Example.Rental.Api.Middlewares;

public class DefaultExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var status = StatusCodes.Status500InternalServerError;

        if (exception is BadHttpRequestException badHttpRequestException)
        {
            status = badHttpRequestException.StatusCode;
        }
        
        var problemDetails = new ProblemDetails
        {
            Title = "An error occurred while processing your request",
            Status = status,
            Detail = exception.Message
        };
        
        httpContext.Response.StatusCode = status;
        
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}