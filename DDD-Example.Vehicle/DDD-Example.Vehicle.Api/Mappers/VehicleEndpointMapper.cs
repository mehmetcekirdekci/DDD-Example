using DDD_Example.Vehicle.Api.Models.Requests;
using DDD_Example.Vehicle.Application.Inputs;

namespace DDD_Example.Vehicle.Api.Mappers;

public interface IVehicleEndpointMapper
{
    public CreateVehicleCommandInput MapToCreateVehicleCommandInput(CreateVehicleRequest request);
}

public class VehicleEndpointMapper : IVehicleEndpointMapper
{
    public CreateVehicleCommandInput MapToCreateVehicleCommandInput(CreateVehicleRequest request)
    {
        throw new NotImplementedException();
    }
}