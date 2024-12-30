using DDD_Example.Customer.Api.Mappers;
using DDD_Example.Customer.Api.Models.Requests;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DDD_Example.Customer.Api.EndpointHandlers.V1;

public static class CustomerHandlers
{
    public static async Task<Results<ProblemHttpResult, Created, BadRequest>> Create(
        [FromBody] CreateCustomerRequest request, 
        [FromServices] ICustomerEndpointMapper mapper,
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var commandInput = mapper.MapToCreateCustomerCommandInput(request);
        
        await mediator.Send(commandInput, cancellationToken);
        
        return TypedResults.Created();
    }
}