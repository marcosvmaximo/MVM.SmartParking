using MVM.SmartParking.Company.API.Dtos;
using MVM.SmartParking.Company.API.Models.Base;
using MVM.SmartParking.Company.API.Services;

namespace MVM.SmartParking.Company.API.Models;

public class Company : BaseModel
{
    public Company(CompanyDto company)
    {
        Name = company.Name;
        Cnpj = company.Cnpj;
        NumberCarSpace = company.NumberCarSpace;
        NumberMotoSpace = company.NumberMotoSpace;
        PasswordHash = PasswordCrypto.GenerateHashPassword(company.Password);
    }

    public string Name { get; set; } 
    public string Cnpj { get; set; }
    public int NumberCarSpace { get; set; }
    public int NumberMotoSpace { get; set; }
    public string PasswordHash { get; set; }
    public List<Adress> Adresses { get; set; }
    public List<Contact> Contacts { get; set; }
}