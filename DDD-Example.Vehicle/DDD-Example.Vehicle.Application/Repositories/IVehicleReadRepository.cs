namespace DDD_Example.Vehicle.Application.Repositories;

public interface IVehicleReadRepository
{
    public Task<Domain.Aggregates.Vehicles.Vehicle> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    public Task<List<Domain.Aggregates.Vehicles.Vehicle>> GetListAsync(CancellationToken cancellationToken);
}