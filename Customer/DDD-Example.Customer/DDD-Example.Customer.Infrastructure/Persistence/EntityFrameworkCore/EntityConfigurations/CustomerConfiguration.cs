using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD_Example.Customer.Infrastructure.Persistence.EntityFrameworkCore.EntityConfigurations;

public sealed class CustomerConfiguration : IEntityTypeConfiguration<Domain.Aggregates.Customers.Customer>
{
    public void Configure(EntityTypeBuilder<Domain.Aggregates.Customers.Customer> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedNever();
        
        builder.ComplexProperty(x => x.Name).IsRequired();
        
        builder.ComplexProperty(x => x.BirthDate, y =>
        {
            y.Property(z => z.Value);
            y.IsRequired();
        });

        //builder.ComplexProperty(x => x.Address).IsRequired();
        
        builder.ComplexProperty(x => x.Mail, y =>
        {
            y.Property(z => z.Value);
            y.IsRequired();
        });
        
        builder.ComplexProperty(x => x.Phone).IsRequired();

        
        builder.ComplexProperty(x => x.Status, y =>
        {
            y.ComplexProperty(z => z.MailStatus).IsRequired();
            y.ComplexProperty(z => z.LicenceStatus).IsRequired();
            y.IsRequired();
        });

        builder.ToTable("Customers");
    }
}