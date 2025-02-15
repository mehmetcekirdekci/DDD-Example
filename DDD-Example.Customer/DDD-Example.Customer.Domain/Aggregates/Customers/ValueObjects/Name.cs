using System.ComponentModel.DataAnnotations.Schema;
using DDD_Example.Customer.Domain.Base;

namespace DDD_Example.Customer.Domain.Aggregates.Customers.ValueObjects;

public sealed class Name : ValueObject
{
    private Name()
    {
        
    }

    internal static Name Create(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new ArgumentException($"{nameof(FirstName)} cannot be null or whitespace.");
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new ArgumentException($"{nameof(LastName)} cannot be null or whitespace.");
        }
        
        return new Name
        {
            FirstName = firstName,
            LastName = lastName
        };
    }
    public string FirstName { get; private init; }
    public string LastName { get; private init; }

    public string FullName()
    {
        return FirstName + " " + LastName;
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return FirstName;
        yield return LastName;
    }
}