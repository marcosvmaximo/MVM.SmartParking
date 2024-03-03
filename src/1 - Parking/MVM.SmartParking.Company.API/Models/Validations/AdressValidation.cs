using FluentValidation;
using MVM.SmartParking.Company.API.Models;

namespace MVM.SmartParking.Company.API.Models.Validations;

public class AdressValidation : AbstractValidator<Adress>
{
    public AdressValidation()
    {
        
    }
}