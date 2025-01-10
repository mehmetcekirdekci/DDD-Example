namespace DDD_Example.Vehicle.Application.Repositories;

public interface IVehicleReadRepository
{
    public Task<Domain.Aggregates.Vehicles.Vehicle> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}