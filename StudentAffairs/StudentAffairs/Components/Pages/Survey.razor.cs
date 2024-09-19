using Course;
using EntityDefinition;
using Shared.utils;
using StudentAffairs.Service;

namespace StudentAffairs;

public partial class Survey
{
    const int countYears = 8;
    SurveyData _survey = new();
    List<Course> courses = new();
    List<string> years = new();
    bool isLoading = false;

    private bool ShowSurveyInputs => !(_survey.CourseId == Guid.Empty || _survey.Semester is null);

    [Inject] public ICourseService? _service { get; set; }
    [Inject] public IEmailService? _emailService { get; set; }

    protected async override Task OnInitializedAsync()
    {
        ArgumentNullException.ThrowIfNull(_service, nameof(_service));
        isLoading = true;
        courses = await _service.GetCourses();
        years = FillYears(countYears);
        isLoading = false;

        await base.OnInitializedAsync();
    }

    private static List<string> FillYears(int count)
    {
        int startYear = DateTime.Now.Year;
        List<string> years = new ();
        for (int i = 0; i < count; i++)
        {
            years.Add($"{startYear - i}/{startYear - i + 1}");
        }
        return years;
    }

    private async Task HandleValidSubmit()
    {
        if (isLoading)
        {
            Console.WriteLine("Can't Do New Process While Loading");
            return;
        }
        if (_survey is null)
        {
            Console.WriteLine($"{nameof(_survey)} Not Found");
            return;
        }

        isLoading = true;
        StateHasChanged();

        try
        {
            ArgumentNullException.ThrowIfNull(_emailService, nameof(_emailService));
            await _emailService.SendSurvey(_survey);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
            Console.WriteLine($"{nameof(_survey)} Not Saved");
            throw;
        }
        finally
        {
            isLoading = false;
            Clear();
            StateHasChanged();
        }
    }

    private void Clear()
    {
        _survey = new();
    }
}

public class SurveyData
{
    internal string? AcademicYear { get; set; }
    internal SemesterType? Semester { get; set; }
    internal Guid CourseId { get; set; }

    internal int ContentUpdateRating { get; set; }
    internal int ExpectationRating { get; set; }
    internal int LapRating { get; set; }
    internal int InstructorRation { get; set; }
    internal int ExperienceRating { get; set; }
    internal string? Others { get; set; }

}

