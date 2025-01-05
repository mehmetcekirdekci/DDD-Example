using System.Data.Entity;
using DDD_Example.Customer.Application.Repositories;

namespace DDD_Example.Customer.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

public class CustomerRepository(CustomerDbContext customerDbContext) : ICustomerRepository
{
    public async Task<bool> IsUserExistAsync(string mail, CancellationToken cancellationToken)
    {
        return await customerDbContext.Customers.AnyAsync(x => x.Mail.Value.Equals(mail), cancellationToken);
    }

    public void Add(Domain.Aggregates.Customers.Customer customer)
    {
        customerDbContext.Customers.Add(customer);
    }
}