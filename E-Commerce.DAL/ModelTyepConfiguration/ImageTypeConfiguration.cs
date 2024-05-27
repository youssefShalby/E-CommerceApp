
namespace E_Commerce.DAL.ModelTyepConfiguration;

public class ImageTypeConfiguration : IEntityTypeConfiguration<Image>
{
	public void Configure(EntityTypeBuilder<Image> modelBuilder)
	{
		modelBuilder.HasKey(I => I.Id);
		//modelBuilder.Property(I => I.Url).IsRequired();


	}
}
