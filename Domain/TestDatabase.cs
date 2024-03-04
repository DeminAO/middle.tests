using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace review.test.Domain;

public class TestDatabase(DbContextOptions<TestDatabase> options) : DbContext(options)
{
	public virtual DbSet<HierarchicalEntity> HierarchicalEntities { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new EntitiesConfiguration());
		base.OnModelCreating(modelBuilder);
	}
}

public class EntitiesConfiguration : IEntityTypeConfiguration<HierarchicalEntity>
{
	public void Configure(EntityTypeBuilder<HierarchicalEntity> builder)
	{
		builder.HasMany(x => x.Children).WithOne(x => x.Parent);
	}
}