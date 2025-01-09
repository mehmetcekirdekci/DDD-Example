using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD_Example.Vehicle.Infrastructure.Persistence.EntityConfigurations;

public sealed class VehicleConfiguration : IEntityTypeConfiguration<Domain.Aggregates.Vehicles.Vehicle>
{
    public void Configure(EntityTypeBuilder<Domain.Aggregates.Vehicles.Vehicle> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedNever();
        
        builder.ComplexProperty(x => x.Plate, y =>
        {
            y.Property(z => z.Value);
            y.IsRequired();
        });
        
        builder.ComplexProperty(x => x.Year, y =>
        {
            y.Property(z => z.Value);
            y.IsRequired();
        });
        
        builder.ComplexProperty(x => x.Price, y =>
        {
            y.Property(z => z.Currency).IsRequired();
            y.Property(z => z.Amount).IsRequired();
            y.IsRequired();
        });
        
        builder.ComplexProperty(x => x.Brand, y =>
        {
            y.Property(z => z.Value);
            y.IsRequired();
        });
        
        builder.ComplexProperty(x => x.Type, y =>
        {
            y.Property(z => z.Value);
            y.IsRequired();
        });
        
        builder.ComplexProperty(x => x.Color, y =>
        {
            y.Property(z => z.Code).IsRequired();
            y.Property(z => z.Name).IsRequired();
            y.IsRequired();
        });
        
        builder.ComplexProperty(x => x.Mileage, y =>
        {
            y.Property(z => z.Value);
            y.IsRequired();
        });
        
        builder.ToTable("Vehicles");
    }
}