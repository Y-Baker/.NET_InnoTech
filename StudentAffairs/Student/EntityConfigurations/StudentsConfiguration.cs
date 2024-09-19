namespace StudentDomain;

public class StudentsConfiguration : UserConfiguration<Student>
{
    public override void Configure(EntityTypeBuilder<Student> modelBuilder)
    {
        base.Configure(modelBuilder);

        modelBuilder.ToTable("Students", t =>
            t.HasCheckConstraint("CK_Student_GPA", "`GPA` >= 0 AND `GPA` <= 4")
        );

        modelBuilder.Property(e => e.GPA)
                    .HasPrecision(3, 2);
    }
}