namespace Domain.Entities;

public class HierarchicalEntity
{
	public long Id { get; set; }
	public string Name { get; set; }
	public int? Value { get; set; }

	public long? ParentId { get; set; }
	public virtual HierarchicalEntity Parent { get; set; }
	public virtual ICollection<HierarchicalEntity> Children { get; set; } = [];
}