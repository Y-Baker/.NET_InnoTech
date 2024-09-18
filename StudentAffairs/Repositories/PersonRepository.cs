namespace StudentAffairs;

public class PersonRepository<TEntity> : Repository<TEntity>, IPersonRepository<TEntity>
    where TEntity : Person
{
    public PersonRepository(StudentsAffairsDbContext context) : base(context) { }

    public async Task<bool> CheckEmailExists(string email)
    {
        return await _dbSet.AnyAsync(e => e.Email == email);
    }
}