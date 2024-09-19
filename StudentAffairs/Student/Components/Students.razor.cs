using Microsoft.AspNetCore.Components;

namespace StudentAffairs;

public partial class Students
{
    Student? _student = new();
    List<Student>? students = new List<Student>();
    bool isLoading = false;
    Student? _studentToDelete;
    Modal? modal;
    [Inject] public IStudentsUnitOfWork? _students { get; set; }
    [Inject] public IStudentService? _service { get; set; }

    protected async override Task OnInitializedAsync()
    {
        Track.TrackMethod();
        ArgumentNullException.ThrowIfNull(_service, nameof(_service));
        students = await _service.GetStudents();

        await base.OnInitializedAsync();
    }
    private async Task HandleValidSubmit()
    {
        Track.TrackMethod();

        if (isLoading)
        {
            Console.WriteLine("Can't Do New Process While Loading");
            return;
        }
        if (_student is null)
        {
            Console.WriteLine($"{nameof(_student)} Not Found");
            return;
        }

        isLoading = true;
        StateHasChanged();

        try
        {
            string studentSerialized = _student is null ? string.Empty : JsonSerializer.Serialize(_student);
            Student? validStudent = JsonSerializer.Deserialize<Student>(studentSerialized);
            ArgumentNullException.ThrowIfNull(validStudent, nameof(validStudent));

            Student? newStudent = students?.FirstOrDefault(e => e.Id == validStudent.Id);

            ArgumentNullException.ThrowIfNull(_students, nameof(_students));
            if (newStudent is null)
            {
                validStudent.Id = Guid.NewGuid();
                await _students.Create(validStudent);
            }
            else
            {
                await _students.Update(validStudent);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
            Console.WriteLine($"{nameof(_student)} Not Saved");
            throw;
        }
        finally
        {
            ArgumentNullException.ThrowIfNull(_service, nameof(_service));
            students = await _service.GetStudents();
            isLoading = false;
            Clear();
            StateHasChanged();
        }
    }

    private void EditStudent(Student toBeEditedStudent)
    {
        Track.TrackMethod();

        string? studentSerialized = JsonSerializer.Serialize(toBeEditedStudent);
        if (studentSerialized is not null)
            _student = JsonSerializer.Deserialize<Student>(studentSerialized);

        StateHasChanged();
    }

    private async void PrepareForDelete(Student student)
    {
        ArgumentNullException.ThrowIfNull(_service, nameof(_service));
        ArgumentNullException.ThrowIfNull(modal, nameof(modal));
        _studentToDelete = student;
        await _service.ShowModal(modal);
    }
    private async Task ConfirmDelete()
    {
        if (_studentToDelete != null)
        {
            await DeleteStudent(_studentToDelete);
        }
    }
    private async Task DeleteStudent(Student student)
    {
        Track.TrackMethod();
        isLoading = true;
        ArgumentNullException.ThrowIfNull(student, nameof(student));
        ArgumentNullException.ThrowIfNull(_students, nameof(_students));

        try
        {
            await _students.Delete(student);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
            Console.WriteLine("Student Not Saved");
        }
        finally
        {
            ArgumentNullException.ThrowIfNull(_service, nameof(_service));
            students = await _service.GetStudents();
            isLoading = false;
            StateHasChanged();
        }
    }

    private void Clear()
    {
        _student = new();
    }
}