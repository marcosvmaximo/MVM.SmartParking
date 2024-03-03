namespace MVM.SmartParking.Parking.API.Models;

public class Adress
{
    public string ZipCode { get; set; }
    public string StreetAdress { get; set; } // Street, number, complement
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
}