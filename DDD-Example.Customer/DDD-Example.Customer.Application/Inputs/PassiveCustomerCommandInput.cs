using MediatR;

namespace DDD_Example.Customer.Application.Inputs;

public class PassiveCustomerCommandInput : IRequest
{
    public Guid CustomerId { get; init; }
}