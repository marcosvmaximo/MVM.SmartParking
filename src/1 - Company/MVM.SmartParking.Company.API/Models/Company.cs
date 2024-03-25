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
        Status = true;
        
        Adresses = new();
        Contacts = new();
        PriceRules = new();
    }

    public Company(){}
    
    public string Name { get; set; } 
    public string Cnpj { get; set; }
    public int NumberCarSpace { get; set; }
    public int NumberMotoSpace { get; set; }
    public string PasswordHash { get; set; }
    public bool Status { get; set; }
    public List<Adress> Adresses { get; set; }
    public List<Contact> Contacts { get; set; }
    public List<PriceRule> PriceRules { get; set; }
}