

namespace E_Commerce.DAL.ModelTyepConfiguration;

public class OrderTypeConfiguration : IEntityTypeConfiguration<Order>
{
	public void Configure(EntityTypeBuilder<Order> modelBuilder)
	{
		//> make ShipmentAddress class belongs to Order class type
		modelBuilder.OwnsOne(O => O.ShipToAddress, O =>
		{
			O.WithOwner();
		});

		modelBuilder.Property(O => O.Status)
			.HasConversion(O => O.ToString(), O => (OrderStatus)Enum.Parse(typeof(OrderStatus), O));

		//> relations
		modelBuilder.HasMany(O => O.OrderItems).WithOne().OnDelete(DeleteBehavior.Cascade);

		modelBuilder.HasOne(O => O.DeliveryMethod).WithMany(DM => DM.Orders).HasForeignKey(O => O.DeliveryMethodId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}
