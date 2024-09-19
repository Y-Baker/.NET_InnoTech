namespace StudentAffairs;

public interface IStudentsRepository : IUserRepository<Student>
{
    Task<Student?> GetByGPA(float value);
}
