namespace UserOperationsLog.Domain.Entities;

public class BillPosition
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Count { get; set; }
    public decimal Price { get; set; }

    public Guid BillId { get; set; }
    public virtual Bill Bill { get; set; }

    public Guid PriceListItemId { get; set; }
    public virtual PriceListItem PriceListItem { get; set; }
}
