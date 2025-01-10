using DDD_Example.Vehicle.Application.Inputs;
using DDD_Example.Vehicle.Application.Repositories;
using DDD_Example.Vehicle.Domain.Aggregates.Vehicles.Enums;
using DDD_Example.Vehicle.Domain.Aggregates.Vehicles.Factories;
using DDD_Example.Vehicle.Domain.Aggregates.Vehicles.Models;
using DDD_Example.Vehicle.Domain.Exceptions;
using MediatR;

namespace DDD_Example.Vehicle.Application.Commands;

public class CreateVehicleCommand : IRequestHandler<CreateVehicleCommandInput>
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IVehicleFactory _vehicleFactory;
    private readonly IUnitOfWork _unitOfWork;

    public CreateVehicleCommand(IVehicleRepository vehicleRepository, IVehicleFactory vehicleFactory, IUnitOfWork unitOfWork)
    {
        _vehicleRepository = vehicleRepository;
        _vehicleFactory = vehicleFactory;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateVehicleCommandInput input, CancellationToken cancellationToken)
    {
        var isVehicleExist = await _vehicleRepository.IsExistAsync(input.Plate, cancellationToken);
        if (isVehicleExist)
        {
            throw new VehicleAlreadyExistException();
        }

        var vehicle = _vehicleFactory.Create(new VehicleCreateModel
        {
            Plate = input.Plate,
            Year = input.Year,
            PriceCurrency = (Currency)input.PriceCurrency,
            PriceAmount = input.PriceAmount,
            Brand = input.Brand,
            Type = input.Type,
            ColorCode = input.ColorCode,
            ColorName = input.ColorName,
            Mileage = input.Mileage
        });
        
        _vehicleRepository.Add(vehicle);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}