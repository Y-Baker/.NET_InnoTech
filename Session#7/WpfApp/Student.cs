using System.Net.Http;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace StudentWpf;

internal class Student
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("age")]
    public int Age { get; set; }

    [JsonPropertyName("mobile")]
    public string? Mobile { get; set; }

    public static List<Student> GetStudents(string url)
    {
        if (string.IsNullOrEmpty(url))
            return new List<Student>();

        HttpClient client = new HttpClient();

        HttpResponseMessage? httpResponseMessage = client.GetAsync(url).GetAwaiter().GetResult();
        if (httpResponseMessage.IsSuccessStatusCode)
        {
            string responseContent = httpResponseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Console.WriteLine(responseContent);
            List<Student>? students = JsonSerializer.Deserialize<List<Student>>(responseContent);
            return students ?? new List<Student>();
        }
        return new List<Student>();
    }
}
