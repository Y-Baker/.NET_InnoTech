namespace StudentsAffairsWebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeachersController : ControllerBase
{
    const int maxTeachersCount = 15;
    private List<Teacher>? teachers = new();
    Teacher teacher = new();
    const string filePath = @"Teachers.json";

    public TeachersController()
    {
        FileInfo fileInfo = new FileInfo(filePath);
        if (fileInfo.Exists)
        {
            string? fileContent = System.IO.File.ReadAllText(filePath);
            teachers = JsonSerializer.Deserialize<List<Teacher>>(fileContent);
        }

        if (teachers is null || !teachers.Any())
        {
            teachers = teacher.ReadTeachers(maxTeachersCount).ToList();
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
        teachers?.Add(teacher);

        string? fileContent = JsonSerializer.Serialize(teachers);
        System.IO.File.WriteAllText(filePath, fileContent);
    }

    [HttpDelete]
    public void Delete(Teacher teacher)
    {
        //TODO:: Find teacher in teachers list and remove from list and write to HD
        teachers?.Remove(teacher);

        string? fileContent = JsonSerializer.Serialize(teachers);
        System.IO.File.WriteAllText(filePath, fileContent);
    }
}
