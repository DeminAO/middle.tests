namespace UserOperationsLog.Domain.Entities;

public class Bill
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid CreatedById { get; set; }

    public virtual ICollection<BillPosition> Positions { get; set; } = [];

    public DateTime? PaidAt { get; set; }
    public Guid? PaidById { get; set; }
}
