using DDD_Example.Customer.Domain.Base;

namespace DDD_Example.Customer.Domain.Aggregates.Customers.ValueObjects;

public sealed class MailStatus : ValueObject
{
    private MailStatus()
    {
    }

    internal static MailStatus Create(bool isApproved)
    {
        return new MailStatus
        {
            IsApproved = isApproved,
            UpdatedAt = DateTime.UtcNow
        };
    }
    public bool IsApproved { get; private init; }
    public DateTime UpdatedAt { get; private init; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return IsApproved;
    }
}