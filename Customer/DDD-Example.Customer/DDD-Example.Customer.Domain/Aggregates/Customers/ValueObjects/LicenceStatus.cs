using DDD_Example.Customer.Domain.Base;

namespace DDD_Example.Customer.Domain.Aggregates.Customers.ValueObjects;

public sealed class LicenceStatus : ValueObject
{
    private LicenceStatus()
    {
    }

    internal static LicenceStatus Create(bool isApproved)
    {
        return new LicenceStatus
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
        yield return UpdatedAt;
    }
}