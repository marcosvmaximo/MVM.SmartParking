using MVM.SmartParking.Company.API.Dtos;
using MVM.SmartParking.Company.API.Models.Base;

namespace MVM.SmartParking.Company.API.Models;

public class Adress : BaseModel
{
    public Adress(AdressDto adress)
    {
        ZipCode = adress.ZipCode;
        Street = adress.Street;
        Number = adress.Number;
        Complement = adress.Complement;
        City = adress.City;
        State = adress.State;
        Neighborhood = adress.Neighborhood;
    }

    public Adress(){}
    public string ZipCode { get; set; }
    public string Street { get; set; }
    public string? Complement { get; set; }
    public string Neighborhood { get; set; }
    public int Number { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public Guid CompanyId { get; set; }
    public Company Company { get; set; }
}