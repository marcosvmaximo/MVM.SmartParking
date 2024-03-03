using MVM.SmartParking.Company.API.Models.Base;

namespace MVM.SmartParking.Company.API.Models;

public class Company : BaseModel
{
    public string Name { get; set; } 
    public string Cnpj { get; set; }
    public int NumberCarSpace { get; set; }
    public int NumberMotoSpace { get; set; }
    public IEnumerable<Adress> Adresses { get; set; }
    public IEnumerable<Contact> Contacts { get; set; }
}