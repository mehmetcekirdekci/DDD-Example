namespace DDD_Example.Customer.Application.Repositories;

public interface ICustomerRepository
{
    public Task<bool> IsUserExistAsync(string mail, CancellationToken cancellationToken);
    void Add(Domain.Aggregates.Customers.Customer customer);
}