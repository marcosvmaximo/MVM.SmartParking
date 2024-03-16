using MVM.SmartParking.Domain.Core;
using MVM.SmartParking.Parking.Domain.Entities.Validations;
using MVM.SmartParking.Parking.Domain.Enum;
using MVM.SmartParking.Parking.Domain.ValueObjects;

namespace MVM.SmartParking.Parking.Domain.Entities;

public class Vehicle : Entity
{
    private List<Ticket> _tickets;

    public Vehicle(string plate, ETypeVehicle type, Brand brand, Model model, Color color)
    {
        Plate = plate;
        Type = type;
        Brand = brand;
        Model = model;
        Color = color;
        Parked = false;
        
        _tickets = new();
        
        Validate();
    }

    public string Plate { get; private set; }
    public ETypeVehicle Type { get; private set; }
    public Color Color { get; private set; }
    public Brand Brand { get; private set; }
    public Model Model { get; private set; }
    public bool Parked { get; private set; }
    
    // Ef Relations
    public IReadOnlyCollection<Ticket> Tickets => _tickets;
    
    public void AddTicket(Ticket ticket)
    {
        _tickets.Add(ticket);
    }

    public sealed override void Validate() => DomainValidations.ValidateVehicle(this);
}