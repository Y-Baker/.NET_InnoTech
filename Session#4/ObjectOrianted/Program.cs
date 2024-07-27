using StudentsAffairs;

const int desiredTeachersCount = 20;

Console.WriteLine("Hello, World!");


ICollection<Teacher> teachers = new List<Teacher>();

for (int i = 1; i <= desiredTeachersCount; i++)
{
    Teacher teacher = new() { Id = i, Name = $"Student{i}", Age = i + 20 };
    //teacher.Id = i;
    //teacher.Name = $"Student{i}";
    //teacher.Age = i + 20;

    teachers.Add(teacher);
}

Teacher? teacherToBeRemoved = teachers.FirstOrDefault(e => e.Name is not null && e.Name.ToLower().Equals("student13"));
if (teacherToBeRemoved is not null)
    teachers.Remove(teacherToBeRemoved);


foreach (Teacher teacher in teachers)
{
    Console.WriteLine($"Teacher Id = {teacher.Id}, Teacher Name = {teacher.Name}, Teacher Age = {teacher.Age}");
}

List<int> ages = new() { 10, 20, 30, 40, 50 };

foreach (int age in ages)
{
    Console.WriteLine($"age = {age}");
}