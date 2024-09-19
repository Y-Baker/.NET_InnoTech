namespace StudentDomain;

public interface IStudentsUnitOfWork : IUserUnitOfWork<Student>
{
    Task<Student?> ReadByGPA(float value);
}