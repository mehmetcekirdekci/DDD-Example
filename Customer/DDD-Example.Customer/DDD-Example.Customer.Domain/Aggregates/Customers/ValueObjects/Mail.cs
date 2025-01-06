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
            Value = email,
            IsApproved = false
        };
    }
    
    public string Value { get; private init; }
    public bool IsApproved { get; private init; }
    
    internal Mail Approve()
    {
        return new Mail
        {
            IsApproved = true,
            Value = Value
        };
    }
    
    public Mail UnApprove()
    {
        return new Mail
        {
            IsApproved = false,
            Value = Value
        };
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}