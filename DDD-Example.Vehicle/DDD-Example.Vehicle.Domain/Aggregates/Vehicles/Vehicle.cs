using DDD_Example.Vehicle.Domain.Aggregates.Vehicles.Enums;
using DDD_Example.Vehicle.Domain.Aggregates.Vehicles.Models;
using DDD_Example.Vehicle.Domain.Aggregates.Vehicles.ValueObjects;
using DDD_Example.Vehicle.Domain.Base;
using Type = DDD_Example.Vehicle.Domain.Aggregates.Vehicles.ValueObjects.Type;

namespace DDD_Example.Vehicle.Domain.Aggregates.Vehicles;

public class Vehicle : BaseEntity, IAggregateRoot
{
    private Vehicle()
    {
    }
    
    internal static Vehicle Create(VehicleCreateModel createModel)
    {
        return new Vehicle
        {
            Id = Guid.NewGuid(),
            Plate = Plate.Create(createModel.Plate),
            Year = Year.Create(createModel.Year),
            Price = Price.Create(createModel.PriceCurrency, createModel.PriceAmount),
            Brand = Brand.Create(createModel.Brand),
            Type = Type.Create(createModel.Type),
            Color = Color.Create(createModel.ColorCode, createModel.ColorName),
            Mileage = Mileage.Create(createModel.Mileage),
            Status = Status.Active
        };
    }
    
    public Plate Plate { get; private set; }
    public Year Year { get; private set; }
    public Price Price { get; private set; }
    public Brand Brand { get; private set; }
    public Type Type { get; private set; }
    public Color Color { get; private set; }
    public Mileage Mileage { get; private set; }
    public Status Status { get; private set; }

    public void Delete()
    {
        Status = Status.Deleted;
    }

    public void Activate()
    {
        Status = Status.Active;
    }
}