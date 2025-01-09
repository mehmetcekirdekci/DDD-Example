using System.ComponentModel.DataAnnotations.Schema;

namespace DDD_Example.Customer.Domain.Base;

public abstract class BaseEntity
{
    public Guid Id { get; protected init; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    private readonly List<DomainEvent> _domainEvents = new();
    [NotMapped] public IReadOnlyList<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(DomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}