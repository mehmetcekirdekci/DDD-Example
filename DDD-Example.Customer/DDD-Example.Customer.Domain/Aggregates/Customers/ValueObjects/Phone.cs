using DDD_Example.Customer.Domain.Base;

namespace DDD_Example.Customer.Domain.Aggregates.Customers.ValueObjects;

public sealed class Phone : ValueObject
{
    private Phone()
    {
    }

    internal static Phone Create(string countryCode, string number)
    {
        if (string.IsNullOrWhiteSpace(countryCode))
        {
            throw new ArgumentException($"{nameof(CountryCode)} cannot be null or whitespace.");
        }

        if (string.IsNullOrWhiteSpace(number))
        {
            throw new ArgumentException($"{nameof(Number)} cannot be null or whitespace.");
        }
        
        return new Phone
        {
            CountryCode = countryCode,
            Number = number
        };
    }
    
    public string CountryCode { get; private init; }
    public string Number { get; private init; }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return CountryCode;
        yield return Number;
    }
}