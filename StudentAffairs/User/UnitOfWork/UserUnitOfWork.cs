namespace UserDomain;

public class UserUnitOfWork<TEntity> : UnitOfWork<TEntity>, IUserUnitOfWork<TEntity>
    where TEntity : User
{
    private readonly StudentsAffairsDbContext _context;
    private readonly IUserRepository<TEntity> _repository;

    public UserUnitOfWork(StudentsAffairsDbContext context, IUserRepository<TEntity> repository) : base(context, repository)
    {
        _context = context;
        _repository = repository;
    }

    public Task<bool> EmailExists(string email)
    {
        return _repository.CheckEmailExists(email);
    }
}

