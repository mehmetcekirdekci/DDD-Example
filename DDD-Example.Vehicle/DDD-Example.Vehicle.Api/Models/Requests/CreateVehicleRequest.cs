namespace DDD_Example.Vehicle.Api.Models.Requests;

public class CreateVehicleRequest
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