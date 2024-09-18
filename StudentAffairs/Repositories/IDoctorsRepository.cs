namespace StudentAffairs;

public interface IDoctorsRepository : IPersonRepository<Doctor>
{
    Task<Doctor?> GetByCourse(Course course);
}
