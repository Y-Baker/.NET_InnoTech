# Student Affairs Project
- Version: 0.2.3

## Invoke The Name Of the Method
* [src](./Components/Pages/Students.razor.cs)

#### Method 1:
```cs
private void TrackMethod([CallerMemberName] string methodName = "")
{
    Console.WriteLine($"{methodName} invoked.");
}
```
- Then Just Call 
```cs
Track.TrackMethod();
```

#### Method 2:
```cs
MethodBase.GetCurrentMethod()?.Name
```

---

<br />

## reflection to get all assmblies
* [src](./StudentsAffairsDbContext.cs)

```cs
//TODO:: HasSet<Assembly> refrencedAssemblies  = Use reflection to get allllll refrecing assmblies
Assembly currentAssembly = Assembly.GetExecutingAssembly();
HashSet<Assembly> referencedAssemblies = currentAssembly.GetReferencedAssemblies()
                                                        .Select(x => Assembly.Load(x))
                                                        .ToHashSet() ?? new ();
referencedAssemblies.Add(currentAssembly);
//Foreach Assembly in refrencedAssemblies modelBuilder.ApplyConfigurationsFromAssembly()
foreach (Assembly assembly in referencedAssemblies)
{
    modelBuilder.ApplyConfigurationsFromAssembly(assembly);
}
```

---

<br />

## Read Constants from appsettings.json
* [src](./Program.cs)
#### Json Structure
```json
"ConnectionStrings": {
    "SQL-Server": "Data Source=.;Initial Catalog=StudentsAffairsDB;User Id=windows;Password=root;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;",
    "MySQL": "Server=172.30.136.6;Database=StudentsAffairsDB;User=windows;Password=root;Connect Timeout=60;"
  }
```
#### How to invoke
- first you need a class which has attribute match the constants
```cs
public class ConnectionStrings
{
    public string? SQLServer { get; set; }
    public string? MySQL { get; set; }
}
```
- then call
```cs
webApplicationBuilder.Configuration.GetSection("ConnectionStrings").Get<ConnectionStrings>()
```
---

<br />

## Authors :black_nib:
* [__Repo__](https://github.com/Y-Baker/.NET_InnoTech/)
* __Yousef Bakier__ &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />
 &nbsp;&nbsp;[<img height="" src="https://img.shields.io/static/v1?label=&message=GitHub&color=181717&logo=GitHub&logoColor=f2f2f2&labelColor=2F333A" alt="Github">](https://github.com/Y-Baker)
