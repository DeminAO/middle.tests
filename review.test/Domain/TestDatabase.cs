using Microsoft.EntityFrameworkCore;

namespace review.test.Domain;

public class TestDatabase(DbContextOptions<TestDatabase> options) : DbContext(options)
{
	public virtual DbSet<Entity> Entities { get; set; }
	public virtual DbSet<EntityRel> EntityRels { get; set; }
}

public class Entity
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public ICollection<EntityRel> EntityRels { get; set; } = [];
}
public class EntityRel
{
	public Guid Id { get; set; }
	public string Name { get; set; }
}