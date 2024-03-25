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
    [ProducesResponseType(typeof(IEnumerable<Models.Company>), (int)StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<Models.Company>>> GetCompanies()
    {
        return Ok(await _repository.GetAll());
    }
    
    [HttpGet("{cnpj}", Name = "Obter empresas")]
    [ProducesResponseType(typeof(IEnumerable<Models.Company>), (int)StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<Models.Company>>> GetCompanieByCnpj(string cnpj)
    {
        var companies = await _repository.GetByFilter(company => company.Cnpj == cnpj);

        if (!companies.Any()) return NotFound("Nenhuma empresa encontrada.");

        return Ok(companies);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> AddCompany([FromBody] CompanyDto dto)
    {
        await _service.AddCompany(dto);
        
        if (_notify.AnyNotification()) return BadRequest(_notify.GetNotifications());

        return CreatedAtRoute(nameof(GetCompanieByCnpj), dto.Cnpj);
    }
    
    [HttpPut("{cnpj}/adress")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateAdressOfCompany([FromRoute]string cnpj, [FromBody]AdressDto newAdress)
    {
        var company = await _repository.GetByCnpj(cnpj);
        if (company == null) return NotFound("Empresa não encontrada");
        
        await _service.UpdateAdress(company, newAdress);
        
        if (!_notify.AnyNotification()) return Ok();

        return BadRequest(_notify.GetNotifications());
    }   
    
    [HttpPut("{cnpj}/contact")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateContactOfCompany([FromRoute]string cnpj, [FromBody]ContactDto newContact)
    {
        var company = await _repository.GetByCnpj(cnpj);
        if (company == null) return NotFound("Empresa não encontrada");
        
        await _service.UpdateContact(company, newContact);
        
        if (!_notify.AnyNotification()) return Ok();

        return BadRequest(_notify.GetNotifications());
    }

    [HttpPost("{cnpj}/price-rule")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> AddPriceRuleForComany([FromRoute]string cnpj, [FromBody]PriceRuleDto request)
    {
        await _service.AddPriceRule(cnpj, request);
        
        if (!_notify.AnyNotification()) return Ok();
        
        return BadRequest(_notify.GetNotifications());
    }
    
    
    [HttpDelete("{cnpj}/price-rule")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> RemovePriceRuleForComany([FromRoute]string cnpj, [FromBody]PriceRuleDto request)
    {
        await _service.RemovePriceRule(cnpj, request);
        
        if (!_notify.AnyNotification()) return NoContent();

        return NotFound(_notify.GetNotifications());
    }
}