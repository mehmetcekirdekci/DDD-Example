using DDD_Example.Vehicle.Domain.Aggregates.Vehicles.Enums;
using MediatR;

namespace DDD_Example.Vehicle.Application.Inputs;

public class UpdateVehiclePriceCommandInput : IRequest
{
    public Guid Id { get; init; }
    public int PriceCurrency { get; init; }
    public decimal PriceAmount { get; init; }
}