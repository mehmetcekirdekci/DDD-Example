using MediatR;

namespace DDD_Example.Vehicle.Application.Inputs;

public class DeleteVehicleCommandInput : IRequest
{
    public Guid Id { get; init; }
}