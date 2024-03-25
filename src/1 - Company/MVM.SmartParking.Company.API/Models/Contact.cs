using MVM.SmartParking.Company.API.Dtos;
using MVM.SmartParking.Company.API.Models.Base;

namespace MVM.SmartParking.Company.API.Models;

public class Contact : BaseModel
{
    public Contact(ContactDto contact)
    {
        Email = contact.Email;
        Code = contact.Code;
        Telephone = contact.Telephone;
    }
    
    public Contact(){}

    public string Email { get; set; }
    public string Code { get; set; }
    public string Telephone { get; set; }
    public Guid CompanyId { get; set; }
    public Company Company { get; set; }
}