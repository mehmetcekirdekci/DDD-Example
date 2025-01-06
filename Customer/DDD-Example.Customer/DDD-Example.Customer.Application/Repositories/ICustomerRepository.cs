namespace DDD_Example.Customer.Application.Repositories;

public interface ICustomerRepository
{
    public Task<bool> IsUserExistAsync(string mail, CancellationToken cancellationToken);
    public void Add(Domain.Aggregates.Customers.Customer customer);
    public Task<Domain.Aggregates.Customers.Customer> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}