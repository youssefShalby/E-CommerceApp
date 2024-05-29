

namespace E_Commerce.DAL.ModelTyepConfiguration;

public class DeliveryMethodTypeConfiguration : IEntityTypeConfiguration<DeliveryMethod>
{
	public void Configure(EntityTypeBuilder<DeliveryMethod> modelBuilder)
	{
		modelBuilder.Property(D => D.Price).HasColumnType("decimal(18,2)");

		//> add seeding data
		modelBuilder.HasData(JsonHelper.GetSeedData<DeliveryMethod>(@"../E-Commerce.DAL/SeedData/delivery.json"));
	}
}
