using DDD_Example.Vehicle.Api.Mappers;
using DDD_Example.Vehicle.Api.Models.Requests;
using DDD_Example.Vehicle.Api.Models.Responses;
using DDD_Example.Vehicle.Application.Inputs;
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

    public static async Task<Results<ProblemHttpResult, NoContent, BadRequest>> UpdatePrice(
        [FromBody] UpdateVehiclePriceRequest request,
        [FromRoute] Guid id,
        [FromServices] IVehicleEndpointMapper mapper,
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var commandInput = mapper.MapToUpdateVehiclePriceCommandInput(id, request.PriceCurrency, request.PriceAmount);
        
        await mediator.Send(commandInput, cancellationToken);
        
        return TypedResults.NoContent();
    }
    
    public static async Task<Results<ProblemHttpResult, Ok<GetVehicleResponse>, BadRequest>> GetVehicle(
        [FromRoute] Guid id,
        [FromServices] IVehicleEndpointMapper mapper,
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var queryInput = mapper.MapToGetVehicleQueryInput(id);
        
        var queryOutput = await mediator.Send(queryInput, cancellationToken);
        
        var response = mapper.MapToGetVehicleResponse(queryOutput);
        
        return TypedResults.Ok(response);
    }

    public static async Task<Results<ProblemHttpResult, Ok<GetVehiclesResponse>, BadRequest>> GetVehicles(
        [FromServices] IVehicleEndpointMapper mapper,
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken)
    {
        var queryOutput = await mediator.Send(new GetVehiclesQueryInput(), cancellationToken);
        
        var response = mapper.MapToGetVehiclesResponse(queryOutput);
        
        return TypedResults.Ok(response);
    }
}