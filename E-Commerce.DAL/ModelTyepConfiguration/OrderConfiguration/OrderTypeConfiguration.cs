

namespace E_Commerce.DAL.ModelTyepConfiguration;

public class OrderTypeConfiguration : IEntityTypeConfiguration<Order>
{
	public void Configure(EntityTypeBuilder<Order> modelBuilder)
	{

		modelBuilder.Property(O => O.Status)
			.HasConversion(O => O.ToString(), O => (OrderStatus)Enum.Parse(typeof(OrderStatus), O));

		//> relations
		modelBuilder.HasMany(O => O.OrderItems).WithOne().OnDelete(DeleteBehavior.Cascade);
		modelBuilder.HasOne(O => O.ShipToAddress).WithMany(SA => SA.Orders).HasForeignKey(O => O.ShipToAddressId)
			.OnDelete(DeleteBehavior.Cascade);

		modelBuilder.HasOne(O => O.DeliveryMethod).WithMany(DM => DM.Orders).HasForeignKey(O => O.DeliveryMethodId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}
