namespace StudentAffairs;

public class StudentValidator : AbstractValidator<Student>
{
    public StudentValidator(IStringLocalizer<Resource> _localizer, IStudentsUnitOfWork _studentDbSet)
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage(_localizer["V-NameEmpty"])
            .Length(3, 50).WithMessage(_localizer["V-NameLength"]);

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
                bool exists = await _studentDbSet.EmailExists(email);
                return !exists;
            }).WithMessage(_localizer["V-EmailExists"]);

        RuleFor(p => p.GPA)
            .NotEmpty().WithMessage(_localizer["V-GPAEmpyt"])
            .GreaterThanOrEqualTo(0).WithMessage(_localizer["V-GPANegative"])
            .LessThanOrEqualTo(4).WithMessage(_localizer["V-GPALarge"]);

        ClassLevelCascadeMode = CascadeMode.Stop;
    }
}
