namespace DoctorDomain;

public class DoctorsRepository : UserRepository<Doctor>, IDoctorsRepository
{
    public DoctorsRepository(StudentsAffairsDbContext context) : base(context) { }

    public async Task<Doctor?> GetByCourse(Course course)
    {
        Doctor? doctorFromDb = await _dbSet.FindAsync(course.InstructorId);

        return doctorFromDb;
    }
}