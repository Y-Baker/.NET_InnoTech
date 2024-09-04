namespace StudentAffairs;

public class StudentsConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> modelBuilder)
    {
        modelBuilder.ToTable("Students", t =>
        {
            t.HasCheckConstraint("CK_Student_GPA", "`GPA` >= 0 AND `GPA` <= 4");
        });

        modelBuilder.HasKey(e => e.Id);
        modelBuilder.HasIndex(e => e.Email).IsUnique();
        modelBuilder.HasIndex(e => e.Name);

        modelBuilder.Property(e => e.Id)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Property(e => e.Mobile)
            .HasMaxLength(20);

        modelBuilder.Property(e => e.Age)
            .HasMaxLength(2)
            .HasDefaultValue(18);

        modelBuilder.Property(e => e.Email)
            .IsRequired()
            .HasMaxLength(150);

        modelBuilder.Property(e => e.GPA)
            .HasPrecision(3, 2);
    }
}