using MVM.SmartParking.Company.API.Models.Base;

namespace MVM.SmartParking.Company.API.Models;

public class Contact : BaseModel
{
    public string Email { get; set; }
    public string Telephone { get; set; }
}