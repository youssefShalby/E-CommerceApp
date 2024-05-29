


namespace E_Commerce.DAL.ModelTyepConfiguration;

public class BrandTypeConfiguration : IEntityTypeConfiguration<Brand>
{
	public void Configure(EntityTypeBuilder<Brand> modelBuilder)
	{
		modelBuilder.HasKey(B => B.Id);
		modelBuilder.Property(B => B.Name).IsRequired().HasMaxLength(100);

		//> add seed data
		modelBuilder.HasData(JsonHelper.GetSeedData<Brand>(@"../E-Commerce.DAL/SeedData/brands.json"));

		//> configure the relations
		modelBuilder.HasMany(B => B.Products).WithOne(P => P.Brand).HasForeignKey(P => P.BrandId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}
