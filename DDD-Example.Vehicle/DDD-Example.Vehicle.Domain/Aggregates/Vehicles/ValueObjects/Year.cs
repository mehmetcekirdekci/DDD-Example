using System.Diagnostics;
using DDD_Example.Vehicle.Domain.Base;

namespace DDD_Example.Vehicle.Domain.Aggregates.Vehicles.ValueObjects;

public sealed class Year : ValueObject
{
    private Year()
    {
    }

    internal static Year Create(int year)
    {
        if (year < 0)
        {
            throw new ArgumentException("Invalid year. The year must be over 0.");
        }

        return new Year
        {
            Value = year
        };
    }

    public int Value { get; private init; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}