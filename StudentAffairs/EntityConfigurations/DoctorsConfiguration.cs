namespace StudentAffairs;

public class DoctorsConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> modelBuilder)
    {
        modelBuilder.ToTable("Doctors");

        modelBuilder.HasKey(e => e.Id);
        modelBuilder.HasIndex(e => e.Email).IsUnique();
        modelBuilder.HasIndex(e => e.Name);

        modelBuilder.Property(e => e.Id)
            .IsRequired()
            .HasMaxLength(5);

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
    }
}
