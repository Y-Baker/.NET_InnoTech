using System;
using System.Text;
using System.Text.Json;
using BlazorApp.Models;
namespace BlazorApp.Pages;

public partial class StudentPage
{
    private Student _student = new();
    List<Student> students = new List<Student>();
    readonly static string apiURL = @"https://students.innopack.app/api";
    protected async override Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        students = await Student.GetStudents(apiURL + "/students");
        if (firstRender && !students.Any())
        {
            _student.Id = 1;
            _student.Name = "Wael Shehab Eldin";
            _student.Mobile = "01207888335";
            _student.Age = 44;
        }
        StateHasChanged();
    }

    private async void HandleValidSubmit()
    {
        HttpClient httpClient = new HttpClient();
        Random random = new Random();
        int idx = -1;
        _student.Id = random.Next(1000000, 9999999);
        if (_student is not null)
        {
            Student? studentFromList = students.FirstOrDefault(e =>
                e.Name is not null && e.Name.Equals(_student.Name));
            if (studentFromList is not null)
            {
                idx = students.IndexOf(studentFromList);
                Student studentToUpdate = new();
                studentToUpdate.Id = students[idx].Id;
                studentToUpdate.Name = _student.Name;
                studentToUpdate.Mobile = _student.Mobile;
                studentToUpdate.Age = _student.Age;

                string studentSerialized = JsonSerializer.Serialize(studentToUpdate);
                HttpContent content = new StringContent(studentSerialized, Encoding.UTF8, "application/json");
                HttpResponseMessage? response = await httpClient.PutAsync(apiURL + "/students", content);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Update Successfully");
                    students[idx] = studentToUpdate;
                }
            }
            if (studentFromList is null || idx < 0)
            {
                string studentSerialized = JsonSerializer.Serialize(_student);
                HttpContent content = new StringContent(
                    studentSerialized, Encoding.UTF8, "application/json"
                );
                HttpResponseMessage? response = await httpClient.PostAsync(apiURL + "/students", content);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Added Successfully");
                    students.Add(JsonSerializer.Deserialize<Student>(studentSerialized)!);
                }
            }
        }
    }

    private void EditStudent(Student toBeEditedStudent)
    {
        _student = toBeEditedStudent;

        StateHasChanged();
    }

}