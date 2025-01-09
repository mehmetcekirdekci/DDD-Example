using System.Reflection.Metadata.Ecma335;
using DDD_Example.Vehicle.Domain.Base;

namespace DDD_Example.Vehicle.Domain.Aggregates.Vehicles.ValueObjects;

public sealed class Color : ValueObject
{
    private Color()
    {
    }

    internal static Color Create(string code, string name)
    {
        if (string.IsNullOrWhiteSpace(code))
        {
            throw new ArgumentException("Invalid color code. The color code must not be null or empty.");
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Invalid color name. The color name must not be null or empty.");
        }

        return new Color
        {
            Code = code,
            Name = name
        };
    }
    public string Code { get; private init; }
    public string Name { get; private init; }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Code;
        yield return Name;
    }
}