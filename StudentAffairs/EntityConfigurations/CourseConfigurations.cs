namespace StudentAffairs;

public class CourseConfigurations : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> modelBuilder)
    {
        modelBuilder.ToTable("Courses", t => 
            t.HasCheckConstraint("CK_Creadit_Hours", "`CreaditHours` >= 0 AND `CreaditHours` <= 4")
        );

        modelBuilder.HasKey(e => e.Id);
        modelBuilder.HasIndex(e => e.Name);
        modelBuilder.HasIndex(e => e.InstructorId);

        modelBuilder.Property(e => e.Id)
            .IsRequired();

        modelBuilder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(150);

        modelBuilder.Property(e => e.CreaditHours)
            .IsRequired();

        modelBuilder.Property(e => e.InstructorId)
            .IsRequired();

        modelBuilder.Property(e => e.PreRequest)
            .HasDefaultValue(null);

        modelBuilder.Property(e => e.NumberOfStudents)
            .HasDefaultValue(0);

        modelBuilder.HasOne<Doctor>()
            .WithMany()
            .HasForeignKey(e => e.InstructorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.HasOne<Course>()
            .WithMany()
            .HasForeignKey(e => e.PreRequest)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
