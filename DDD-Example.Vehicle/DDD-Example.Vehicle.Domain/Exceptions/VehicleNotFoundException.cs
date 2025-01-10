using System.Net;
using DDD_Example.Vehicle.Domain.Base;
using DDD_Example.Vehicle.Domain.Constants;

namespace DDD_Example.Vehicle.Domain.Exceptions;

public class VehicleNotFoundException : BaseException
{
    public VehicleNotFoundException() : base(HttpStatusCode.BadRequest, ExceptionMessages.VehicleNotFound, true)
    {
    }
}