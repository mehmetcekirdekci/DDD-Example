using DDD_Example.Customer.Api.Mappers;
using DDD_Example.Customer.Application;
using DDD_Example.Customer.Application.Commands;
using DDD_Example.Customer.Application.Repositories;
using DDD_Example.Customer.Domain.Aggregates.Customers.Factories;
using DDD_Example.Customer.Infrastructure.DomainEventDispatcher;
using DDD_Example.Customer.Infrastructure.Persistence.EntityFrameworkCore;
using DDD_Example.Customer.Infrastructure.Persistence.EntityFrameworkCore.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DDD_Example.Customer.Api.ServiceRegistrations;

public static class CustomerRegistrations
{
    public static IServiceCollection RegisterCustomer(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        #region Mediatr

        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly, typeof(CreateCustomerCommand).Assembly));

        #endregion

        #region DomainEventDispatcher

        services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();

        #endregion

        #region DbContext

        var connectionString = configuration.GetConnectionString("customer");
        services.AddDbContext<CustomerDbContext>((_, optionsBuilder) =>
                optionsBuilder.UseNpgsql(connectionString)
            )
            .AddScoped<IUnitOfWork, CustomerDbContext>(x =>
                x.GetRequiredService<CustomerDbContext>());

        #endregion

        #region Types
            // Mappers
            services.AddSingleton<ICustomerEndpointMapper, CustomerEndpointMapper>();
            
            // Repositories
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            
            // Factories
            services.AddScoped<ICustomerFactory, CustomerFactory>();
        #endregion

        return services;
    }
}