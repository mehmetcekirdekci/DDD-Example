using System.Net;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace DDD_Example.Vehicle.Api.Middlewares;

public sealed class ValidationFilter<T> : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var validator = context.HttpContext.RequestServices.GetRequiredService<IValidator<T>>();
        
        var argToValidate = (T)context.Arguments.FirstOrDefault(x => x?.GetType() == typeof(T));
        if (argToValidate is null)
        {
            return Results.UnprocessableEntity();
        }

        var validationResult = await validator.ValidateAsync(argToValidate!);
        if (!validationResult.IsValid)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return new ProblemDetails
            {
                Status = (int)HttpStatusCode.BadRequest,
                Errors = validationResult.ToDictionary(),
                Title = "Request is not valid"
            };
        }

        return await next.Invoke(context);
    }
}

public class ProblemDetails : ValidationProblemDetails {}