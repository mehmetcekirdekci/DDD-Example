using DDD_Example.Customer.Application.Inputs;
using DDD_Example.Customer.Application.Repositories;
using DDD_Example.Customer.Domain.Aggregates.Customers.Enums;
using DDD_Example.Customer.Domain.Aggregates.Customers.Factories;
using DDD_Example.Customer.Domain.Aggregates.Customers.Models;
using DDD_Example.Customer.Domain.Exceptions;
using MediatR;

namespace DDD_Example.Customer.Application.Commands;

public class UpdateCustomerCommand : IRequestHandler<UpdateCustomerCommandInput>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ICustomerFactory _customerFactory;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCustomerCommand(ICustomerRepository customerRepository, ICustomerFactory customerFactory,
        IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _customerFactory = customerFactory;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateCustomerCommandInput input, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(input.Id, cancellationToken);
        if (customer is null || customer.Status == Status.Passive)
        {
            throw new CustomerNotFoundException();
        }

        var newCustomerExist = await _customerRepository.IsAnotherExistAsync(input.Id, input.Mail, input.PhoneCountryCode,
            input.PhoneNumber, cancellationToken);
        if (newCustomerExist)
        {
            throw new CustomerAlreadyExistException();
        }

        customer.Update(new CustomerUpdateModel
        {
            FirstName = input.FirstName,
            LastName = input.LastName,
            BirthDate = input.BirthDate,
            Country = input.Country,
            City = input.City,
            Street = input.Street,
            Email = input.Mail,
            CountryCode = input.PhoneCountryCode,
            PhoneNumber = input.PhoneNumber,
            LicenceImage = input.LicenceImage
        });

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}