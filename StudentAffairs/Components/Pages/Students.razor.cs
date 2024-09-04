namespace StudentAffairs;

public partial class Students
{
    Student? _student = new();
    List<Student>? students = new List<Student>();
    bool isLoading = false;
    public Modal? modalComponent;

    [Inject] public StudentsAffairsDbContext? _studentsAffairsDbContext { get; set; }

    private void TrackMethod([CallerMemberName] string methodName = "")
    {
        Console.WriteLine($"{methodName} invoked.");
    }
    protected async override Task OnInitializedAsync()
    {
        TrackMethod();
        try
        {
            students = await GetStudentsAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Request error: {ex.Message}");
        }
        await base.OnInitializedAsync();
    }
    protected async override Task OnAfterRenderAsync(bool firstRender)
    {
        Console.WriteLine($"{MethodBase.GetCurrentMethod()?.Name} invoked. firstRender = {firstRender}");
        await base.OnAfterRenderAsync(firstRender);
    }

    private async Task HandleValidSubmit()
    {
        TrackMethod();
        if (isLoading) {
            Console.WriteLine("Can't Do New Process While Loading");
            return;
        }
        if (_student is null)
        {
            Console.WriteLine("Student Not Found");
            return;
        }

        isLoading = true;
        StateHasChanged();
        try
        {
            string studentSerialized = _student is null ? string.Empty : JsonSerializer.Serialize(_student);
            Student? validStudent = JsonSerializer.Deserialize<Student>(studentSerialized);
            ArgumentNullException.ThrowIfNull(validStudent);

            Student? newStudent = students?.FirstOrDefault(e => e.Name is not null && e.Name.Equals(validStudent?.Name));

            ArgumentNullException.ThrowIfNull(_studentsAffairsDbContext);
            if (newStudent is null)
            {
                validStudent.Id = Guid.NewGuid();
                _studentsAffairsDbContext.Students.Add(validStudent);
            }
            else
            {
                _studentsAffairsDbContext.Students.Update(validStudent);
            }
            await _studentsAffairsDbContext.SaveChangesAsync();

            if (newStudent is not null)
                _studentsAffairsDbContext.ChangeTracker.Clear();

            students = await GetStudentsAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
            Console.WriteLine("Student Not Saved");
            throw;
        }
        finally
        {
            isLoading = false;
            StateHasChanged();
        }
    }

    private async Task<List<Student>> GetStudentsAsync()
    {
        TrackMethod();

        if (_studentsAffairsDbContext is not null)
            return await _studentsAffairsDbContext.Students.AsNoTracking().ToListAsync();
        else
            return new();
    }

    private void EditStudent(Student toBeEditedStudent)
    {
        TrackMethod();

        string? studentSerialized = JsonSerializer.Serialize(toBeEditedStudent);
        if (studentSerialized is not null)
            _student = JsonSerializer.Deserialize<Student>(studentSerialized);

        StateHasChanged();
    }

    public async Task DeleteStudent(Student student)
    {
        TrackMethod();
        isLoading = true;
        ArgumentNullException.ThrowIfNull(student);

        try
        {
            _studentsAffairsDbContext?.Remove(student);
            ArgumentNullException.ThrowIfNull(_studentsAffairsDbContext);
            await _studentsAffairsDbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
            Console.WriteLine("Student Not Saved");
        }
        finally
        {
            isLoading = false;
            StateHasChanged();
        }
    }

    private async void ShowModal()
    {
        ArgumentNullException.ThrowIfNull(modalComponent);
        await modalComponent.ShowModal();
    }
}