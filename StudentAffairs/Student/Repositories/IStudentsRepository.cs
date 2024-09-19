namespace StudentDomain;

public interface IStudentsRepository : IUserRepository<Student>
{
    Task<Student?> GetByGPA(float value);
}
