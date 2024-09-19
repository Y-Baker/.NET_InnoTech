namespace DoctorDomain;

public interface IDoctorsRepository : IUserRepository<Doctor>
{
    Task<Doctor?> GetByCourse(Course course);
}
