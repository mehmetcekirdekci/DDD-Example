using DDD_Example.Vehicle.Domain.Base;

namespace DDD_Example.Vehicle.Domain.Aggregates.Vehicles.ValueObjects;

public sealed class Plate : ValueObject
{
    private Plate()
    {
    }


    internal static Plate Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Invalid plate. The plate must not be null or empty.");
        }

        return new Plate
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