using DDD_Example.Vehicle.Domain.Aggregates.Vehicles.Enums;

namespace DDD_Example.Vehicle.Domain.Aggregates.Vehicles.Models;

public class VehicleCreateModel
{
    public string Plate { get; init; }
    public int Year { get; init; }
    public Currency PriceCurrency { get; init; }
    public decimal PriceAmount { get; init; }
    public string Brand { get; init; }
    public string Type { get; init; }
    public string ColorCode { get; init; }
    public string ColorName { get; init; }
    public int Mileage { get; init; }
}