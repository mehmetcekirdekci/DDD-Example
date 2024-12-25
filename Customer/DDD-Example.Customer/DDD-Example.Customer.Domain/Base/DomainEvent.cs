namespace DDD_Example.Customer.Domain.Base;

public abstract class DomainEvent
{
    public DomainEvent()
    {
        OccuredOn = DateTime.Now;
    }
    public DateTime OccuredOn { get; protected set; }
}