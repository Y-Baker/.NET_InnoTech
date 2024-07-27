namespace StudentsAffairsWebAPI.Controllers;
[ApiController]
[Route("api/[controller]")]

public class TeachersController : ControllerBase
{
    const int maxTeachersCount = 15;
    readonly static string directory = @"./logs/";
    readonly static string filePath = directory + "Teachers.json";
    private List<Teacher>? teachers = new();
    Teacher teacher = new();

    public TeachersController()
    {
        if (Directory.Exists(filePath) is false)
        {
            Directory.CreateDirectory(directory);
        }
        FileInfo fileInfo = new FileInfo(filePath);
        if (fileInfo.Exists)
        {

            string? fileContent = System.IO.File.ReadAllText(filePath);
            if (fileContent.Length == 0)
            {
                teachers = new List<Teacher>();
            }
            else
            {
                teachers = JsonSerializer.Deserialize<List<Teacher>>(fileContent);
            }
        }

        if (teachers is null)
        {
            teachers = Teacher.ReadTeachers(maxTeachersCount).ToList();
            string? fileContent = JsonSerializer.Serialize(teachers);

            System.IO.File.WriteAllText(filePath, fileContent);
        }

    }

    [HttpGet]
    public IEnumerable<Teacher> Get()
    {
        return teachers ?? new();
    }

    [HttpPost]
    public void Post(Teacher teacher)
    {
        string? content = System.Text.Json.JsonSerializer.Serialize(teacher);
        if (System.IO.File.Exists(filePath) == false || System.IO.File.ReadAllBytes(filePath).Length == 0)
        {
            content = '[' + content + "]";
            System.IO.File.WriteAllText(filePath, content);
        }
        else
        {
            content += ']';
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite))
            {
                fs.Seek(-1, SeekOrigin.End);
                fs.WriteByte((byte)',');
                fs.Write(Encoding.UTF8.GetBytes(content));
            }
        }
    }

    [HttpPut]
    public void Update(int key, Teacher teacher)  // https://localhost:7153/api/teachers/?key=17
    {
        for (int i = 0; i < teachers?.Count; i++)
        {
            if (teachers[i].Id == key)
            {
                teachers[i] = teacher;
                break;
            }
        }
        string? fileContent = JsonSerializer.Serialize(teachers);
        System.IO.File.WriteAllText(filePath, fileContent);
    }

    [HttpDelete]
    public void Delete(int key) // https://localhost:7153/api/teachers/?key=13
    {
        for (int i = 0; i < teachers?.Count; i++)
        {
            if (teachers[i].Id == key)
                teachers.RemoveAt(i);
        }
        string? fileContent = JsonSerializer.Serialize(teachers);
        System.IO.File.WriteAllText(filePath, fileContent);
    }
}
