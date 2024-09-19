namespace UserDomain;

public interface IUserUnitOfWork<TEntity> : IUnitOfWork<TEntity>
    where TEntity : User
{
    Task<bool> EmailExists(string email);
}