using MediatR;

namespace DDD_Example.Customer.Application.Inputs;

public class ApproveLicenceCommandInput : IRequest
{
    public Guid CustomerId { get; init; }
}