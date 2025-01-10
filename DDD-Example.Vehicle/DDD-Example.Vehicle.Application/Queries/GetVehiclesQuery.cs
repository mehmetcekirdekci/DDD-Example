using DDD_Example.Vehicle.Application.Inputs;
using DDD_Example.Vehicle.Application.Outputs;
using DDD_Example.Vehicle.Application.Repositories;
using DDD_Example.Vehicle.Domain.Aggregates.Vehicles.Enums;
using DDD_Example.Vehicle.Domain.Aggregates.Vehicles.Factories;
using DDD_Example.Vehicle.Domain.Aggregates.Vehicles.Models;
using DDD_Example.Vehicle.Domain.Exceptions;
using MediatR;

namespace DDD_Example.Vehicle.Application.Queries;

public class GetVehiclesQuery : IRequestHandler<GetVehiclesQueryInput, GetVehiclesQueryOutput>
{
    private readonly IVehicleReadRepository _vehicleReadRepository;

    public GetVehiclesQuery(IVehicleReadRepository vehicleReadRepository)
    {
        _vehicleReadRepository = vehicleReadRepository;
    }

    public async Task<GetVehiclesQueryOutput> Handle(GetVehiclesQueryInput input, CancellationToken cancellationToken)
    {
        var vehicles = await _vehicleReadRepository.GetListAsync(cancellationToken);
        if (vehicles is null)
        {
            return new GetVehiclesQueryOutput();
        }
        
        return new GetVehiclesQueryOutput
        {
            Vehicles = vehicles.Select(vehicle => new VehicleDto
            {
                Id = vehicle.Id,
                Plate = vehicle.Plate.Value,
                Brand = vehicle.Brand.Value,
                Type = vehicle.Type.Value,
                Year = vehicle.Year.Value,
                Color = vehicle.Color.Name,
                Mileage = vehicle.Mileage.Value
            }).ToList()
        };
    }
}