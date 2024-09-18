namespace StudentAffairs;

public interface IDoctorsUnitOfWork : IPersonUnitOfWork<Doctor>
{
    Task<Doctor?> ReadByCourse(Course course);
}
