using DDD_Example.Vehicle.Domain.Aggregates.Vehicles.Enums;
using DDD_Example.Vehicle.Domain.Base;

namespace DDD_Example.Vehicle.Domain.Aggregates.Vehicles.ValueObjects;

public sealed class Price : ValueObject
{
    private Price()
    {
    }

    internal static Price Create(Currency currency, decimal amount)
    {
        if (Enum.IsDefined(currency))
        {
            throw new ArgumentException("Invalid currency. The currency must not be null or empty.");
        }
        
        if (amount <= 0)
        {
            throw new ArgumentException("Invalid amount. The amount must be over 0.");
        }
        
        return new Price
        {
            Currency = currency,
            Amount = amount
        };
    }

    public Currency Currency { get; private init; }
    public decimal Amount { get; private init; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Currency;
        yield return Amount;
    }
}