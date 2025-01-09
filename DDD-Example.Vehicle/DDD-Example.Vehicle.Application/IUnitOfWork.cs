namespace DDD_Example.Vehicle.Application;

public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}