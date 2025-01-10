using DDD_Example.Rental.Domain.Base;
using MediatR;

namespace DDD_Example.Rental.Application;

public class DomainEventNotification<TDomainEvent> : INotification where TDomainEvent : DomainEvent
{
    public DomainEventNotification(TDomainEvent domainEvent)
    {
        DomainEvent = domainEvent;
    }

    public DomainEvent DomainEvent { get; }
}