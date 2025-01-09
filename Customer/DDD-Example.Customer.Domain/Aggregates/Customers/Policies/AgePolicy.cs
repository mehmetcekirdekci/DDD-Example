namespace DDD_Example.Customer.Domain.Aggregates.Customers.Policies;

public class AgePolicy
{
    public static bool IsAllowed(DateOnly birthDate)
    {
        var now = DateTime.UtcNow;
        return birthDate <= new DateOnly(now.Year - 18, now.Month, now.Day);
    }
}