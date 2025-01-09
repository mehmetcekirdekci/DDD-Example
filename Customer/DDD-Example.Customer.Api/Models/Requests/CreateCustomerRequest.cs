using DDD_Example.Customer.Domain.Aggregates.Customers.Enums;

namespace DDD_Example.Customer.Api.Models.Requests;

public class CreateCustomerRequest
{
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