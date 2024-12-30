using DDD_Example.Customer.Api.Mappers;
using DDD_Example.Customer.Application.Commands;
using MediatR;

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

        #region Types
            // Mappers
            services.AddSingleton<ICustomerEndpointMapper, CustomerEndpointMapper>();
        #endregion

        return services;
    }
}