using DDD_Example.Customer.Domain.Base;

namespace DDD_Example.Customer.Domain.Aggregates.Customers.ValueObjects;

public sealed class Status : ValueObject
{
    private Status()
    {
    }

    internal static Status Create(bool isActive, MailStatus mailStatus, LicenceStatus licenceStatus)
    {
        return new Status
        {
            IsActive = isActive,
            MailStatus = mailStatus,
            LicenceStatus = licenceStatus
        };
    }
    
    public bool IsActive { get; private init; }
    public MailStatus MailStatus { get; private init; }
    public LicenceStatus LicenceStatus { get; private init; }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return IsActive;
        yield return MailStatus;
        yield return LicenceStatus;
    }
}