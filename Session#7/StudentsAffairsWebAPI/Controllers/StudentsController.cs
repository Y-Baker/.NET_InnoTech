using System;

namespace StudentsAffairsWebAPI;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    List<Student> students = new();
    Student student = new();
    const int maxStudentsCount = 15;
    const string filePath = "Students.json";
    public StudentsController()
    {
        FileInfo fileInfo = new FileInfo(filePath);
        if (fileInfo.Exists)
        {
            string? fileContent = System.IO.File.ReadAllText(filePath);
            students = JsonSerializer.Deserialize<List<Student>>(fileContent);
        }

        if (students is null || !students.Any())
        {
            FillStudents(maxStudentsCount);
            string? fileContent = JsonSerializer.Serialize(students);

            System.IO.File.WriteAllText(filePath, fileContent);
        }
    }
    public void FillStudents(int desiredCount)
    {
        for (int i = 1; i <= desiredCount; i++)
        {
            Student student = new() { Id = i, Name = $"Student{i}", Age = i + 30, Mobile = $"012784512{i}" };
            students.Add(student);
        }
    }

    [HttpPost]
    public IActionResult Post([FromBody] Student student)
    {
        students?.Add(student);

        string? fileContent = JsonSerializer.Serialize(students);
        System.IO.File.WriteAllText(filePath, fileContent);

        return Created();
    }

    [HttpGet]
    public IEnumerable<Student> GetAll()
    {
        return students ?? new();
    }


    [HttpGet("{id}")]
    public IActionResult GetBuId([FromRoute] string id)
    {
        bool isParsedAsInt = int.TryParse(id, out int idParsed);
        if (!isParsedAsInt)
            return BadRequest($"The value {id} can't be parsed as int");

        try
        {
            Student? studentFromList = students.FirstOrDefault(e => e.Id.Equals(idParsed));

            return Ok(studentFromList);
        }
        catch (Exception exception)
        {
            return NotFound(exception.Message);
        }
    }

    //// PUT api/<StudentsController>/5
    //[HttpPut("{id}")]
    //public void Put(int id, [FromBody] string value)
    //{
    //}
    [HttpPut]
    public IActionResult Update([FromBody] Student student)
    {
        if (student is null || string.IsNullOrEmpty(student.Name)) throw new Exception("The student can't be null or its name can't be empty");

        try
        {
            Student? studentFromList = students.FirstOrDefault(e => e.Name is not null && e.Name.Equals(student.Name));
            if (studentFromList is null) return NotFound(student);
            int toBeUpdatedStudentIndex = students.IndexOf(studentFromList);

            if (toBeUpdatedStudentIndex >= 0)
                students[toBeUpdatedStudentIndex] = student;
            else
                return NotFound(student);

            string? fileContent = JsonSerializer.Serialize(students);
            System.IO.File.WriteAllText(filePath, fileContent);

            return Ok(student);
        }
        catch (Exception exception)
        {
            return NotFound(exception.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] string id)
    {
        bool isParsedAsInt = int.TryParse(id, out int idParsed);
        if (!isParsedAsInt)
            return BadRequest($"The value {id} can't be parsed as int");

        try
        {
            List<Student> toBeDeletedStudents = new();

            foreach (Student student in students)
            {
                if (student.Id == idParsed)
                {
                    toBeDeletedStudents.Add(student);
                }
            }
            if (toBeDeletedStudents.Count > 0)
            {
                foreach (Student student in toBeDeletedStudents)
                {
                    students.Remove(student);
                }
            }
            else
            {
                return NotFound(idParsed);
            }

            string? fileContent = JsonSerializer.Serialize(students);
            System.IO.File.WriteAllText(filePath, fileContent);

            return Ok(toBeDeletedStudents);
        }
        catch (Exception exception)
        {
            return NotFound(exception.Message);
        }
    }
    [HttpDelete]
    public IActionResult Delete([FromBody] Student student)
    {
        if (student is null) throw new Exception("The student can't be null");

        try
        {
            List<Student> toBeDeletedStudents = new();

            foreach (Student studentFromStudents in students)
            {
                if (student.Name.Equals(studentFromStudents.Name))
                {
                    toBeDeletedStudents.Add(studentFromStudents);
                }
            }
            if (toBeDeletedStudents.Count > 0)
            {
                foreach (Student studentToDelete in toBeDeletedStudents)
                {
                    students.Remove(studentToDelete);
                }
            }
            else
            {
                return NotFound(student);
            }

            string? fileContent = JsonSerializer.Serialize(students);
            System.IO.File.WriteAllText(filePath, fileContent);

            return Ok(toBeDeletedStudents);
        }
        catch (Exception exception)
        {
            return NotFound(exception.Message);
        }
    }
}
