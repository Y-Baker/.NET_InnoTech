using System.Net.Http;

namespace BlazorApp.Components;

public partial class StudentPage
{
    private bool isLoading = false;
    private Student? _student = new();
    List<Student> students = new List<Student>();

    readonly static string apiURL = @"http://localhost:5000/api";

    protected async override Task OnInitializedAsync()
    {
        isLoading = true;
        try
        {
            students = await Student.GetStudents(apiURL + "/students");
            isLoading = false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Request error: {ex.Message}");
            isLoading = true;
        }

        await base.OnInitializedAsync();
    }
    protected async override Task OnAfterRenderAsync(bool firstRender)
    {
        if (_student is not null && firstRender && !students.Any())
        {
            _student.Id = 1;
            _student.Name = "Wael Shehab Eldin";
            _student.Mobile = "01207888335";
            _student.Age = 44;
            await base.OnAfterRenderAsync(firstRender);
            StateHasChanged();
        }
    }

    private async void HandleValidSubmit()
    {
        if (isLoading)
        {
            Console.WriteLine("Can't Do New Process While Loading");
            return;
        }
        if (_student is null)
        {
            Console.WriteLine("Student Not Found");
            return;
        }

        isLoading = true;

        Random random = new Random();

        try
        {
            Student? studentFromList = students.FirstOrDefault(e =>
                e.Name is not null && e.Name.Equals(_student.Name));
            int idx = studentFromList is not null ? students.IndexOf(studentFromList) : -1;
            if (idx == -1)
            {
                _student.Id = random.Next(1000000, 9999999);
            }
            string studentSerialized = JsonSerializer.Serialize(_student);
            using (HttpClient? httpClient = new HttpClient())
            {
                HttpContent content = new StringContent(studentSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage? httpResponseMessage;
                if (idx == -1)
                    httpResponseMessage = await httpClient.PostAsync(apiURL + "/students", content);
                else
                    httpResponseMessage = await httpClient.PutAsync(apiURL + "/students", content);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    if (idx == -1)
                    {
                        Console.WriteLine("Added Successfully");
                        students.Add(JsonSerializer.Deserialize<Student>(studentSerialized)!);
                    }
                    else
                    {
                        Console.WriteLine("Update Successfully");
                        students[idx] = _student;
                    }
                }
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Request error: {ex.Message}");
            Console.WriteLine("Student Not Saved");
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

    private void EditStudent(Student toBeEditedStudent)
    {
        _student = toBeEditedStudent;

        StateHasChanged();
    }

    private async void DeleteStudent(Student toBeDeletedStudnet)
    {
        isLoading = true;
        StateHasChanged();
        try
        {
            using (HttpClient? httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.DeleteAsync(apiURL + $"/students/{toBeDeletedStudnet.Id}");
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Deleted Successfully");
                    students = await Student.GetStudents(apiURL + "/students");             
                }
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Request error: {ex.Message}");
            Console.WriteLine("Student Not Deleted");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
            Console.WriteLine("Student Not Deleted");
        }
        finally
        {
            isLoading = false;
            StateHasChanged();
        }
    }
}
