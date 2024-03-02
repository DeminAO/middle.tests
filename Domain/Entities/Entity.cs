namespace Domain.Entities;

public class Entity
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public ICollection<EntityRel> EntityRels { get; set; } = [];
}
