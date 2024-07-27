namespace StudentsAffairs;

public class Student
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }

    public virtual string? Greeting(string name)
    {
        Student student = new Student();
        student.Name = name;

        return $"Hello {student.Name}";
    }
}
