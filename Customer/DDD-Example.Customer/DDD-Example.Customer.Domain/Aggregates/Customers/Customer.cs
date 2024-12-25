using System.Net.Mail;
using DDD_Example.Customer.Domain.Aggregates.Customers.Enums;
using DDD_Example.Customer.Domain.Aggregates.Customers.ValueObjects;
using DDD_Example.Customer.Domain.Base;

namespace DDD_Example.Customer.Domain.Aggregates.Customers;

public class Customer : BaseEntity, IAggregateRoot
{
    private Customer()
    {
    }

    internal static Customer Create()
    {
        return new Customer
        {
            Id = Guid.NewGuid(),
            Name = Name.Create("sefa", "çekirdekci"),
            BirthDate = BirthDate.Create(DateOnly.MinValue),
            Address = Address.Create(),
            Mail = Mail.Create("sefa@gmail.com"),
            Gender = Gender.Male,
            Status = Status.Active,
        };
    }

    public Name Name { get; private init; }
    public BirthDate BirthDate { get; private init; }
    public Address Address { get; private init; }
    public Mail Mail { get; private init; }
    public Gender Gender { get; private init; }
    public Status Status { get; private init; }
}