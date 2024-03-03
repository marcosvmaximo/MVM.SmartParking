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

    public virtual ValidationResult Validate<TEntity, TValidation>()
        where TValidation : AbstractValidator<TEntity>, new()
        where TEntity : BaseModel
    {
        return new TValidation().Validate((TEntity)this);
    }
}