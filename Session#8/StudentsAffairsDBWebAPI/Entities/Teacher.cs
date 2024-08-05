namespace StudentsAffairsWebAPI;

public class Teacher : BaseEntity
{
    public int Age { get; set; }
    public string? Mobile { get; set; }
    public ICollection<Teacher> ReadTeachers(int desiredCount)
    {
        ICollection<Teacher> teachers = new List<Teacher>();

        for (int i = 1; i <= desiredCount; i++)
        {
            Teacher teacher = new() { Id = i, Name = $"Teacher{i}", Age = Convert.ToByte(i + 30) };
            teachers.Add(teacher);
        }

        return teachers;
    }
}
