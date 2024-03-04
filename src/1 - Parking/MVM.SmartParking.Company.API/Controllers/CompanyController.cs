using Microsoft.AspNetCore.Mvc;
using MVM.SmartParking.Company.API.Data.Interfaces;
using MVM.SmartParking.Company.API.Dtos;
using MVM.SmartParking.Company.API.Services;
using MVM.SmartParking.Company.API.Services.Notifications;

namespace MVM.SmartParking.Company.API.Controllers;

[ApiController]
[Route("api/companies")]
public class CompanyController : ControllerBase
{
    private readonly ICompanyRepository _repository;
    private readonly ICompanyService _service;
    private readonly INotify _notify;

    public CompanyController(
        ICompanyRepository repository,
        ICompanyService service,
        INotify notify)
    {
        _repository = repository;
        _service = service;
        _notify = notify;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Models.Company>>> GetCompanies()
    {
        var companies = await _repository.GetAll();

        if (!companies.Any()) return NotFound("Nenhuma empresa encontrada.");

        return Ok(companies);
    }

    [HttpPost]
    public async Task<ActionResult> AddCompany([FromBody] CompanyDto dto)
    {
        await _service.AddCompany(dto);
        
        if (!_notify.AnyNotification()) return Ok();

        return BadRequest(_notify.GetNotifications());
    }

    [HttpPut("{companyId}/adress")]
    public async Task<ActionResult> UpdateAdressOfCompany([FromRoute]Guid companyId, [FromBody]AdressDto newAdress)
    {
        await _service.UpdateAdress(companyId, newAdress);
        
        if (!_notify.AnyNotification()) return Ok();

        return BadRequest(_notify.GetNotifications());
    }   
    
    [HttpPut("{companyId}/contact")]
    public async Task<ActionResult> UpdateContactOfCompany([FromRoute]Guid companyId, [FromBody]ContactDto newContact)
    {
        await _service.UpdateContact(companyId, newContact);
        
        if (!_notify.AnyNotification()) return Ok();

        return BadRequest(_notify.GetNotifications());
    }
}