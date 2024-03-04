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
        
        if (!Validate<Models.Company, CompanyValidation>(company)) return;

        await _repository.Add(company);
        await _repository.UnityOfWork.Commit();
    }

    public async Task UpdateAdress(Guid companyId, AdressDto dto)
    {
        var newAdress = new Adress(dto);
        if(!Validate<Adress, AdressValidation>(newAdress)) return;

        var company = await _repository.GetById(companyId);
        if (company is null)
        {
            _notify.AddNotification(new Notification("Company","Empresa não encontrada."));
            return;
        }

        var adress = company.Adresses.FirstOrDefault(x => x.Status);
        if(adress is null)
        {
            _notify.AddNotification(new Notification("Adress","Empresa não possui endereços encontrados."));
            return;
        }

        adress.Status = false;
        company.Adresses.Add(newAdress);
    }

    public async Task UpdateContact(Guid companyId, ContactDto dto)
    {
        var newContact = new Contact(dto);
        if(!Validate<Contact, ContactValidation>(newContact)) return;
        
        var company = await _repository.GetById(companyId);
        if (company is null)
        {
            _notify.AddNotification(new Notification("Company","Empresa não encontrada."));
            return;
        }

        var contact = company.Contacts.FirstOrDefault(x => x.Status);
        if(contact is null)
        {
            _notify.AddNotification(new Notification("Contact","Empresa não possui endereços encontrados."));
            return;
        }

        contact.Status = false;

        
        company.Contacts.Add(newContact);
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