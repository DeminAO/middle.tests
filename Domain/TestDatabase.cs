using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace review.test.Domain;

public class TestDatabase(DbContextOptions<TestDatabase> options) : DbContext(options)
{
	public virtual DbSet<Entity> Entities { get; set; }
	public virtual DbSet<EntityRel> EntityRels { get; set; }
	public virtual DbSet<HierarchicalEntity> HierarchicalEntities { get; set; }
}
