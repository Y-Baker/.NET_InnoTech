namespace StudentAffairs;

public class PersonUnitOfWork<TEntity> : UnitOfWork<TEntity>, IPersonUnitOfWork<TEntity>
    where TEntity : Person
{
    private readonly StudentsAffairsDbContext _context;
    private readonly IPersonRepository<TEntity> _repository;

    public PersonUnitOfWork(StudentsAffairsDbContext context, IPersonRepository<TEntity> repository) : base(context, repository)
    {
        _context = context;
        _repository = repository;
    }

    public Task<bool> EmailExists(string email)
    {
        return _repository.CheckEmailExists(email);
    }
}

