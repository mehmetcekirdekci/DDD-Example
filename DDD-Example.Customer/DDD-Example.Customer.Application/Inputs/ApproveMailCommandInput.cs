using MediatR;

namespace DDD_Example.Customer.Application.Inputs;

public class ApproveMailCommandInput : IRequest
{
    public Guid CustomerId { get; init; }
}