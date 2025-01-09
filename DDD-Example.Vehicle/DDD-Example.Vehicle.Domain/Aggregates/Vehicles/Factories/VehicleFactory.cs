using DDD_Example.Vehicle.Domain.Aggregates.Vehicles.Models;

namespace DDD_Example.Vehicle.Domain.Aggregates.Vehicles.Factories;

public interface IVehicleFactory
{
    public Vehicle Create(VehicleCreateModel createModel);   
}

public class VehicleFactory : IVehicleFactory
{
    public Vehicle Create(VehicleCreateModel createModel)
    {
        return Vehicle.Create(createModel);
    }
}