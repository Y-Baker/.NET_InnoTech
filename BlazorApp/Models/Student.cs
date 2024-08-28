using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlazorApp.Models;

public class Student
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("mobile")]
    public string? Mobile { get; set; }

    [JsonPropertyName("age")]
    public int Age { get; set; }

    public Student(string? name = null, string? mobile = null, int age = 18)
    {
        this.Name = name;
        this.Mobile = mobile;
        this.Age = age;
    }

    public static async Task<List<Student>> GetStudents(string url)
    {
        if (string.IsNullOrEmpty(url))
            return new List<Student>();

        HttpClient client = new HttpClient();

        HttpResponseMessage httpResponseMessage = await client.GetAsync(url);
        if (httpResponseMessage.IsSuccessStatusCode)
        {
            string responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
            List<Student>? students = JsonSerializer.Deserialize<List<Student>>(responseContent);
            return students ?? new List<Student>();
        }
        return new List<Student>();
    }
}
