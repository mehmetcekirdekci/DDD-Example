using DDD_Example.Customer.Application.Inputs;
using DDD_Example.Customer.Application.Outputs;
using MediatR;

namespace DDD_Example.Customer.Application.Commands;

public class CreateCustomerCommand : IRequestHandler<CreateCustomerCommandInput, CreateCustomerCommandOutput>
{
    public async Task<CreateCustomerCommandOutput> Handle(CreateCustomerCommandInput request, CancellationToken cancellationToken)
    {
        return new CreateCustomerCommandOutput();
    }
}