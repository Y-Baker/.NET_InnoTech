namespace UserDomain;

public class UserRepository<TEntity> : Repository<TEntity>, IUserRepository<TEntity>
    where TEntity : User
{
    public UserRepository(StudentsAffairsDbContext context) : base(context) { }

    public async Task<bool> CheckEmailExists(string email)
    {
        return await _dbSet.AnyAsync(e => e.Email == email);
    }
}