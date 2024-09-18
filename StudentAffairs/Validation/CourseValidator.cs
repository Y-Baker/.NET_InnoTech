namespace StudentAffairs;

public class CourseValidator : AbstractValidator<Course>
{
    public CourseValidator(IStringLocalizer<Resource> _localizer)
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage(_localizer["V-NameEmpty"])
            .Length(3, 50).WithMessage(_localizer["V-NameLength"]);

        RuleFor(p => p.CreaditHours)
            .NotEmpty().WithMessage(_localizer["V-CreditHoursEmpty"])
            .GreaterThanOrEqualTo(0).WithMessage(_localizer["V-CreditHoursNegative"])
            .LessThanOrEqualTo(4).WithMessage(_localizer["V-CreditHoursLarge"]);

        RuleFor(p => p.InstructorId)
            .Must(instructor => instructor != Guid.Empty).WithMessage(_localizer["V-Instructor"]);

        RuleFor(p => p.PreRequest)
            .Must(preRequest => preRequest == null || preRequest != Guid.Empty).WithMessage(_localizer["V-PreRequest"]);

        ClassLevelCascadeMode = CascadeMode.Stop;
    }
}
