namespace StudentAffairs;

public class DoctorsConfiguration : UserConfiguration<Doctor>
{
    public override void Configure(EntityTypeBuilder<Doctor> modelBuilder)
    {
        base.Configure(modelBuilder);

        modelBuilder.ToTable("Doctors");

        modelBuilder.Property(e => e.Major)
                    .IsRequired()
                    .HasMaxLength (150);
    }
}
