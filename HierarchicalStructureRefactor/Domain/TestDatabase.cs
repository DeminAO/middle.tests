using HierarchicalStructureRefactor.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HierarchicalStructureRefactor.Domain;

public class TestDatabase(DbContextOptions<TestDatabase> options) : DbContext(options)
{
    public virtual DbSet<HierarchicalEntity> HierarchicalEntities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new HierarchicalEntityConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}

public class HierarchicalEntityConfiguration : IEntityTypeConfiguration<HierarchicalEntity>
{
    public void Configure(EntityTypeBuilder<HierarchicalEntity> builder)
    {
        builder.HasMany(x => x.Children).WithOne(x => x.Parent);
    }
}