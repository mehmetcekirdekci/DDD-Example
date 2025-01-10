namespace DDD_Example.Vehicle.Api.Models.Responses;

public class GetVehiclesResponse
{
    public List<VehicleDto> Vehicles { get; init; }
}

public class VehicleDto
{
    public Guid Id { get; init; }
    public string Plate { get; init; }
    public int Year { get; init; }
    public string Brand { get; init; }
    public string Type { get; init; }
    public string Color { get; init; }
    public int Mileage { get; init; }
}