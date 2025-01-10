using DDD_Example.Rental.Application;
using DDD_Example.Rental.Application.Commands;
using DDD_Example.Rental.Application.Repositories;
using DDD_Example.Rental.Infrastructure.DomainEventDispatcher;
using DDD_Example.Rental.Infrastructure.Persistence;
using DDD_Example.Rental.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DDD_Example.Rental.Api.ServiceRegistrations;

public static class RentalRegistrations
{
    public static IServiceCollection RegisterRental(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        #region Mediatr

        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly, typeof(CreateRentalCommand).Assembly));

        #endregion

        #region DomainEventDispatcher

        services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();

        #endregion

        #region DbContext

        var connectionString = configuration.GetConnectionString("rental");
        services.AddDbContext<RentalDbContext>((_, optionsBuilder) =>
                optionsBuilder.UseNpgsql(connectionString)
            )
            .AddScoped<IUnitOfWork, RentalDbContext>(x =>
                x.GetRequiredService<RentalDbContext>());

        #endregion

        #region Types
        // Mappers
        
            
        // Repositories
        services.AddScoped<IRentalRepository, RentalRepository>();
            
        // Factories
        
        #endregion

        return services;
    }
}