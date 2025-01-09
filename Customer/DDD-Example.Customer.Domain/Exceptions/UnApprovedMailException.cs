using System.Net;
using DDD_Example.Customer.Domain.Base;
using DDD_Example.Customer.Domain.Constants;

namespace DDD_Example.Customer.Domain.Exceptions;

public class UnApprovedMailException : BaseException
{
    public UnApprovedMailException() : base(HttpStatusCode.BadRequest, ExceptionMessages.UnApprovedMail, true)
    {
    }
}