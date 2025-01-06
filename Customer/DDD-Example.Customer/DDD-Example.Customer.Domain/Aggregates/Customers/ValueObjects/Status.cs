using DDD_Example.Customer.Domain.Aggregates.Customers.Policies;
using DDD_Example.Customer.Domain.Base;
using DDD_Example.Customer.Domain.Exceptions;

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

    internal Status ApproveMail()
    {
        return new Status
        {
            IsActive = true,
            MailStatus = MailStatus.Create(true),
            LicenceStatus = LicenceStatus
        };
    }

    public Status ApproveLicence()
    {
        if (!MailPolicy.IsAllowed(MailStatus))
        {
            throw new UnApprovedMailException();
        }
        
        return new Status
        {
            IsActive = IsActive,
            MailStatus = MailStatus,
            LicenceStatus = LicenceStatus.Create(true)
        };
    }

    public Status Activate()
    {
        if (!MailPolicy.IsAllowed(MailStatus))
        {
            throw new UnApprovedMailException();
        }
        
        return new Status
        {
            IsActive = true,
            MailStatus = MailStatus,
            LicenceStatus = LicenceStatus
        };
    }

    public Status Passive()
    {
        return new Status
        {
            IsActive = false,
            MailStatus = MailStatus.Create(false),
            LicenceStatus = LicenceStatus.Create(false)
        };
    }
}