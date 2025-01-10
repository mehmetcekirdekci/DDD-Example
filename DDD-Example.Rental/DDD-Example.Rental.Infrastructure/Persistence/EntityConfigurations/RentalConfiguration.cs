using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD_Example.Rental.Infrastructure.Persistence.EntityConfigurations;

public sealed class RentalConfiguration : IEntityTypeConfiguration<Domain.Aggregates.Rentals.Rental>
{
    public void Configure(EntityTypeBuilder<Domain.Aggregates.Rentals.Rental> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedNever();
        
        //builder.ToTable("Rentals");
    }
}