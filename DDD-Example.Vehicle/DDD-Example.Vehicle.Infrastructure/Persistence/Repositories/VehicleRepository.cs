using DDD_Example.Vehicle.Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DDD_Example.Vehicle.Infrastructure.Persistence.Repositories;

public class VehicleRepository(VehicleDbContext vehicleDbContext) : IVehicleRepository
{
    public async Task<Domain.Aggregates.Vehicles.Vehicle> GetByPlateAsync(string plate,
        CancellationToken cancellationToken)
    {
        return await vehicleDbContext.Vehicles.FirstOrDefaultAsync(x => x.Plate.Value.Equals(plate), cancellationToken)
            .ConfigureAwait(false);
    }

    public void Add(Domain.Aggregates.Vehicles.Vehicle vehicle)
    {
        vehicleDbContext.Vehicles.Add(vehicle);
    }

    public async Task<Domain.Aggregates.Vehicles.Vehicle> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await vehicleDbContext.Vehicles.FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken)
            .ConfigureAwait(false);
    }
}