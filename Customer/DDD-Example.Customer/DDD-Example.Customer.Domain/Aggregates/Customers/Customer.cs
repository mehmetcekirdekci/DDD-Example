using DDD_Example.Customer.Domain.Aggregates.Customers.Enums;
using DDD_Example.Customer.Domain.Aggregates.Customers.Models;
using DDD_Example.Customer.Domain.Aggregates.Customers.ValueObjects;
using DDD_Example.Customer.Domain.Base;

namespace DDD_Example.Customer.Domain.Aggregates.Customers;

public class Customer : BaseEntity, IAggregateRoot
{
    private Customer()
    {
    }

    internal static Customer Create(CustomerCreateModel createModel)
    {
        if (!Enum.IsDefined(createModel.Gender))
        {
            throw new ArgumentException($"{nameof(Gender)} is invalid.");
        }
        
        return new Customer
        {
            Id = Guid.NewGuid(),
            Name = Name.Create(createModel.FirstName, createModel.LastName),
            BirthDate = BirthDate.Create(createModel.BirthDate),
            Address = Address.Create(createModel.Country, createModel.City, createModel.Street),
            Mail = Mail.Create(createModel.Email),
            Phone = Phone.Create(createModel.CountryCode, createModel.PhoneNumber),
            Gender = createModel.Gender,
            Status = Status.Create(false, MailStatus.Create(false), LicenceStatus.Create(false))
        };
    }

    public Name Name { get; private init; }
    public BirthDate BirthDate { get; private init; }
    public Address Address { get; private init; }
    public Mail Mail { get; private init; }
    public Phone Phone { get; private init; }
    public Gender Gender { get; private init; }
    public Status Status { get; private set; }
    
    public void ApproveMail()
    {
        Status = Status.ApproveMail();
    }

    public void ApproveLicence()
    {
        Status = Status.ApproveLicence();
    }

    public void Passive()
    {
        Status = Status.Passive();
    }
}