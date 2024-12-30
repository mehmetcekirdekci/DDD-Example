using Asp.Versioning;
using DDD_Example.Customer.Api.EndpointHandlers.V1;

namespace DDD_Example.Customer.Api.EndpointMappings.V1;

public static class CustomerEndpoints
{
    public static void MapCustomerEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var groupBuilder = endpoints.MapGroup("/v{version:apiVersion}/customers");
        
        var apiVersionset = groupBuilder.NewApiVersionSet()
            .HasApiVersion(new ApiVersion(1))
            .ReportApiVersions()
            .Build();
        
        groupBuilder.MapPost("", CustomerHandlers.Create)
            .WithName("Create")
            .WithApiVersionSet(apiVersionset)
            .MapToApiVersion(1);
    }
}