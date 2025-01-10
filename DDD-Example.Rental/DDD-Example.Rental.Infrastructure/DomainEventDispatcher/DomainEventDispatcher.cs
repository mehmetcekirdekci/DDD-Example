using DDD_Example.Rental.Application;
using DDD_Example.Rental.Domain.Base;
using MediatR;

namespace DDD_Example.Rental.Infrastructure.DomainEventDispatcher;

public interface IDomainEventDispatcher
{ 
    Task Dispatch(IEnumerable<BaseEntity> entities, CancellationToken cancellationToken);   
}

public sealed class DomainEventDispatcher : IDomainEventDispatcher
{
    private readonly IMediator _mediator;

    public DomainEventDispatcher(IMediator mediator)
    {
        _mediator = mediator;
    }


    public async Task Dispatch(IEnumerable<BaseEntity> entities, CancellationToken cancellationToken)
    {
        foreach (var entity in entities)
        {
            var events = entity.DomainEvents.ToArray();
            entity.ClearDomainEvents();

            foreach (var domainEvent in events)
            {
                var domainEventNotification = CreateDomainEventNotification((dynamic)domainEvent);
                await _mediator.Publish(domainEventNotification, cancellationToken).ConfigureAwait(false);
            }
        }
    }

    private static DomainEventNotification<TDomainEvent>
        CreateDomainEventNotification<TDomainEvent>(TDomainEvent domainEvent) where TDomainEvent : DomainEvent
    {
        return new DomainEventNotification<TDomainEvent>(domainEvent);
    }
}