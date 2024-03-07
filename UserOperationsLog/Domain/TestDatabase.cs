using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using UserOperationsLog.Domain.Entities;

namespace UserOperationsLog.Domain;

public class TestDatabase(DbContextOptions<TestDatabase> options) : DbContext(options)
{
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Bill> Bills { get; set; }
    public virtual DbSet<BillPosition> BillPositions { get; set; }
    public virtual DbSet<PriceListItem> PriceList { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BillPositionConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}

public class BillPositionConfiguration : IEntityTypeConfiguration<BillPosition>
{
    public void Configure(EntityTypeBuilder<BillPosition> builder)
    {
        builder.HasOne(x => x.Bill).WithMany(x => x.Positions);
        builder.HasOne(x => x.PriceListItem).WithMany(x => x.BillPositions);
    }
}