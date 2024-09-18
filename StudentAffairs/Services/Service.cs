namespace StudentAffairs;

public interface IService
{
    Task<List<Student>> GetStudents();
    Task<List<Doctor>> GetDoctors();
    Task<List<Course>> GetCourses();

    Task<Doctor> GetInstructor(Course course);
    Task<Course> GetCourse(Guid id);

    Task ShowModal(Modal modal);
}
public class Service : IService
{
    private readonly IStudentsUnitOfWork students;
    private readonly IDoctorsUnitOfWork doctors;
    private readonly ICoursesUnitOfWork courses;

    public Service(IStudentsUnitOfWork _students,
                   IDoctorsUnitOfWork _doctors,
                   ICoursesUnitOfWork _courses)
    {
        students = _students;
        doctors = _doctors;
        courses = _courses;
    }

    public async Task<List<Student>> GetStudents()
    {
        return (List<Student>)await students.ReadAll();
    }
    public async Task<List<Doctor>> GetDoctors()
    {
        return (List<Doctor>)await doctors.ReadAll();
    }
    public async Task<List<Course>> GetCourses()
    {
        return (List<Course>)await courses.ReadAll();
    }

    public async Task<Doctor> GetInstructor(Course course)
    {
        Doctor? doctor = await doctors.ReadByCourse(course);
        return doctor ?? new();
    }
    public async Task<Course> GetCourse(Guid id)
    {
        Course? course = await courses.ReadById(id);
        return course ?? new();
    }

    public async Task ShowModal(Modal modal)
    {
        ArgumentNullException.ThrowIfNull(modal);
        await modal.ShowModal();
    }
}
