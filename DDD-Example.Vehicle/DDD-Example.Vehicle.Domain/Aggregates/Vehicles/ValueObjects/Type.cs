using DDD_Example.Vehicle.Domain.Base;

namespace DDD_Example.Vehicle.Domain.Aggregates.Vehicles.ValueObjects;

public sealed class Type : ValueObject
{
    private Type()
    {
    }
    
    internal static Type Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Invalid type. The type must not be null or empty.");
        }

        return new Type
        {
            Value = value
        };
    }

    public string Value { get; private init; }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}