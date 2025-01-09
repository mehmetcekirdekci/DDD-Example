using DDD_Example.Customer.Application.Outputs;
using MediatR;

namespace DDD_Example.Customer.Application.Inputs;

public class UpdateCustomerCommandInput : IRequest
{
    public Guid Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public DateOnly BirthDate { get; init; }
    public string Country { get; init; }
    public string City { get; init; }
    public string Street { get; init; }
    public string Mail { get; init; }
    public string PhoneCountryCode { get; init; }
    public string PhoneNumber { get; init; }
    public string LicenceImage { get; init; }
    public int Gender { get; init; }
}