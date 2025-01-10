namespace DDD_Example.Vehicle.Api.Models.Requests;

public class UpdateVehiclePriceRequest
{
    public int PriceCurrency { get; init; }
    public decimal PriceAmount { get; init; }
}