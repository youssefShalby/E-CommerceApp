

namespace E_Commerce.DAL.ModelTyepConfiguration;

public class OrderItemTypeConfiguration : IEntityTypeConfiguration<OrderItem>
{
	public void Configure(EntityTypeBuilder<OrderItem> modelBuilder)
	{
		modelBuilder.OwnsOne(OI => OI.ItemOrdered, OI => { OI.WithOwner(); });
		modelBuilder.Property(OI => OI.Price).HasColumnType("decimal(18,2)");

	}
}
