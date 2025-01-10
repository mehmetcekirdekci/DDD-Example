using DDD_Example.Vehicle.Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DDD_Example.Vehicle.Infrastructure.Persistence.Repositories;

public class VehicleReadRepository(VehicleDbContext vehicleDbContext) : IVehicleReadRepository
{
    public async Task<Domain.Aggregates.Vehicles.Vehicle> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await vehicleDbContext.Vehicles.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken)
            .ConfigureAwait(false);
    }

    public async Task<List<Domain.Aggregates.Vehicles.Vehicle>> GetListAsync(CancellationToken cancellationToken)
    {
        return await vehicleDbContext.Vehicles.AsNoTracking().ToListAsync(cancellationToken)
            .ConfigureAwait(false);
    }
}