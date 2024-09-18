namespace StudentAffairs;

public interface IPersonUnitOfWork<TEntity> : IUnitOfWork<TEntity>
    where TEntity : Person
{
    Task<bool> EmailExists(string email);
}