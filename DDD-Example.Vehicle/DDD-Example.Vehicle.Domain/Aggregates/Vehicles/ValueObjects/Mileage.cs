using DDD_Example.Vehicle.Domain.Base;

namespace DDD_Example.Vehicle.Domain.Aggregates.Vehicles.ValueObjects;

public sealed class Mileage : ValueObject
{
    private Mileage()
    {
    }
    
    internal static Mileage Create(int value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Invalid mileage. The mileage must be over 0.");
        }

        return new Mileage
        {
            Value = value
        };
    }
    public int Value { get; private init; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}