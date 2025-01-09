using DDD_Example.Customer.Application.Inputs;
using DDD_Example.Customer.Application.Repositories;
using DDD_Example.Customer.Domain.Exceptions;
using MediatR;

namespace DDD_Example.Customer.Application.Commands;

public class PassiveCustomerCommand : IRequestHandler<PassiveCustomerCommandInput>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PassiveCustomerCommand(ICustomerRepository customerRepository,IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(PassiveCustomerCommandInput input, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(input.CustomerId, cancellationToken);
        if (customer is null)
        {
            throw new CustomerNotFoundException();
        }
        
        customer.Passive();
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}