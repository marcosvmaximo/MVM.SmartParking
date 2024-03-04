using MVM.SmartParking.Company.API.Dtos;
using MVM.SmartParking.Company.API.Models.Base;

namespace MVM.SmartParking.Company.API.Models;

public class Contact : BaseModel
{
    public Contact(ContactDto contact)
    {
        Email = contact.Email;
        Telephone = contact.Telephone;
    }

    public string Email { get; set; }
    public string Telephone { get; set; }
}