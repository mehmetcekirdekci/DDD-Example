using DDD_Example.Vehicle.Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DDD_Example.Vehicle.Infrastructure.Persistence.Repositories;

public class VehicleRepository(VehicleDbContext vehicleDbContext) : IVehicleRepository
{
    public async Task<bool> IsExistAsync(string plate,
        CancellationToken cancellationToken)
    {
        return await vehicleDbContext.Vehicles.AsNoTracking().AnyAsync(
                x => x.Plate.Value.Equals(plate), cancellationToken)
            .ConfigureAwait(false);
    }

    public void Add(Domain.Aggregates.Vehicles.Vehicle vehicle)
    {
        vehicleDbContext.Vehicles.Add(vehicle);
    }
}