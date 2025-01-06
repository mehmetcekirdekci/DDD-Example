using DDD_Example.Customer.Domain.Aggregates.Customers.ValueObjects;

namespace DDD_Example.Customer.Domain.Aggregates.Customers.Policies;

public class MailPolicy
{
    public static bool IsAllowed(MailStatus mailStatus)
    {
        return mailStatus.IsApproved;
    }
}