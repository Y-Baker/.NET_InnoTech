namespace StudentAffairs;

public class DoctorsUnitOfWork : UserUnitOfWork<Doctor> , IDoctorsUnitOfWork
{
    private readonly StudentsAffairsDbContext _context;
    private readonly IDoctorsRepository _repository;

    public DoctorsUnitOfWork(StudentsAffairsDbContext context, IDoctorsRepository repository) : base(context, repository)
    {
        _context = context;
        _repository = repository;
    }

    public Task<Doctor?> ReadByCourse(Course course)
    {
        return _repository.GetByCourse(course);
    }
}
