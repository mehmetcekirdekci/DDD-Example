using DDD_Example.Customer.Api.Models.Requests;
using DDD_Example.Customer.Application.Inputs;
using MediatR;

namespace DDD_Example.Customer.Api.Mappers;

public interface ICustomerEndpointMapper
{
    public CreateCustomerCommandInput MapToCreateCustomerCommandInput(CreateCustomerRequest request);
    public ApproveMailCommandInput MapToApproveMailCommandInput(Guid customerId);
    public ApproveLicenceCommandInput MapToApproveLicenceCommandInput(Guid id);
    public PassiveCustomerCommandInput MapToPassiveCustomerCommandInput(Guid id);
    public UpdateCustomerCommandInput MapToUpdateCustomerCommandInput(Guid id, UpdateCustomerRequest request);
}

public class CustomerEndpointMapper : ICustomerEndpointMapper
{
    public CreateCustomerCommandInput MapToCreateCustomerCommandInput(CreateCustomerRequest request)
    {
        return new CreateCustomerCommandInput
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            BirthDate = request.BirthDate,
            Country = request.Country,
            City = request.City,
            Street = request.Street,
            Mail = request.Mail,
            PhoneCountryCode = request.PhoneCountryCode,
            PhoneNumber = request.PhoneNumber,
            LicenceImage = request.LicenceImage,
            Gender = request.Gender
        };
    }

    public ApproveMailCommandInput MapToApproveMailCommandInput(Guid customerId)
    {
        return new ApproveMailCommandInput
        {
            CustomerId = customerId
        };
    }
    
    public ApproveLicenceCommandInput MapToApproveLicenceCommandInput(Guid customerId)
    {
        return new ApproveLicenceCommandInput
        {
            CustomerId = customerId
        };
    }

    public PassiveCustomerCommandInput MapToPassiveCustomerCommandInput(Guid id)
    {
        return new PassiveCustomerCommandInput
        {
            CustomerId = id
        };
    }

    public UpdateCustomerCommandInput MapToUpdateCustomerCommandInput(Guid id, UpdateCustomerRequest request)
    {
        return new UpdateCustomerCommandInput
        {
            Id = id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            BirthDate = request.BirthDate,
            Country = request.Country,
            City = request.City,
            Street = request.Street,
            Mail = request.Mail,
            PhoneCountryCode = request.PhoneCountryCode,
            PhoneNumber = request.PhoneNumber,
            LicenceImage = request.LicenceImage,
            Gender = request.Gender
        };
    }
}