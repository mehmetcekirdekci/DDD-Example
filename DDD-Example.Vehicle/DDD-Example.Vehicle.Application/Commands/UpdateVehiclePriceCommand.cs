using DDD_Example.Vehicle.Application.Inputs;
using DDD_Example.Vehicle.Application.Repositories;
using DDD_Example.Vehicle.Domain.Aggregates.Vehicles.Enums;
using DDD_Example.Vehicle.Domain.Aggregates.Vehicles.Factories;
using DDD_Example.Vehicle.Domain.Aggregates.Vehicles.Models;
using DDD_Example.Vehicle.Domain.Exceptions;
using MediatR;

namespace DDD_Example.Vehicle.Application.Commands;

public class UpdateVehiclePriceCommand : IRequestHandler<UpdateVehiclePriceCommandInput>
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IVehicleFactory _vehicleFactory;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVehiclePriceCommand(IVehicleRepository vehicleRepository, IVehicleFactory vehicleFactory, IUnitOfWork unitOfWork)
    {
        _vehicleRepository = vehicleRepository;
        _vehicleFactory = vehicleFactory;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateVehiclePriceCommandInput input, CancellationToken cancellationToken)
    {
        var vehicle = await _vehicleRepository.GetByIdAsync(input.Id, cancellationToken);
        if (vehicle == null)
        {
            throw new VehicleNotFoundException();
        }

        vehicle.UpdatePrice((Currency)input.PriceCurrency, input.PriceAmount);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}