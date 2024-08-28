using FluentValidation;

namespace BlazorApp.Models;

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
