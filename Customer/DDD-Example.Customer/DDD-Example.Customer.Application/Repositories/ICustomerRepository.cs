namespace DDD_Example.Customer.Application.Repositories;

public interface ICustomerRepository
{
    public Task<bool> IsExistAsync(string mail, string phoneCountryCode, string phoneNumber, CancellationToken cancellationToken);

    public Task<bool> IsAnotherExistAsync(Guid id, string mail, string phoneCountryCode, string phoneNumber,
        CancellationToken cancellationToken);
    public void Add(Domain.Aggregates.Customers.Customer customer);
    public Task<Domain.Aggregates.Customers.Customer> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}