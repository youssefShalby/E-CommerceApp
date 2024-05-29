
namespace E_Commerce.DAL.ModelTyepConfiguration;

public class CategoryTypeConfiguration : IEntityTypeConfiguration<Category>
{
	public void Configure(EntityTypeBuilder<Category> modelBuilder)
	{
		modelBuilder.HasKey(C => C.Id);
		modelBuilder.Property(C => C.Name).IsRequired().HasMaxLength(100);

		modelBuilder.HasData(JsonHelper.GetSeedData<Category>(@"../E-Commerce.DAL/SeedData/types.json"));

		//> configure the relations
		modelBuilder.HasMany(B => B.Products).WithOne(P => P.Category).HasForeignKey(P => P.CategoryId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}
