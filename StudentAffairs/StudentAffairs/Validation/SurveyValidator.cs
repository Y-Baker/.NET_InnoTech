namespace StudentAffairs.Validation;

public class SurveyValidator : AbstractValidator<SurveyData>
{
    public SurveyValidator(IStringLocalizer<Resource> _localizer)
    {
        RuleFor(p => p.AcademicYear)
            .NotEmpty().WithMessage(_localizer["V-YearEmpty"]);

        RuleFor(p => p.Semester)
            .Must(semester => semester is not null).WithMessage(_localizer["V-Semester"]);

        RuleFor(p => p.CourseId)
            .Must(id => id != Guid.Empty).WithMessage(_localizer["V-Course"]);
    }
}
