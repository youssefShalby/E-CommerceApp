


namespace E_Commerce.DAL.ModelTyepConfiguration;

public class ProductTypeConfiguration : IEntityTypeConfiguration<Product>
{
	public void Configure(EntityTypeBuilder<Product> modelBuilder)
	{
		//> configure the properties
		modelBuilder.HasKey(P => P.Id);
		modelBuilder.Property(P => P.Name).IsRequired().HasMaxLength(100);
		modelBuilder.Property(P => P.Description).IsRequired().HasMaxLength(250);
		modelBuilder.Property(P => P.OriginalPrice).IsRequired().HasColumnType("decimal(18,2)");
		modelBuilder.Property(P => P.OfferPrice).IsRequired().HasColumnType("decimal(18,2)");

		//> make the foregin keys nullable
		//-- modelBuilder.Property(P => P.BrandId).IsRequired(false);
		//-- modelBuilder.Property(P => P.CategoryId).IsRequired(false);

		modelBuilder
			.HasMany(P => P.Images)
			.WithOne()
			.HasForeignKey(I => I.ProductId)
			.OnDelete(DeleteBehavior.Cascade);

		//> Add Seeding data
		modelBuilder.HasData(JsonHelper.GetSeedData<Product>("../E-Commerce.DAL/SeedData/products.json"));

	}
}
