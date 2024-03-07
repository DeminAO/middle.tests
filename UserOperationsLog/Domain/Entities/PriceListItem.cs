namespace UserOperationsLog.Domain.Entities;

public class PriceListItem
{
    public Guid Id { get; set; }
    public decimal Price { get; set; }
    public string Name { get; set; }
    public virtual ICollection<BillPosition> BillPositions { get; set; } = [];
}