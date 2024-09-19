namespace DoctorDomain;

public class DoctorValidator : UserValidator<Doctor>
{
    public DoctorValidator(IStringLocalizer<Resource> _localizer, IDoctorsUnitOfWork _doctorDbSet)
        : base(_localizer, _doctorDbSet)
    {
        RuleFor(p => p.Major)
            .NotEmpty().WithMessage(_localizer["V-MajorEmpty"])
            .Length(2, 250).WithMessage(_localizer["V-MajorLength"]);

        ClassLevelCascadeMode = CascadeMode.Stop;
    }
}
