using DDD_Example.Vehicle.Domain.Base;

namespace DDD_Example.Vehicle.Domain.Aggregates.Vehicles.ValueObjects;

public sealed class Brand : ValueObject
{
    private Brand()
    {
    }
    
    internal static Brand Create(string brand)
    {
        if (string.IsNullOrWhiteSpace(brand))
        {
            throw new ArgumentException("Invalid brand. The brand must not be null or empty.");
        }

        return new Brand
        {
            Value = brand
        };
    }

    public string Value { get; private init; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}