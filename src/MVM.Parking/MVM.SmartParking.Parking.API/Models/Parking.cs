using MVM.SmartParking.Core;

namespace MVM.SmartParking.Parking.API.Models;

public class Parking : Entity
{
    public string Name { get; set; }
    public string Cnpj { get; set; }
    public int NumberParkingSpaceCar { get; set; }
    public int NumberParkingSpaceMotocycle { get; set; }
    public Adress Adress {get; set; }
    public Contact Contact { get; set; }
    // public IEnumerable<Bilhete> Tickets { get; set; }
}