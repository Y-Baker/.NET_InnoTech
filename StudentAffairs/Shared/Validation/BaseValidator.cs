namespace Shared;

public abstract class BaseValidator<TEntity> : AbstractValidator<TEntity>
    where TEntity : BaseEntity
{
    protected BaseValidator(IStringLocalizer<Resource> _localizer)
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage(_localizer["V-NameEmpty"])
            .Length(3, 50).WithMessage(_localizer["V-NameLength"]);

        ClassLevelCascadeMode = CascadeMode.Stop;
    }
}
