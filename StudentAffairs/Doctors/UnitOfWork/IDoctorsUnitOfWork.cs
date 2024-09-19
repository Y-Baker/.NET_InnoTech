namespace DoctorDomain;

public interface IDoctorsUnitOfWork : IUserUnitOfWork<Doctor>
{
    Task<Doctor?> ReadByCourse(Course course);
}
