using DDD_Example.Vehicle.Api.Mappers;
using DDD_Example.Vehicle.Api.Models.Requests;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DDD_Example.Vehicle.Api.EndpointHandlers.V1;

public static class VehicleHandlers
{
    public static async Task<Results<ProblemHttpResult, Created, BadRequest>> Create(
        [FromBody] CreateVehicleRequest request, 
        [FromServices] IVehicleEndpointMapper mapper,
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var commandInput = mapper.MapToCreateVehicleCommandInput(request);
        
        await mediator.Send(commandInput, cancellationToken);
        
        return TypedResults.Created();
    }

    public static async Task<Results<ProblemHttpResult, NoContent, BadRequest>> Delete(
        [FromRoute] Guid id,
        [FromServices] IVehicleEndpointMapper mapper,
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var commandInput = mapper.MapToDeleteVehicleCommandInput(id);
        
        await mediator.Send(commandInput, cancellationToken);
        
        return TypedResults.NoContent();
    }
}