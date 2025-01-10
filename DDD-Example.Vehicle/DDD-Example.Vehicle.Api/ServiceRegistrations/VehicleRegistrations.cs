using DDD_Example.Vehicle.Api.Mappers;
using DDD_Example.Vehicle.Application;
using DDD_Example.Vehicle.Application.Commands;
using DDD_Example.Vehicle.Application.Repositories;
using DDD_Example.Vehicle.Domain.Aggregates.Vehicles.Factories;
using DDD_Example.Vehicle.Infrastructure.DomainEventDispatcher;
using DDD_Example.Vehicle.Infrastructure.Persistence;
using DDD_Example.Vehicle.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DDD_Example.Vehicle.Api.ServiceRegistrations;

public static class VehicleRegistrations
{
    public static IServiceCollection RegisterVehicle(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        #region Mediatr

        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly, typeof(CreateVehicleCommand).Assembly));

        #endregion

        #region DomainEventDispatcher

        services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();

        #endregion

        #region DbContext

        var connectionString = configuration.GetConnectionString("vehicle");
        services.AddDbContext<VehicleDbContext>((_, optionsBuilder) =>
                optionsBuilder.UseNpgsql(connectionString)
            )
            .AddScoped<IUnitOfWork, VehicleDbContext>(x =>
                x.GetRequiredService<VehicleDbContext>());

        #endregion

        #region Types
        // Mappers
        services.AddSingleton<IVehicleEndpointMapper, VehicleEndpointMapper>();
            
        // Repositories
        services.AddScoped<IVehicleRepository, VehicleRepository>();
            
        // Factories
        services.AddScoped<IVehicleFactory, VehicleFactory>();
        #endregion

        return services;
    }
}