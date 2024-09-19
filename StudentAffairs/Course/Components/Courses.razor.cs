namespace StudentAffairs;

public partial class Courses
{
    Course? _course = new();
    List<Course> courses = new();
    List<Doctor> doctors = new();
    bool isLoading = false;
    Course? _courseToDelete;
    Modal? modal;

    private Dictionary<Guid, string> doctorsNames = new();
    private Dictionary<Guid, string> preRequestCourseNames = new();

    [Inject] public ICoursesUnitOfWork? _courses { get; set; }
    [Inject] public ICourseService? _service { get; set; }

    protected async override Task OnInitializedAsync()
    {
        ArgumentNullException.ThrowIfNull(_service, nameof(_service));
        courses = await _service.GetCourses();
        doctors = await _service.GetDoctors();

        foreach (Course course in courses)
        {
            Doctor? instructor = await _service.GetInstructor(course);
            doctorsNames[course.Id] = instructor.Name ?? "No Instructor";

            if (course.PreRequest.HasValue && course.PreRequest is not null)
            {
                Course? preRequestCourse = await _service.GetCourse(course.PreRequest ?? Guid.Empty);

                preRequestCourseNames[course.Id] = preRequestCourse.Name ?? _localizer["None"];
            }
            else
            {
                preRequestCourseNames[course.Id] = _localizer["None"];
            }
        }

        await base.OnInitializedAsync();
    }
    private async Task HandleValidSubmit()
    {
        if (isLoading)
        {
            Console.WriteLine("Can't Do New Process While Loading");
            return;
        }
        if (_course is null)
        {
            Console.WriteLine($"{nameof(_course)} Not Found");
            return;
        }
        
        isLoading = true;
        StateHasChanged();

        try
        {
            string courseSerialized = _course is null ? string.Empty : JsonSerializer.Serialize(_course);
            Course? validCourse = JsonSerializer.Deserialize<Course>(courseSerialized);
            ArgumentNullException.ThrowIfNull(validCourse, nameof(validCourse));

            Course? newCourse = courses?.FirstOrDefault(e => e.Id == validCourse.Id);

            ArgumentNullException.ThrowIfNull(_courses, nameof(_courses));
            if (newCourse is null)
            {
                validCourse.Id = Guid.NewGuid();
                await _courses.Create(validCourse);
            }
            else
            {
                await _courses.Update(validCourse);
            }

            ArgumentNullException.ThrowIfNull(_service, nameof(_service));
            Doctor? instructor = await _service.GetInstructor(validCourse);
            doctorsNames[validCourse.Id] = instructor.Name ?? "No Instructor";

            if (validCourse.PreRequest.HasValue && validCourse.PreRequest is not null)
            {
                Course? preRequestCourse = await _service.GetCourse(validCourse.PreRequest ?? Guid.Empty);

                preRequestCourseNames[validCourse.Id] = preRequestCourse.Name ?? _localizer["None"];
            }
            else
            {
                preRequestCourseNames[validCourse.Id] = _localizer["None"];
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
            Console.WriteLine($"{nameof(_course)} Not Saved");
            throw;
        }
        finally
        {
            ArgumentNullException.ThrowIfNull(_service, nameof(_service));
            courses = await _service.GetCourses();
            isLoading = false;
            Clear();
            StateHasChanged();
        }
    }

    private void EditCourse(Course toBeEditedCourse)
    {
        string? courseSerialized = JsonSerializer.Serialize(toBeEditedCourse);
        if (courseSerialized is not null)
            _course = JsonSerializer.Deserialize<Course>(courseSerialized);

        StateHasChanged();
    }

    private async void PrepareForDelete(Course course)
    {
        ArgumentNullException.ThrowIfNull(_service, nameof(_service));
        ArgumentNullException.ThrowIfNull(modal, nameof(modal));
        _courseToDelete = course;
        await _service.ShowModal(modal);
    }
    private async Task ConfirmDelete()
    {
        if (_courseToDelete != null)
        {
            await DeleteCourse(_courseToDelete);
        }
    }
    public async Task DeleteCourse(Course course)
    {
        isLoading = true;
        ArgumentNullException.ThrowIfNull(course, nameof(course));
        ArgumentNullException.ThrowIfNull(_courses, nameof(_courses));

        try
        {
            await _courses.Delete(course);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
            Console.WriteLine("Course Not Saved");
        }
        finally
        {
            ArgumentNullException.ThrowIfNull(_service, nameof(_service));
            courses = await _service.GetCourses();
            isLoading = false;
            StateHasChanged();
        }
    }
    private void Clear()
    {
        _course = new();
    }
}