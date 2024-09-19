namespace StudentAffairs;

public class StudentValidator : UserValidator<Student>
{
    public StudentValidator(IStringLocalizer<Resource> _localizer, IStudentsUnitOfWork _studentDbSet)
        : base(_localizer, _studentDbSet)
    {
        RuleFor(p => p.GPA)
            .NotEmpty().WithMessage(_localizer["V-GPAEmpyt"])
            .GreaterThanOrEqualTo(0).WithMessage(_localizer["V-GPANegative"])
            .LessThanOrEqualTo(4).WithMessage(_localizer["V-GPALarge"]);

        ClassLevelCascadeMode = CascadeMode.Stop;
    }
}
