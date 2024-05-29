

namespace E_Commerce.DAL.ModelTyepConfiguration;

public class ShipmentAddressTypeConfiguration : IEntityTypeConfiguration<ShipmentAddress>
{
	public void Configure(EntityTypeBuilder<ShipmentAddress> modelBuilder)
	{
		modelBuilder.Property(SA => SA.FirstName).HasMaxLength(50);
		modelBuilder.Property(SA => SA.LastName).HasMaxLength(50);
		modelBuilder.Property(SA => SA.City).HasMaxLength(50);
		modelBuilder.Property(SA => SA.Street).HasMaxLength(80);
		modelBuilder.Property(SA => SA.State).HasMaxLength(80);
		modelBuilder.Property(SA => SA.Zipcode).HasMaxLength(20);

		//> add another configuration of model here
	
	}
}
