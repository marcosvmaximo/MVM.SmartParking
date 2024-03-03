using MVM.SmartParking.Company.API.Dtos;

namespace MVM.SmartParking.Company.API.Services;

public interface ICompanyService
{
    Task AddCompany(CompanyRequest request);
}