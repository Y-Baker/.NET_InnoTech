namespace StudentsAffairsWebAPI;

public class StudentsAffairsDbContext : DbContext
{
    public StudentsAffairsDbContext(DbContextOptions<StudentsAffairsDbContext> options)
        : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Applicant> Applicants { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Doctor> Doctors { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Student>().ToTable("Students");
        
        modelBuilder.Entity<Student>().HasKey(e => e.Id);
        modelBuilder.Entity<Student>().HasIndex(e => e.Name).IsUnique();
        
        modelBuilder.Entity<Student>().Property(e => e.Id).IsRequired();
        modelBuilder.Entity<Student>().Property(e => e.Id).HasMaxLength(5);
        modelBuilder.Entity<Student>().Property(e => e.Name).IsRequired();
        modelBuilder.Entity<Student>().Property(e => e.Name).HasMaxLength(50);
        modelBuilder.Entity<Student>().Property(e => e.Mobile).HasMaxLength(20);
        modelBuilder.Entity<Student>().Property(e => e.Age).HasMaxLength(2);
        modelBuilder.Entity<Student>().Property(e => e.Age).HasDefaultValue(18);




        modelBuilder.Entity<Applicant>().ToTable("Applicants");

        modelBuilder.Entity<Applicant>().HasKey(e => e.Id);
        modelBuilder.Entity<Applicant>().HasIndex(e => e.Name).IsUnique();

        modelBuilder.Entity<Applicant>().Property(e => e.Id).IsRequired();
        modelBuilder.Entity<Applicant>().Property(e => e.Id).HasMaxLength(5);
        modelBuilder.Entity<Applicant>().Property(e => e.Name).IsRequired();
        modelBuilder.Entity<Applicant>().Property(e => e.Name).HasMaxLength(50);
        modelBuilder.Entity<Applicant>().Property(e => e.Mobile).HasMaxLength(20);
        modelBuilder.Entity<Applicant>().Property(e => e.Age).HasMaxLength(2);
        modelBuilder.Entity<Applicant>().Property(e => e.Age).HasDefaultValue(18);




        modelBuilder.Entity<Teacher>().ToTable("Teachers");

        modelBuilder.Entity<Teacher>().HasKey(e => e.Id);
        modelBuilder.Entity<Teacher>().HasIndex(e => e.Name).IsUnique();

        modelBuilder.Entity<Teacher>().Property(e => e.Id).IsRequired();
        modelBuilder.Entity<Teacher>().Property(e => e.Id).HasMaxLength(5);
        modelBuilder.Entity<Teacher>().Property(e => e.Name).IsRequired();
        modelBuilder.Entity<Teacher>().Property(e => e.Name).HasMaxLength(50);
        modelBuilder.Entity<Teacher>().Property(e => e.Mobile).HasMaxLength(20);
        modelBuilder.Entity<Teacher>().Property(e => e.Age).HasMaxLength(2);
        modelBuilder.Entity<Teacher>().Property(e => e.Age).HasDefaultValue(18);




        modelBuilder.Entity<Doctor>().ToTable("Doctors");

        modelBuilder.Entity<Doctor>().HasKey(e => e.Id);
        modelBuilder.Entity<Doctor>().HasIndex(e => e.Name).IsUnique();

        modelBuilder.Entity<Doctor>().Property(e => e.Id).IsRequired();
        modelBuilder.Entity<Doctor>().Property(e => e.Id).HasMaxLength(5);
        modelBuilder.Entity<Doctor>().Property(e => e.Name).IsRequired();
        modelBuilder.Entity<Doctor>().Property(e => e.Name).HasMaxLength(50);
        modelBuilder.Entity<Doctor>().Property(e => e.Mobile).HasMaxLength(20);
        modelBuilder.Entity<Doctor>().Property(e => e.Age).HasMaxLength(2);
        modelBuilder.Entity<Doctor>().Property(e => e.Age).HasDefaultValue(18);
    }
}
