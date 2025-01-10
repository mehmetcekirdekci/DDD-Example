using Asp.Versioning;
using DDD_Example.Rental.Api.EndpointHandlers.V1;

namespace DDD_Example.Rental.Api.EndpointMappings.V1;

public static class RentalEndpoints
{
    public static void MapRentalEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var groupBuilder = endpoints.MapGroup("/v{version:apiVersion}/rentals");
        
        var apiVersionset = groupBuilder.NewApiVersionSet()
            .HasApiVersion(new ApiVersion(1))
            .ReportApiVersions()
            .Build();
        
        groupBuilder.MapPost("", RentalHandlers.Create)
            .WithName("Create")
            .WithApiVersionSet(apiVersionset)
            .MapToApiVersion(1);
    }
}