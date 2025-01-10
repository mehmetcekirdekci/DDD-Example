using DDD_Example.Rental.Domain.Base;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace DDD_Example.Rental.Api.Middlewares;

public class DomainExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not BaseException baseException)
        {
            return false;
        }
        
        var problemDetails = new ProblemDetails
        {
            Title = baseException.Message,
            Status = (int)baseException.HttpStatusCode,
            Detail = exception.Message
        };

        if (baseException.ShouldBeIncludedInResponse)
        {
            problemDetails.Detail = baseException.Message;
        }
        
        httpContext.Response.StatusCode = (int)baseException.HttpStatusCode;
        
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
        
        return true;
    }
}