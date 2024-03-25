using MVM.SmartParking.Company.API.Dtos;

namespace MVM.SmartParking.Company.API.Services;

public interface ICompanyService
{
    Task AddCompany(CompanyDto dto);
    Task UpdateAdress(Models.Company company, AdressDto newAdress);
    Task UpdateContact(Models.Company company, ContactDto newContact);
    Task AddPriceRule(string cnpj, PriceRuleDto rule);
    Task RemovePriceRule(string cnpj, PriceRuleDto request);
}