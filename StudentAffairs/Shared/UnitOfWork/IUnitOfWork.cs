namespace Shared;

public interface IUnitOfWork<TEntity>
    where TEntity : BaseEntity
{
    Task Create(TEntity student);

    Task<IEnumerable<TEntity>> ReadAll();
    Task<TEntity?> ReadById(Guid id);
    Task<TEntity?> ReadByName(string name);

    Task Update(TEntity entity);

    Task Delete(TEntity student);
    Task Delete(Guid id);
}