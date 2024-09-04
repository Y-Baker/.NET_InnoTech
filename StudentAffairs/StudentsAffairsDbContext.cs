using System.Collections.Generic;
using System.Reflection.Emit;

namespace StudentAffairs;

public class StudentsAffairsDbContext : DbContext
{
    public StudentsAffairsDbContext(DbContextOptions<StudentsAffairsDbContext> options) : base(options) { }

    public DbSet<Student> Students { get; set; }
    public DbSet<Doctor> Doctors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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

        base.OnModelCreating(modelBuilder);
    }
}
