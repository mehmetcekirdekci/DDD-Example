using System.Net;
using DDD_Example.Vehicle.Domain.Base;
using DDD_Example.Vehicle.Domain.Constants;

namespace DDD_Example.Vehicle.Domain.Exceptions;

public class VehicleAlreadyExistException : BaseException
{
    public VehicleAlreadyExistException() : base(HttpStatusCode.BadRequest, ExceptionMessages.VehicleAlreadyExist, true)
    {
    }
}