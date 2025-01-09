using DDD_Example.Customer.Domain.Aggregates.Customers.Models;

namespace DDD_Example.Customer.Domain.Aggregates.Customers.Factories;

public interface ICustomerFactory
{
    public Customer Create(CustomerCreateModel createModel);
}

public class CustomerFactory : ICustomerFactory
{
    public Customer Create(CustomerCreateModel createModel)
    {
        return Customer.Create(createModel);
    }
}