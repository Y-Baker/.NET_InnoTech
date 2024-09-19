namespace CourseDomain;

public class CourseConfigurations : BaseConfiguration<Course>
{
    public override void Configure(EntityTypeBuilder<Course> modelBuilder)
    {
        base.Configure(modelBuilder);

        modelBuilder.ToTable("Courses", t =>
            t.HasCheckConstraint("CK_Creadit_Hours", "`CreaditHours` >= 0 AND `CreaditHours` <= 4")
        );

        modelBuilder.HasIndex(e => e.InstructorId);


        modelBuilder.Property(e => e.CreaditHours)
                    .IsRequired();

        modelBuilder.Property(e => e.InstructorId)
                    .IsRequired();

        modelBuilder.Property(e => e.PreRequest)
                    .HasDefaultValue(null);

        modelBuilder.Property(e => e.NumberOfStudents)
                    .HasDefaultValue(0);

        modelBuilder.HasOne("Doctor")
                    .WithMany()
                    .HasForeignKey("InstructorId")
                    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.HasOne<Course>()
                    .WithMany()
                    .HasForeignKey(e => e.PreRequest)
                    .OnDelete(DeleteBehavior.SetNull);
    }
}
