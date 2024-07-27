namespace StudentsAffairs;

public class Teacher : Student
{
    //public string? Name { get; set; }
    //public string? Name
    //{
    //    get { return _name; }
    //    set
    //    {
    //        if (value is not null && value.Length > 5)
    //            _name = value;
    //    }
    //}
    //private string? _name;

    public string? Greeting(string name, string language)
    {
        string greetings = string.Empty;

        if (language.Equals("English"))
        {
            greetings = Greeting(name) ?? "Hi";
            //greetings = Greeting(name) ?? "Hi";
        }
        else
            greetings = "Hola";

        return greetings;
    }

    public static ICollection<Teacher> ReadTeachers(int desiredCount)
    {
        ICollection<Teacher> teachers = new List<Teacher>();

        for (int i = 1; i <= desiredCount; i++)
        {
            Teacher teacher = new() { Id = i, Name = $"Teacher{i}", Age = i + 30 };
            teachers.Add(teacher);
        }

        return teachers;
    }

    public static ICollection<Teacher> ReadTeachers(int start, int desiredCount)
    {
        ICollection<Teacher> teachers = new List<Teacher>();

        for (int i = 0; i < desiredCount; i++)
        {
            Teacher teacher = new() { Id = i + start, Name = $"Teacher{i + start}", Age = i + 30 };
            teachers.Add(teacher);
        }

        return teachers;
    }
}
