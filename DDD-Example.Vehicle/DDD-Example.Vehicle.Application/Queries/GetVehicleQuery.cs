using DDD_Example.Vehicle.Application.Inputs;
using DDD_Example.Vehicle.Application.Outputs;
using DDD_Example.Vehicle.Application.Repositories;
using DDD_Example.Vehicle.Domain.Aggregates.Vehicles.Enums;
using DDD_Example.Vehicle.Domain.Aggregates.Vehicles.Factories;
using DDD_Example.Vehicle.Domain.Aggregates.Vehicles.Models;
using DDD_Example.Vehicle.Domain.Exceptions;
using MediatR;

namespace DDD_Example.Vehicle.Application.Queries;

public class GetVehicleQuery : IRequestHandler<GetVehicleQueryInput, GetVehicleQueryOutput>
{
    private readonly IVehicleReadRepository _vehicleReadRepository;

    public GetVehicleQuery(IVehicleReadRepository vehicleReadRepository)
    {
        _vehicleReadRepository = vehicleReadRepository;
    }

    public async Task<GetVehicleQueryOutput> Handle(GetVehicleQueryInput input, CancellationToken cancellationToken)
    {
        var vehicle = await _vehicleReadRepository.GetByIdAsync(input.Id, cancellationToken);
        if (vehicle is null || vehicle.Status != Status.Active)
        {
            throw new VehicleNotFoundException();
        }
        
        return new GetVehicleQueryOutput
        {
            Id = vehicle.Id,
            Plate = vehicle.Plate.Value,
            Brand = vehicle.Brand.Value,
            Type = vehicle.Type.Value,
            Year = vehicle.Year.Value,
            Color = vehicle.Color.Name,
            Mileage = vehicle.Mileage.Value
        };
    }
}