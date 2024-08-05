//EntityFramework8 ORM object relational mapper =>
//DDL(Create table, Alter view, drop table),
//DML(Insert,Select,Update,Delete),
//DCL(Grant Update on table students to wael,revoke)


namespace StudentsAffairsWebAPI;

[Route("api/[controller]")]
[ApiController]
public class BaseController<TEntity> : ControllerBase
    where TEntity : BaseEntity
{
    const int maxEntityCount = 15;
    protected readonly StudentsAffairsDbContext _studentsAffairsDbContext;
    public BaseController(StudentsAffairsDbContext studentsAffairsDbContext)
    {
        _studentsAffairsDbContext = studentsAffairsDbContext;

        if (_studentsAffairsDbContext.Set<TEntity>() is null || !_studentsAffairsDbContext.Set<TEntity>().Any())
            Fill(maxEntityCount);
    }
    public void Fill(int desiredCount)
    {
        //TODO::fill using Activate
        for (int i = 1; i <= desiredCount; i++)
        {
            TEntity? entity = Activator.CreateInstance(typeof(TEntity)) as TEntity;
            if (entity is not null)
            {
                Type? entityType = typeof(TEntity);

                entity.Id = i;
                entity.Name = $"{entityType.Name} {i}";

                PropertyInfo? ageProperty = entityType.GetProperty("Age");
                if (ageProperty is not null && ageProperty.CanWrite)
                {
                    ageProperty.SetValue(entity, Convert.ToByte(i + 30));
                }

                PropertyInfo? mobileProperty = entityType.GetProperty("Mobile");
                if (mobileProperty is not null && mobileProperty.CanWrite)
                {
                    mobileProperty.SetValue(entity, $"012784512{i}");
                }

                _studentsAffairsDbContext.Set<TEntity>().Add(entity);
            }

        }

        _studentsAffairsDbContext.SaveChanges();
    }

    [HttpPost]
    public IActionResult Post([FromBody] TEntity entity)
    {
        _studentsAffairsDbContext.Set<TEntity>().Add(entity);
        _studentsAffairsDbContext.SaveChanges();

        return Created();
    }

    [HttpGet]
    public IEnumerable<TEntity> GetAll()
    {
        return _studentsAffairsDbContext.Set<TEntity>().ToList() ?? new();
    }

    [HttpGet("{id}")]
    public IActionResult GetBuId([FromRoute] string id)
    {
        bool isParsedAsInt = int.TryParse(id, out int idParsed);
        if (!isParsedAsInt)
            return BadRequest($"The value {id} can't be parsed as int");

        try
        {
            TEntity? entityFromDb = _studentsAffairsDbContext.Set<TEntity>().FirstOrDefault(e => e.Id.Equals(idParsed));

            return Ok(entityFromDb);
        }
        catch (Exception exception)
        {
            return NotFound(exception.Message);
        }
    }

    [HttpPut]
    public IActionResult Update([FromBody] TEntity entity)
    {
        if (entity is null || string.IsNullOrEmpty(entity.Name)) throw new Exception("The entity can't be null or its name can't be empty");

        try
        {
            TEntity? entityFromDb = _studentsAffairsDbContext.Set<TEntity>().FirstOrDefault(e => e.Id.Equals(entity.Id));
            
            if (entityFromDb is null) return NotFound(entity);

            //use reflections to read and set props 
            
            Type? entityType = typeof(TEntity);
            PropertyInfo[]? properties = entityType.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (property.CanWrite)
                {
                    object? value = property.GetValue(entity);
                    property.SetValue(entityFromDb, value);
                }
            }

            _studentsAffairsDbContext.Set<TEntity>().Update(entityFromDb);
            _studentsAffairsDbContext.SaveChanges();

            return Ok(entityFromDb);
        }
        catch (Exception exception)
        {
            return NotFound(exception.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] string id)
    {
        bool isParsedAsInt = int.TryParse(id, out int idParsed);
        if (!isParsedAsInt)
            return BadRequest($"The value {id} can't be parsed as int");

        try
        {
            TEntity? toBeDeletedEntity = _studentsAffairsDbContext.Set<TEntity>().FirstOrDefault(e => e.Id.Equals(idParsed));

            if (toBeDeletedEntity is not null)
            {
                _studentsAffairsDbContext.Set<TEntity>().Remove(toBeDeletedEntity);
                _studentsAffairsDbContext.SaveChanges();
            }

            return Ok(toBeDeletedEntity);
        }
        catch (Exception exception)
        {
            return NotFound(exception.Message);
        }
    }
    [HttpDelete]
    public IActionResult Delete([FromBody] TEntity entity)
    {
        if (entity is null) throw new Exception("The entity can't be null");

        try
        {
            TEntity? entityFromDb = _studentsAffairsDbContext.Set<TEntity>().FirstOrDefault(e => e.Id.Equals(entity.Id));
            if (entityFromDb is null) return NotFound(entity);

            _studentsAffairsDbContext.Set<TEntity>().Remove(entityFromDb);

            return Ok(entity);
        }
        catch (Exception exception)
        {
            return NotFound(exception.Message);
        }
    }
}
