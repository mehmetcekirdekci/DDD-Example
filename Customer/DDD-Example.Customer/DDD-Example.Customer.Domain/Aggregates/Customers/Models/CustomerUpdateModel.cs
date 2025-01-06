using DDD_Example.Customer.Domain.Aggregates.Customers.Enums;

namespace DDD_Example.Customer.Domain.Aggregates.Customers.Models;

public class CustomerUpdateModel
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public DateOnly BirthDate { get; init; }
    public string Country { get; init; }
    public string City { get; init; }
    public string Street { get; init; }
    public string Email { get; init; }
    public string CountryCode { get; init; }
    public string PhoneNumber { get; init; }
    public string LicenceImage { get; init; }
    public Gender Gender { get; init; }
}