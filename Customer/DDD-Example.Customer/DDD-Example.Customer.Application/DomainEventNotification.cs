using DDD_Example.Customer.Domain.Base;
using MediatR;

namespace DDD_Example.Customer.Application;

public class DomainEventNotification<TDomainEvent> : INotification where TDomainEvent : DomainEvent
{
    public DomainEventNotification(TDomainEvent domainEvent)
    {
        DomainEvent = domainEvent;
    }

    public DomainEvent DomainEvent { get; }
}