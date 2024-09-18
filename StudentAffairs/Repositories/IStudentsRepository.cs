namespace StudentAffairs;

public interface IStudentsRepository : IPersonRepository<Student>
{
    Task<Student?> GetByGPA(float value);
}
