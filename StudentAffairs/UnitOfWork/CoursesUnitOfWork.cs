namespace StudentAffairs;

public class CoursesUnitOfWork : UnitOfWork<Course>, ICoursesUnitOfWork
{
    private readonly StudentsAffairsDbContext _context;
    private readonly ICoursesRepository _repository;

    public CoursesUnitOfWork(StudentsAffairsDbContext context, ICoursesRepository repository) : base(context, repository)
    {
        _context = context;
        _repository = repository;
    }
}
