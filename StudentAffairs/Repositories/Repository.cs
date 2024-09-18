namespace StudentAffairs;

public class Repository<TEntity> : IRepository<TEntity> 
    where TEntity : BaseEntity
{
    protected readonly StudentsAffairsDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;
    public Repository(StudentsAffairsDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public virtual async Task Insert(TEntity entity)
    {
        EntityEntry<TEntity>? createdEntity = await _dbSet.AddAsync(entity);

        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAll()
    {
        List<TEntity>? entities = await _dbSet.ToListAsync();

        return entities;
    }

    public async Task<TEntity?> GetById(Guid id)
    {
        TEntity? entityFromDB = await _dbSet.FindAsync(id);
        return entityFromDB;
    }
    public async Task<TEntity?> GetByName(string name)
    {
        TEntity? entityFromDb = await _dbSet.FirstOrDefaultAsync(e => e.Name != null && e.Name.Contains(name));

        return entityFromDb;
    }

    public async Task Update(TEntity entity)
    {
        _context.ChangeTracker.Clear();

        _dbSet.Update(entity);

        await _context.SaveChangesAsync();
    }

    public async Task Delete(TEntity applicant)
    {
        await Delete(applicant.Id);

        await _context.SaveChangesAsync();
    }
    public async Task Delete(Guid id)
    {
        TEntity? entityFromDb = await GetById(id);

        if (entityFromDb is not null)
        {
            _dbSet.Remove(entityFromDb);

            await _context.SaveChangesAsync();
        }
    }
}
