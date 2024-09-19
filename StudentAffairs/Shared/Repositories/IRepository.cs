namespace StudentAffairs;
public interface IRepository<TEntity> 
    where TEntity : BaseEntity
{
    Task Insert(TEntity entity);

    Task<IEnumerable<TEntity>> GetAll();
    Task<TEntity?> GetById(Guid id);
    Task<TEntity?> GetByName(string name);

    Task Update(TEntity entity);

    Task Delete(TEntity entity);
    Task Delete(Guid id);
}
