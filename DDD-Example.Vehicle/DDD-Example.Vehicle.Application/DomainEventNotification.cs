using DDD_Example.Vehicle.Domain.Base;
using MediatR;

namespace DDD_Example.Vehicle.Application;

public class DomainEventNotification<TDomainEvent> : INotification where TDomainEvent : DomainEvent
{
    public DomainEventNotification(TDomainEvent domainEvent)
    {
        DomainEvent = domainEvent;
    }

    public DomainEvent DomainEvent { get; }
}