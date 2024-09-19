namespace UserDomain;

public abstract class UserValidator<TEntity> : BaseValidator<TEntity>
    where TEntity : User
{
    protected UserValidator(IStringLocalizer<Resource> _localizer, IUserUnitOfWork<TEntity> _DbSet)
        : base(_localizer)
    {
        RuleFor(p => p.Age)
            .NotEmpty().WithMessage(_localizer["V-AgeEmpty"])
            .GreaterThanOrEqualTo(8).WithMessage(_localizer["V-AgeLess"])
            .LessThanOrEqualTo(80).WithMessage(_localizer["V-AgeLarge"]);

        RuleFor(p => p.Mobile)
            .NotEmpty().WithMessage(_localizer["V-MobileEmpty"])
            .Must(ValidationUtils.ValidMobile!).WithMessage(_localizer["V-MobileValid"]);

        RuleFor(p => p.Email)
            .NotEmpty().WithMessage(_localizer["V-EmailEmpty"])
            .EmailAddress().WithMessage(_localizer["V-EmailValid"])
            .MustAsync(async (email, cancellation) =>
            {
                bool exists = await _DbSet.EmailExists(email);
                return !exists;
            }).WithMessage(_localizer["V-EmailExists"]);

        ClassLevelCascadeMode = CascadeMode.Stop;
    }
}
