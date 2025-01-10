namespace DDD_Example.Vehicle.Application.Repositories;

public interface IVehicleRepository
{
    public Task<bool> IsExistAsync(string plate, CancellationToken cancellationToken);
    public void Add(Domain.Aggregates.Vehicles.Vehicle vehicle);
}