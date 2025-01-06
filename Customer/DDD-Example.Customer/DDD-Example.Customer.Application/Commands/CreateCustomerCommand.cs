using DDD_Example.Customer.Application.Inputs;
using DDD_Example.Customer.Application.Repositories;
using DDD_Example.Customer.Domain.Aggregates.Customers.Enums;
using DDD_Example.Customer.Domain.Aggregates.Customers.Factories;
using DDD_Example.Customer.Domain.Aggregates.Customers.Models;
using DDD_Example.Customer.Domain.Exceptions;
using MediatR;

namespace DDD_Example.Customer.Application.Commands;

public class CreateCustomerCommand : IRequestHandler<CreateCustomerCommandInput>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ICustomerFactory _customerFactory;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCustomerCommand(ICustomerRepository customerRepository, ICustomerFactory customerFactory, IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _customerFactory = customerFactory;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateCustomerCommandInput input, CancellationToken cancellationToken)
    {
        var isUserExist = await _customerRepository.IsUserExistAsync(input.Mail, cancellationToken);
        if (isUserExist)
        {
            throw new CustomerAlreadyExistException();
        }

        var customer = _customerFactory.Create(new CustomerCreateModel
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
            Gender = (Gender)input.Gender
        });
        
        _customerRepository.Add(customer);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}