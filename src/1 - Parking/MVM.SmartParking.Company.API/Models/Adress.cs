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
        City = adress.City;
        State = adress.State;
        Status = true;
    }

    public string ZipCode { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string City { get; set; }
    public string State { get; set; }
}