namespace CourseDomain;

public interface ICourseService
{
    Task<List<Doctor>> GetDoctors();
    Task<List<Course>> GetCourses();

    Task<Doctor> GetInstructor(Course course);
    Task<Course> GetCourse(Guid id);

    Task ShowModal(Modal modal);
}
public class CourseService : ICourseService
{
    private readonly StudentsAffairsDbContext context;
    private readonly ICoursesUnitOfWork courses;

    public CourseService(StudentsAffairsDbContext _context, ICoursesUnitOfWork _courses)
    {
        context = _context;
        courses = _courses;
    }

    public async Task<List<Doctor>> GetDoctors()
    {
        return await context.Doctors.ToListAsync();
    }
    public async Task<List<Course>> GetCourses()
    {
        return (List<Course>)await courses.ReadAll();
    }

    public async Task<Doctor> GetInstructor(Course course)
    {
        Doctor? doctor = await context.Doctors.FindAsync(course.InstructorId);
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
