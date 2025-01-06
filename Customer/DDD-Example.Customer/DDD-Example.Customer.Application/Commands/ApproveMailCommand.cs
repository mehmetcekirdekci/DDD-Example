using DDD_Example.Customer.Application.Inputs;
using DDD_Example.Customer.Application.Repositories;
using DDD_Example.Customer.Domain.Exceptions;
using MediatR;

namespace DDD_Example.Customer.Application.Commands;

public class ApproveMailCommand : IRequestHandler<ApproveMailCommandInput>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ApproveMailCommand(ICustomerRepository customerRepository,IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(ApproveMailCommandInput input, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(input.CustomerId, cancellationToken);
        if (customer is null)
        {
            throw new CustomerNotFoundException();
        }
        
        customer.ApproveMail();
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}