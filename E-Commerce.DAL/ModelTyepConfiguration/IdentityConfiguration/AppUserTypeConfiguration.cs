namespace E_Commerce.DAL.ModelTyepConfiguration;

internal class AppUserTypeConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
	public void Configure(EntityTypeBuilder<ApplicationUser> modelBuilder)
	{
		//> configure the properties
		modelBuilder.HasKey(U => U.Id);
		modelBuilder.Property(U => U.DisplayName).IsRequired().HasMaxLength(100);
		modelBuilder.Property(U => U.ConfirmationCode).IsRequired(false);
		modelBuilder.Property(U => U.ConfirmationCodeToken).IsRequired(false);


		//> configure the relations
		modelBuilder
			.HasOne(U => U.Address)
			.WithOne(A => A.AppUser)
			.HasForeignKey<Address>(A => A.AppUserId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}
