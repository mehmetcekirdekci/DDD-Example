using DDD_Example.Customer.Domain.Base;

namespace DDD_Example.Customer.Domain.Aggregates.Customers.ValueObjects;

public sealed class Address : ValueObject
{
    private Address()
    {
        
    }

    internal static Address Create(string country,  string city, string street)
    {
        if (string.IsNullOrWhiteSpace(country))
        {
            throw new ArgumentException($"{nameof(Country)} cannot be null or whitespace.");
        }

        if (string.IsNullOrWhiteSpace(city))
        {
            throw new ArgumentException($"{nameof(City)} cannot be null or whitespace.");
        }

        if (string.IsNullOrWhiteSpace(street))
        {
            throw new ArgumentException($"{nameof(Street)} cannot be null or whitespace.");
        }
        
        return new Address
        {
            Country = null,
            City = null,
            Street = null
        };
    }

    public string Country { get; private init; }
    public string City { get; private init; }
    public string Street { get; private init; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Country;
        yield return City;
        yield return Street;
    }
}