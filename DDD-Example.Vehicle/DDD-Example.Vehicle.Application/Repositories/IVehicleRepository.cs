namespace DDD_Example.Vehicle.Application.Repositories;

public interface IVehicleRepository
{
    public Task<Domain.Aggregates.Vehicles.Vehicle> GetByPlateAsync(string plate, CancellationToken cancellationToken);
    public void Add(Domain.Aggregates.Vehicles.Vehicle vehicle);
    public Task<Domain.Aggregates.Vehicles.Vehicle> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}