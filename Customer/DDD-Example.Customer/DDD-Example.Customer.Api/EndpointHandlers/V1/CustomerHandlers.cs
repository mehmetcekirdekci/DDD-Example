using DDD_Example.Customer.Api.Models.Requests;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DDD_Example.Customer.Api.EndpointHandlers.V1;

public static class CustomerHandlers
{
    public static async Task<Results<ProblemHttpResult, Created, BadRequest>> Create(
        [FromBody] CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        return TypedResults.Created();
    }
}