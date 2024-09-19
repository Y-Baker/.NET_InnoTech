namespace StudentAffairs;

public interface IDoctorsUnitOfWork : IUserUnitOfWork<Doctor>
{
    Task<Doctor?> ReadByCourse(Course course);
}
