namespace UserDomain;

public abstract class UserConfiguration<TEntity> : BaseConfiguration<TEntity>
    where TEntity : User
{
    public override void Configure(EntityTypeBuilder<TEntity> modelBuilder)
    {
        base.Configure(modelBuilder);

        modelBuilder.HasIndex(e => e.Email).IsUnique();


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