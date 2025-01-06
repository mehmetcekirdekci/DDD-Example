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
            Licence = Licence.Create(createModel.LicenceImage),
            Gender = createModel.Gender,
            Status = Status.Passive
        };
    }

    public Name Name { get; private set; }
    public BirthDate BirthDate { get; private set; }
    public Address Address { get; private set; }
    public Mail Mail { get; private set; }
    public Phone Phone { get; private set; }
    public Licence Licence { get; private set; }
    public Gender Gender { get; private set; }
    public Status Status { get; private set; }
    
    public void ApproveMail()
    {
        Mail = Mail.Approve();
        Status = Status.Active;
    }

    public void ApproveLicence()
    {
        Licence = Licence.Approve();
    }

    public void Passive()
    {
        Status = Status.Passive;
        Mail = Mail.UnApprove();
        Licence = Licence.UnApprove();
    }

    public void Update(CustomerUpdateModel customerUpdateModel)
    {
        Name = Name.Create(customerUpdateModel.FirstName, customerUpdateModel.LastName);
        BirthDate = BirthDate.Create(customerUpdateModel.BirthDate);
        Address = Address.Create(customerUpdateModel.Country, customerUpdateModel.City, customerUpdateModel.Street);
        Mail = Mail.Create(customerUpdateModel.Email);
        Phone = Phone.Create(customerUpdateModel.CountryCode, customerUpdateModel.PhoneNumber);
        Licence = Licence.Create(customerUpdateModel.LicenceImage);
        Gender = customerUpdateModel.Gender;
    }
}