using System.Net;

namespace DDD_Example.Customer.Domain.Base;

public abstract class BaseException : ApplicationException
{
    public HttpStatusCode HttpStatusCode { get; }
    public bool ShouldBeIncludedInResponse { get; }
    
    protected BaseException(HttpStatusCode httpStatusCode, string message, bool shouldBeIncludedInResponse) : base(message)
    {
        HttpStatusCode = httpStatusCode;
        ShouldBeIncludedInResponse = shouldBeIncludedInResponse;
    }
}