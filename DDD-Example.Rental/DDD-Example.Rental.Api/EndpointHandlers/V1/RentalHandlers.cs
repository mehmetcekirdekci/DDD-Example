using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DDD_Example.Rental.Api.EndpointHandlers.V1;

public static class RentalHandlers
{
    public static async Task<Results<ProblemHttpResult, Created, BadRequest>> Create(
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken)
    {
        //var commandInput = mapper.MapToCreateVehicleCommandInput(request);
        
        //await mediator.Send(commandInput, cancellationToken);
        
        return TypedResults.Created();
    }
}