namespace StudentAffairs;

public interface IDoctorsRepository : IUserRepository<Doctor>
{
    Task<Doctor?> GetByCourse(Course course);
}
