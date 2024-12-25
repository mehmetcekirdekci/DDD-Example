using DDD_Example.Customer.Domain.Base;

namespace DDD_Example.Customer.Domain.Aggregates.Customers.ValueObjects;

public sealed class Name : ValueObject
{
    private Name()
    {
        
    }

    internal static Name Create(string firstName, string lastName)
    {
        if (firstName is null)
        {
            
        }

        if (lastName is null)
        {
            
        }
        
        return new Name
        {
            Value = firstName + " " + lastName,
            FirstName = firstName,
            LastName = lastName
        };
    }

    public string Value { get; private init; }
    public string FirstName { get; private init; }
    public string LastName { get; private init; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return FirstName;
        yield return LastName;
    }
}