namespace CourseDomain;

public class CourseValidator : BaseValidator<Course>
{
    public CourseValidator(IStringLocalizer<Resource> _localizer)
        : base(_localizer)
    {
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
