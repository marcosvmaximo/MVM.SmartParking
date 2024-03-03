using MVM.SmartParking.Company.API.Models.Base;

namespace MVM.SmartParking.Company.API.Models;

public class Adress : BaseModel
{
    public string ZipCode { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string City { get; set; }
    public string State { get; set; }
}