using System.Net;
using DDD_Example.Customer.Domain.Base;
using DDD_Example.Customer.Domain.Constants;

namespace DDD_Example.Customer.Domain.Exceptions;

public class CustomerNotFoundException : BaseException
{
    public CustomerNotFoundException() : base(HttpStatusCode.BadRequest, ExceptionMessages.UserNotFound, true)
    {
    }
}