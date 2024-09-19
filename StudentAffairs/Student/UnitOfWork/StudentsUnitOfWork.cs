namespace StudentDomain;

public class StudentsUnitOfWork : UserUnitOfWork<Student>, IStudentsUnitOfWork
{
    private readonly StudentsAffairsDbContext _context;
    private readonly IStudentsRepository _studentsRepository;
    public StudentsUnitOfWork(StudentsAffairsDbContext context, IStudentsRepository studentsRepository) : base(context, studentsRepository)
    {
        _context = context;
        _studentsRepository = studentsRepository;
    }

    public Task<Student?> ReadByGPA(float value)
    {
        return _studentsRepository.GetByGPA(value);
    }
}

