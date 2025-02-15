using Asp.Versioning;
using DDD_Example.Vehicle.Api.EndpointHandlers.V1;

namespace DDD_Example.Vehicle.Api.EndpointMappings.V1;

public static class VehicleEndpoints
{
    public static void MapVehicleEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var groupBuilder = endpoints.MapGroup("/v{version:apiVersion}/vehicles");
        
        var apiVersionset = groupBuilder.NewApiVersionSet()
            .HasApiVersion(new ApiVersion(1))
            .ReportApiVersions()
            .Build();
        
        groupBuilder.MapPost("", VehicleHandlers.Create)
            .WithName("Create")
            .WithApiVersionSet(apiVersionset)
            .MapToApiVersion(1);
        
        groupBuilder.MapDelete("/{id}", VehicleHandlers.Delete)
            .WithName("Delete")
            .WithApiVersionSet(apiVersionset)
            .MapToApiVersion(1);
        
        groupBuilder.MapPut("/{id}/price", VehicleHandlers.UpdatePrice)
            .WithName("UpdatePrice")
            .WithApiVersionSet(apiVersionset)
            .MapToApiVersion(1);
        
        groupBuilder.MapGet("/{id}", VehicleHandlers.GetVehicle)
            .WithName("GetVehicle")
            .WithApiVersionSet(apiVersionset)
            .MapToApiVersion(1);
        
        groupBuilder.MapGet("", VehicleHandlers.GetVehicles)
            .WithName("GetVehicles")
            .WithApiVersionSet(apiVersionset)
            .MapToApiVersion(1);
    }
}