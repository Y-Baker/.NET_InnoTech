namespace StudentDomain;

public interface IStudentService
{
    Task<List<Student>> GetStudents();
    Task ShowModal(Modal modal);
}
public class StudentService : IStudentService
{
    private readonly IStudentsUnitOfWork students;

    public StudentService(IStudentsUnitOfWork _students)
    {
        students = _students;
    }

    public async Task<List<Student>> GetStudents()
    {
        return (List<Student>)await students.ReadAll();
    }
    public async Task ShowModal(Modal modal)
    {
        ArgumentNullException.ThrowIfNull(modal);
        await modal.ShowModal();
    }
}
