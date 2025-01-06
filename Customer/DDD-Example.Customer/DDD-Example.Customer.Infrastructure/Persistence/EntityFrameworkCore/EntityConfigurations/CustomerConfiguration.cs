using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD_Example.Customer.Infrastructure.Persistence.EntityFrameworkCore.EntityConfigurations;

public sealed class CustomerConfiguration : IEntityTypeConfiguration<Domain.Aggregates.Customers.Customer>
{
    public void Configure(EntityTypeBuilder<Domain.Aggregates.Customers.Customer> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedNever();
        
        builder.ComplexProperty(x => x.Name, y =>
        {
            y.Property(z => z.FirstName).IsRequired();
            y.Property(z => z.LastName).IsRequired();
            y.IsRequired();
        });
        
        builder.ComplexProperty(x => x.BirthDate, y =>
        {
            y.Property(z => z.Value);
            y.IsRequired();
        });
        
        builder.ComplexProperty(x => x.Address, y =>
        {
            y.Property(z => z.Country).IsRequired();
            y.Property(z => z.City).IsRequired();
            y.Property(z => z.Street).IsRequired();
            y.IsRequired();
        });
        
        builder.ComplexProperty(x => x.Mail, y =>
        {
            y.Property(z => z.Value).IsRequired();
            y.Property(z => z.IsApproved).IsRequired();
            y.IsRequired();
        });
        
        builder.ComplexProperty(x => x.Phone, y =>
        {
            y.Property(z => z.CountryCode).IsRequired();
            y.Property(z => z.Number).IsRequired();
            y.IsRequired();
        });
        
        builder.ComplexProperty(x => x.Licence, y =>
        {
            y.Property(z => z.Image).IsRequired();
            y.Property(z => z.IsApproved).IsRequired();
            y.IsRequired();
        });

        builder.ToTable("Customers");
    }
}