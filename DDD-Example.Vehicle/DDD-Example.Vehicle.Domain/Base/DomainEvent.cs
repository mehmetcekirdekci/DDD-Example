namespace DDD_Example.Vehicle.Domain.Base;

public abstract class DomainEvent
{
    public DomainEvent()
    {
        OccuredOn = DateTime.Now;
    }
    public DateTime OccuredOn { get; protected set; }
}