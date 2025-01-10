using DDD_Example.Vehicle.Api.Models.Requests;
using DDD_Example.Vehicle.Api.Models.Responses;
using DDD_Example.Vehicle.Application.Inputs;
using DDD_Example.Vehicle.Application.Outputs;
using DDD_Example.Vehicle.Domain.Aggregates.Vehicles.Enums;

namespace DDD_Example.Vehicle.Api.Mappers;

public interface IVehicleEndpointMapper
{
    public CreateVehicleCommandInput MapToCreateVehicleCommandInput(CreateVehicleRequest request);
    public DeleteVehicleCommandInput MapToDeleteVehicleCommandInput(Guid id);
    public UpdateVehiclePriceCommandInput MapToUpdateVehiclePriceCommandInput(Guid id, int currency, decimal amount);
    public GetVehicleQueryInput MapToGetVehicleQueryInput(Guid id);
    public GetVehicleResponse MapToGetVehicleResponse(GetVehicleQueryOutput output);

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

    public DeleteVehicleCommandInput MapToDeleteVehicleCommandInput(Guid id)
    {
        return new DeleteVehicleCommandInput
        {
            Id = id
        };
    }

    public UpdateVehiclePriceCommandInput MapToUpdateVehiclePriceCommandInput(Guid id, int currency, decimal amount)
    {
        return new UpdateVehiclePriceCommandInput
        {
            Id = id,
            PriceCurrency = currency,
            PriceAmount = amount
        };
    }

    public GetVehicleQueryInput MapToGetVehicleQueryInput(Guid id)
    {
        return new GetVehicleQueryInput
        {
            Id = id
        };
    }

    public GetVehicleResponse MapToGetVehicleResponse(GetVehicleQueryOutput output)
    {
        return new GetVehicleResponse
        {
            Id = output.Id,
            Plate = output.Plate,
            Year = output.Year,
            Brand = output.Brand,
            Type = output.Type,
            Color = output.Color,
            Mileage = output.Mileage
        };
    }
}