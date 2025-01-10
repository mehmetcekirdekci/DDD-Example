using DDD_Example.Vehicle.Api.Models.Requests;
using DDD_Example.Vehicle.Application.Inputs;
using DDD_Example.Vehicle.Domain.Aggregates.Vehicles.Enums;

namespace DDD_Example.Vehicle.Api.Mappers;

public interface IVehicleEndpointMapper
{
    public CreateVehicleCommandInput MapToCreateVehicleCommandInput(CreateVehicleRequest request);
}

public class VehicleEndpointMapper : IVehicleEndpointMapper
{
    public CreateVehicleCommandInput MapToCreateVehicleCommandInput(CreateVehicleRequest request)
    {
        return new CreateVehicleCommandInput
        {
            Plate = request.Plate,
            Year = request.Year,
            PriceCurrency = request.PriceCurrency,
            PriceAmount = request.PriceAmount,
            Brand = request.Brand,
            Type = request.Type,
            ColorCode = request.ColorCode,
            ColorName = request.ColorName,
            Mileage = request.Mileage
        };
    }
}