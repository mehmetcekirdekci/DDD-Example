using DDD_Example.Customer.Api.Models.Requests;
using DDD_Example.Customer.Application.Inputs;

namespace DDD_Example.Customer.Api.Mappers;

public interface ICustomerEndpointMapper
{
    public CreateCustomerCommandInput MapToCreateCustomerCommandInput(CreateCustomerRequest request);
}

public class CustomerEndpointMapper : ICustomerEndpointMapper
{
    public CreateCustomerCommandInput MapToCreateCustomerCommandInput(CreateCustomerRequest request)
    {
        return new CreateCustomerCommandInput();
    }
}