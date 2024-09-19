namespace StudentAffairs;

public class UnitOfWork<TEntity> : IUnitOfWork<TEntity>
    where TEntity : BaseEntity
{
    private readonly StudentsAffairsDbContext _context;
    private readonly IRepository<TEntity> _repository;
    const byte maxAge = 21;
    public UnitOfWork(StudentsAffairsDbContext context, IRepository<TEntity> repository)
    {
        _context = context;
        _repository = repository;
    }

    public async Task Create(TEntity entity)
    {
        using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
        {
            try
            {
                await _repository.Insert(entity);

                transaction.Commit();
            }
            catch (Exception exception)
            {
                transaction.Rollback(); 
                Console.WriteLine(exception.Message);
            }
        }
    }

    public Task<IEnumerable<TEntity>> ReadAll()
    {
        return _repository.GetAll();
    }
    public Task<TEntity?> ReadById(Guid id)
    {
        return _repository.GetById(id);
    }
    public Task<TEntity?> ReadByName(string name)
    {
        return _repository.GetByName(name);
    }

    public async Task Update(TEntity entity)
    {
        using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
        {
            try
            {
                await _repository.Update(entity);

                transaction.Commit();
            }
            catch (Exception exception)
            {
                transaction.Rollback();
                Console.WriteLine(exception.Message);
            }
        }
    }

    public Task Delete(TEntity entity)
    {
        return _repository.Delete(entity);
    }
    public Task Delete(Guid id)
    {
        return _repository.Delete(id);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}

