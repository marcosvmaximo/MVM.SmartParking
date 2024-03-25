using FluentValidation;
using MVM.SmartParking.Company.API.Models;

namespace MVM.SmartParking.Company.API.Models.Validations;

public class ContactValidation : AbstractValidator<Contact>
{
    public ContactValidation()
    {
        
    }
}