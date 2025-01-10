using DDD_Example.Vehicle.Application.Inputs;
using DDD_Example.Vehicle.Application.Repositories;
using DDD_Example.Vehicle.Domain.Aggregates.Vehicles.Enums;
using DDD_Example.Vehicle.Domain.Aggregates.Vehicles.Factories;
using DDD_Example.Vehicle.Domain.Aggregates.Vehicles.Models;
using DDD_Example.Vehicle.Domain.Exceptions;
using MediatR;

namespace DDD_Example.Vehicle.Application.Commands;

public class DeleteVehicleCommand : IRequestHandler<DeleteVehicleCommandInput>
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVehicleCommand(IVehicleRepository vehicleRepository, IUnitOfWork unitOfWork)
    {
        _vehicleRepository = vehicleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteVehicleCommandInput input, CancellationToken cancellationToken)
    {
        var vehicle = await _vehicleRepository.GetByIdAsync(input.Id, cancellationToken);
        if (vehicle is null)
        {
            throw new VehicleNotFoundException();
        }

        vehicle.Delete();
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}