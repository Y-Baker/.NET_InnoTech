## Task 1

#### Use StopWatch to calculate the different between save changes after every addion and just one save changes at the end

* After every add new object
```cs
Stopwatch stopwatch = new();
stopwatch.Start();
for (int i = 1; i <= desiredCount; i++)
{
    Student student = new() { Id = i, Name = $"Student{i}", Age = Convert.ToByte(i + 30), Mobile = $"012784512{i}" };
    _studentsAffairsDbContext.Students.Add(student);
    _studentsAffairsDbContext.SaveChanges();
}
stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds);
```

- The output
```
126
```

* After add all object
```cs
Stopwatch stopwatch = new();
stopwatch.Start();
for (int i = 1; i <= desiredCount; i++)
{
    Student student = new() { Id = i, Name = $"Student{i}", Age = Convert.ToByte(i + 30), Mobile = $"012784512{i}" };
    _studentsAffairsDbContext.Students.Add(student);
}
_studentsAffairsDbContext.SaveChanges();
stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds);
```

- The output
```
7
```

---

## Task 2
* [src](./StudentsAffairsDBWebAPI/Controllers/BaseController.cs)
* [sln](./StudentsAffairsDBWebAPI/StudentsAffairsWebAPI.sln)


### use reflections to read and set props
```cs
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
```
Get all properties of entity and iterate for each property get the value of this entity in entity variable and set it to entityFromDb


### fill using Activate
```cs
for (int i = 1; i <= desiredCount; i++)
{
    TEntity? entity = Activator.CreateInstance(typeof(TEntity)) as TEntity;
    if (entity is not null)
    {
        Type? entityType = typeof(TEntity);

        entity.Id = i;
        entity.Name = $"TEntity{i} {entityType.Name}";

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
```

First you need for each object to use Activator to create a new instance of type TEntity and add the Id and Name properities but as TEntity doesn't have the mobile and age properities you can't use them directly so i use reflection to get and set the values


### Complete Task

Make all Controller inhurit from baseController and create new tables for doctors and teachers

Test all CURD for each controller

---


<br />

## Authors :black_nib:
* [__Repo__](https://github.com/Y-Baker/.NET_InnoTech)
* __Yousef Bakier__ &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />
 &nbsp;&nbsp;[<img height="" src="https://img.shields.io/static/v1?label=&message=GitHub&color=181717&logo=GitHub&logoColor=f2f2f2&labelColor=2F333A" alt="Github">](https://github.com/Y-Baker)
