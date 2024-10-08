﻿namespace Shared;
public class StudentsAffairsDbContext : DbContext
{
    public StudentsAffairsDbContext(DbContextOptions<StudentsAffairsDbContext> options) : base(options) { }

    public DbSet<Student> Students { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Course> Courses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Assembly currentAssembly = Assembly.GetExecutingAssembly();
        HashSet<Assembly> referencedAssemblies = currentAssembly.GetReferencedAssemblies()
                                                                .Select(x => Assembly.Load(x))
                                                                .ToHashSet() ?? new();
        referencedAssemblies.Add(currentAssembly);

        modelBuilder.Ignore<BaseEntity>();
        foreach (Assembly assembly in referencedAssemblies)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }

        base.OnModelCreating(modelBuilder);
    }
}
