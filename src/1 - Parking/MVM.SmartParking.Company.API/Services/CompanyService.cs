using MVM.SmartParking.Company.API.Data.Interfaces;
using MVM.SmartParking.Company.API.Dtos;
using MVM.SmartParking.Company.API.Models.Validations;

namespace MVM.SmartParking.Company.API.Services;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _repository;

    public CompanyService(ICompanyRepository repository)
    {
        _repository = repository;
    }

    public Task AddCompany(CompanyRequest request)
    {
        Models.Company company = new()
        {

        };

        var validationResult = company.Validate<Models.Company, CompanyValidation>();
    }
}