using System.Net;
using DDD_Example.Customer.Domain.Base;
using DDD_Example.Customer.Domain.Constants;

namespace DDD_Example.Customer.Domain.Exceptions;

public class CustomerAlreadyExistException : BaseException
{
    public CustomerAlreadyExistException() : base(HttpStatusCode.BadRequest, ExceptionMessages.UserAlreadyExist, true)
    {
    }
}