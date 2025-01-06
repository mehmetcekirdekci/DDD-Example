using DDD_Example.Customer.Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DDD_Example.Customer.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

public class CustomerRepository(CustomerDbContext customerDbContext) : ICustomerRepository
{
    public async Task<bool> IsUserExistAsync(string mail, CancellationToken cancellationToken)
    {
        return await customerDbContext.Customers.AsNoTracking().AnyAsync(x => x.Mail.Value.Equals(mail), cancellationToken)
            .ConfigureAwait(false);
    }

    public void Add(Domain.Aggregates.Customers.Customer customer)
    {
        customerDbContext.Customers.Add(customer);
    }

    public async Task<Domain.Aggregates.Customers.Customer> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await customerDbContext.Customers.FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken).ConfigureAwait(false);
    }
}