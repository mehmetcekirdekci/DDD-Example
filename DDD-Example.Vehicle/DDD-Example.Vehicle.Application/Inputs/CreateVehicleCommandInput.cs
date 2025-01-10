using DDD_Example.Vehicle.Domain.Aggregates.Vehicles.Enums;
using MediatR;

namespace DDD_Example.Vehicle.Application.Inputs;

public class CreateVehicleCommandInput : IRequest
{
    public string Plate { get; init; }
    public int Year { get; init; }
    public int PriceCurrency { get; init; }
    public decimal PriceAmount { get; init; }
    public string Brand { get; init; }
    public string Type { get; init; }
    public string ColorCode { get; init; }
    public string ColorName { get; init; }
    public int Mileage { get; init; }
}