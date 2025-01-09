using DDD_Example.Customer.Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DDD_Example.Customer.Infrastructure.Persistence.EntityFrameworkCore.Repositories;

public class CustomerRepository(CustomerDbContext customerDbContext) : ICustomerRepository
{
    public async Task<bool> IsExistAsync(string mail, string phoneCountryCode, string phoneNumber,
        CancellationToken cancellationToken)
    {
        return await customerDbContext.Customers.AsNoTracking().AnyAsync(
                x => x.Mail.Value.Equals(mail) ||
                     (x.Phone.CountryCode.Equals(phoneCountryCode) && x.Phone.Number.Equals(phoneNumber)),
                cancellationToken)
            .ConfigureAwait(false);
    }
    
    public async Task<bool> IsAnotherExistAsync(Guid id, string mail, string phoneCountryCode, string phoneNumber,
        CancellationToken cancellationToken)
    {
        return await customerDbContext.Customers.AsNoTracking().AnyAsync(
                x => !x.Id.Equals(id) && (x.Mail.Value.Equals(mail) ||
                     x.Phone.CountryCode.Equals(phoneCountryCode) && x.Phone.Number.Equals(phoneNumber)),
                cancellationToken)
            .ConfigureAwait(false);
    }

    public void Add(Domain.Aggregates.Customers.Customer customer)
    {
        customerDbContext.Customers.Add(customer);
    }

    public async Task<Domain.Aggregates.Customers.Customer> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await customerDbContext.Customers.FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken)
            .ConfigureAwait(false);
    }
}