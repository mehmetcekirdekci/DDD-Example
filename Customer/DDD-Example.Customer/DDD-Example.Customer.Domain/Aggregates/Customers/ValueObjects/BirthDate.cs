using DDD_Example.Customer.Domain.Base;

namespace DDD_Example.Customer.Domain.Aggregates.Customers.ValueObjects;

public sealed class BirthDate : ValueObject
{
    private BirthDate()
    {
    }

    internal static BirthDate Create(DateOnly date)
    {
        return new BirthDate
        {
            Value = date
        };
    }
    
    public DateOnly Value { get; private init; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}