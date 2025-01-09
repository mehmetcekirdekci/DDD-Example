using DDD_Example.Customer.Application.Inputs;
using DDD_Example.Customer.Application.Repositories;
using DDD_Example.Customer.Domain.Exceptions;
using MediatR;

namespace DDD_Example.Customer.Application.Commands;

public class ApproveLicenceCommand : IRequestHandler<ApproveLicenceCommandInput>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ApproveLicenceCommand(ICustomerRepository customerRepository,IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(ApproveLicenceCommandInput input, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(input.CustomerId, cancellationToken);
        if (customer is null)
        {
            throw new CustomerNotFoundException();
        }
        
        customer.ApproveLicence();
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}