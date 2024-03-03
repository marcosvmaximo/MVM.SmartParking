using Microsoft.AspNetCore.Mvc;
using MVM.SmartParking.Company.API.Data.Interfaces;
using MVM.SmartParking.Company.API.Dtos;
using MVM.SmartParking.Company.API.Services;

namespace MVM.SmartParking.Company.API.Controllers;

[ApiController]
[Route("api/companies")]
public class CompanyController : ControllerBase
{
    private readonly ICompanyRepository _repository;
    private readonly ICompanyService _service;

    public CompanyController(ICompanyRepository repository, ICompanyService service)
    {
        _repository = repository;
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Models.Company>>> GetCompanies()
    {
        var companies = await _repository.GetAll();

        if (!companies.Any()) return NotFound("Nenhuma empresa encontrada.");

        return Ok(companies);
    }

    [HttpPost]
    public async Task<ActionResult> AddCompany([FromBody] CompanyRequest request)
    {
        _service.AddCompany(request);
        
        
    }
}