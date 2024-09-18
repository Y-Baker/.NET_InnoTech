namespace StudentAffairs;

public interface IStudentsUnitOfWork : IPersonUnitOfWork<Student>
{
    Task<Student?> ReadByGPA(float value);
}