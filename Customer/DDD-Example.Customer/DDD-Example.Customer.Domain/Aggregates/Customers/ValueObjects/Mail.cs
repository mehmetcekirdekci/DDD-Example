using DDD_Example.Customer.Domain.Base;

namespace DDD_Example.Customer.Domain.Aggregates.Customers.ValueObjects;

public sealed class Mail : ValueObject
{
    private Mail()
    {
        
    }

    internal static Mail Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException($"{nameof(Mail)} cannot be null or whitespace.");
        }
        
        return new Mail
        {
            Value = email
        };
    }
    
    public string Value { get; private init; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}