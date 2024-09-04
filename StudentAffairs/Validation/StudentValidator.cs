namespace StudentAffairs;

public class StudentValidator : AbstractValidator<Student>
{
    public StudentValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} Can't Be Empty")
            .Length(3, 50).WithMessage("{PropertyName} Length({TotalLength}) must be between 3 and 50");

        RuleFor(p => p.Age)
            .GreaterThanOrEqualTo(8).WithMessage("{PropertyName} can't be less than {ComparisonValue}")
            .LessThanOrEqualTo(80).WithMessage("{PropertyName} can't be larger than {ComparisonValue}");

        RuleFor(p => p.Mobile)
            .NotEmpty().WithMessage("{PropertyName} Can't Be Empty")
            .Must(ValidMobile!).WithMessage("{PropertyName} use invalid characters");

        RuleFor(p => p.Email)
            .NotEmpty().WithMessage("{PropertyName} Can't Be Empty")
            .EmailAddress().WithMessage("{PropertyName} is not a valid email address");

        RuleFor(p => p.GPA)
            .NotEmpty().WithMessage("{PropertyName} Can't Be Empty")
            .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} can't be Negative")
            .LessThanOrEqualTo(4).WithMessage("{PropertyName} can't be larger than {ComparisonValue}");

        ClassLevelCascadeMode = CascadeMode.Stop;
    }

    protected static bool ValidMobile(string mobile)
    {
        mobile = mobile
            .Replace(" ", "")
            .Replace("-", "")
            .Replace("+", "");
        bool  result = mobile.All(char.IsDigit);
        return result ? true : false;
    }
}
