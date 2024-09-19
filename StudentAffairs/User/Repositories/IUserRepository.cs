namespace StudentAffairs;

public interface IUserRepository<TEntity> : IRepository<TEntity>
    where TEntity : User
{
    Task<bool> CheckEmailExists(string email);
}
