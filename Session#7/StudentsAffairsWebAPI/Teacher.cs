namespace StudentsAffairsWebAPI;

public class Teacher : Student
{
    public ICollection<Teacher> ReadTeachers(int desiredCount)
    {
        ICollection<Teacher> teachers = new List<Teacher>();

        for (int i = 1; i <= desiredCount; i++)
        {
            Teacher teacher = new() { Id = i, Name = $"Teacher{i}", Age = i + 30 };
            teachers.Add(teacher);
        }

        return teachers;
    }
}
