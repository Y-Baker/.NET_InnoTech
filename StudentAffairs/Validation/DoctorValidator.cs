namespace StudentAffairs;

public class DoctorValidator : AbstractValidator<Doctor>
{
    public DoctorValidator(IStringLocalizer<Resource> _localizer, IDoctorsUnitOfWork _doctorDbSet)
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
                bool exists = await _doctorDbSet.EmailExists(email);
                return !exists;
            }).WithMessage(_localizer["V-EmailExists"]);

        RuleFor(p => p.Major)
            .NotEmpty().WithMessage(_localizer["V-MajorEmpty"])
            .Length(2, 250).WithMessage(_localizer["V-MajorLength"]);

        ClassLevelCascadeMode = CascadeMode.Stop;
    }
}
