using System.Security.Cryptography;
using FluentValidation;
using MVM.SmartParking.Company.API.Data.Interfaces;
using MVM.SmartParking.Company.API.Dtos;
using MVM.SmartParking.Company.API.Models;
using MVM.SmartParking.Company.API.Models.Base;
using MVM.SmartParking.Company.API.Models.Validations;
using MVM.SmartParking.Company.API.Services.Notifications;

namespace MVM.SmartParking.Company.API.Services;

public class CompanyService : ICompanyService
{
    private readonly INotify _notify;
    private readonly ICompanyRepository _repository;

    public CompanyService(ICompanyRepository repository, INotify notify)
    {
        _repository = repository;
        _notify = notify;
    }

    public async Task AddCompany(CompanyDto request)
    {
        if (request.Password != request.ConfirmPassword)
        {
            _notify.AddNotification(new Notification("Company", "Senhas não conferem."));
            return;
        }
        
        Models.Company company = new(request);
        Contact contact = new(request.ContactDto);
        Adress adress = new(request.AdressDto);

        company.Adresses.Add(adress);
        company.Contacts.Add(contact);

        var rules = request.PriceRules.Select(x => new PriceRule(x.Time, x.PriceForTime));
        company.PriceRules.AddRange(rules);
        
        if (!Validate<Models.Company, CompanyValidation>(company)) return;

        await _repository.Add(company);
        await _repository.UnityOfWork.Commit();
    }

    public async Task UpdateAdress(Models.Company company, AdressDto dto)
    {
        var newAdress = new Adress(dto);
        if(!Validate<Adress, AdressValidation>(newAdress)) return;

        var adress = company.Adresses.SingleOrDefault();
        if(adress is null)
        {
            _notify.AddNotification(new Notification("Adress","Empresa não possui endereços encontrados."));
            return;
        }

        company.Adresses.Remove(adress);
        company.Adresses.Add(newAdress);
    }

    public async Task UpdateContact(Models.Company company, ContactDto dto)
    {
        var newContact = new Contact(dto);
        if(!Validate<Contact, ContactValidation>(newContact)) return;

        var contact = company.Contacts.SingleOrDefault();
        if(contact is null)
        {
            _notify.AddNotification(new Notification("Contact","Empresa não possui endereços encontrados."));
            return;
        }

        company.Contacts.Remove(contact);
        company.Contacts.Add(newContact);
    }

    public async Task AddPriceRule(string cnpj, PriceRuleDto rule)
    {
        PriceRule priceRule = new(){ Time = rule.Time, PriceForTime = rule.PriceForTime };

        PriceRuleValidation validation = new();
        var validate = validation.Validate(priceRule);
        if (!validate.IsValid)
        {
            var notifications = validate.Errors.Select(fail => new Notification(fail.PropertyName, fail.ErrorMessage));
            _notify.AddNotification(notifications);
        }

        var company = await _repository.GetByCnpj(cnpj);
        if (company is null)
        {
            _notify.AddNotification(new Notification("Company","Empresa não encontrada."));
            return;
        }

        if (company.PriceRules.Exists(x => x.Equals(priceRule)))
        {
            _notify.AddNotification(new Notification(nameof(PriceRule), "Regra de preço já existente."));
            return;
        }
        
        company.PriceRules.Add(priceRule);
        
        await _repository.Update(company);
        await _repository.UnityOfWork.Commit();
    }

    public async Task RemovePriceRule(string cnpj, PriceRuleDto rule)
    {
        var company = await _repository.GetByCnpj(cnpj);
        if (company is null)
        {
            _notify.AddNotification(new Notification("Company","Empresa não encontrada."));
            return;
        }

        PriceRule priceRule = new(){ Time = rule.Time, PriceForTime = rule.PriceForTime };

        if (!company.PriceRules.Exists(x => x.Equals(priceRule)))
        {
            _notify.AddNotification(new Notification(nameof(PriceRule), "Regra de preço não existente."));
            return;
        }

        company.PriceRules.Remove(priceRule);

        await _repository.Update(company);
        await _repository.UnityOfWork.Commit();
    }

    private bool Validate<TEntity, TValidation>(TEntity entity)
        where TValidation : AbstractValidator<TEntity>, new()
        where TEntity : BaseModel
    {
        var validationResult = entity.Validate<TEntity, TValidation>();
        
        var notifications = validationResult.Errors.Select(fail => new Notification(fail.PropertyName, fail.ErrorMessage));
        _notify.AddNotification(notifications);
        
        return validationResult.IsValid;
    }

}