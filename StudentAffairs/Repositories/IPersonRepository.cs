namespace StudentAffairs;

public interface IPersonRepository<TEntity> : IRepository<TEntity>
    where TEntity : Person
{
    Task<bool> CheckEmailExists(string email);
}
