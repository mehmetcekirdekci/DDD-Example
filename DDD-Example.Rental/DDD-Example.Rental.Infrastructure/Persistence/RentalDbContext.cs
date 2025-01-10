using DDD_Example.Rental.Application;
using DDD_Example.Rental.Domain.Base;
using DDD_Example.Rental.Infrastructure.DomainEventDispatcher;
using Microsoft.EntityFrameworkCore;

namespace DDD_Example.Rental.Infrastructure.Persistence;

public sealed class RentalDbContext : DbContext, IUnitOfWork
{
    private readonly IDomainEventDispatcher _domainEventDispatcher;

    public RentalDbContext(DbContextOptions<RentalDbContext> options,
        IDomainEventDispatcher domainEventDispatcher) : base(options)
    {
        _domainEventDispatcher = domainEventDispatcher;
    }

    public DbSet<Domain.Aggregates.Rentals.Rental> Vehicles { get; set; }
    
    async Task<int> IUnitOfWork.SaveChangesAsync(CancellationToken cancellationToken)
    {
        AddTimeStamps();
        var result = await SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        if (_domainEventDispatcher is null)
        {
            return result;
        }

        var domainEvents = ChangeTracker
            .Entries()
            .Select(e => e.Entity as BaseEntity)
            .Where(e => e?.DomainEvents is not null && e.DomainEvents.Any())
            .ToArray();

        await _domainEventDispatcher.Dispatch(domainEvents, cancellationToken).ConfigureAwait(false);

        return result;
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RentalDbContext).Assembly);
    }
    
    private void AddTimeStamps()
    {
        var entities = ChangeTracker
            .Entries()
            .Where(e => e.Entity is BaseEntity && (e.State is EntityState.Added or EntityState.Modified));

        foreach (var entity in entities)
        {
            var now = DateTime.UtcNow;
            if (entity.State == EntityState.Added)
            {
                ((BaseEntity)entity.Entity).CreatedAt = now;
            }
            ((BaseEntity)entity.Entity).UpdatedAt = now;
        }
    }
}