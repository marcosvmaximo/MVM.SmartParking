using FluentValidation;
using FluentValidation.Results;

namespace MVM.SmartParking.Company.API.Models.Base;

public abstract class BaseModel
{
    public BaseModel()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; private set; }

    public virtual ValidationResult Validate<TModel, TValidation>()
        where TValidation : AbstractValidator<TModel>, new()
        where TModel : BaseModel
    {
        return new TValidation().Validate((TModel)this);
    }
}