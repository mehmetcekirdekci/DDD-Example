using DDD_Example.Customer.Domain.Base;

namespace DDD_Example.Customer.Domain.Aggregates.Customers.ValueObjects;

public class Licence : ValueObject
{
    private Licence()
    {
        
    }

    internal static Licence Create(string licenceImage)
    {
        if (string.IsNullOrWhiteSpace(licenceImage))
        {
            throw new ArgumentException($"{nameof(Image)} cannot be null or whitespace.");
        }
        
        return new Licence
        {
            Image = licenceImage,
            IsApproved = false
        };
    }
    
    public string Image { get; private init; }
    public bool IsApproved { get; private init; }

    public Licence Approve()
    {
        return new Licence
        {
            Image = Image,
            IsApproved = true
        };
    }
    
    public Licence UnApprove()
    {
        return new Licence
        {
            Image = Image,
            IsApproved = false
        };
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Image;
    }
}