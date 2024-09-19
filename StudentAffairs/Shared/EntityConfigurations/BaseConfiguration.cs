namespace StudentAffairs;

public abstract class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> modelBuilder)
    {
        modelBuilder.HasKey(e => e.Id);

        modelBuilder.HasIndex(e => e.Name);

        modelBuilder.Property(e => e.Id)
                    .IsRequired()
                    .HasMaxLength(100);

        modelBuilder.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
    }
}
