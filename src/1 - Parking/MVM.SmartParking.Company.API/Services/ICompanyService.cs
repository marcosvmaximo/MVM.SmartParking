using MVM.SmartParking.Company.API.Dtos;

namespace MVM.SmartParking.Company.API.Services;

public interface ICompanyService
{
    Task AddCompany(CompanyDto dto);
    Task UpdateAdress(Guid companyId, AdressDto newAdress);
    Task UpdateContact(Guid companyId, ContactDto newContact);
}