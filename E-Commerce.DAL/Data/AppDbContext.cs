﻿
namespace E_Commerce.DAL.Data;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
    {
        //> pass the options to the base class(IdentityDbContext<>)
    }


    //> initial database models
    public DbSet<Address> Addresses => Set<Address>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Image> ProductImages => Set<Image>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<DeliveryMethod> DeliveryMethods => Set<DeliveryMethod>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		base.OnConfiguring(optionsBuilder);

        optionsBuilder.EnableSensitiveDataLogging();
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

        //> call external configurations
        new AppUserTypeConfiguration().Configure(modelBuilder.Entity<ApplicationUser>());
        new AddressTypeConfiguration().Configure(modelBuilder.Entity<Address>());
        new ProductTypeConfiguration().Configure(modelBuilder.Entity<Product>());
        new ImageTypeConfiguration().Configure(modelBuilder.Entity<Image>());
        new CategoryTypeConfiguration().Configure(modelBuilder.Entity<Category>());
        new BrandTypeConfiguration().Configure(modelBuilder.Entity<Brand>());
        new OrderItemTypeConfiguration().Configure(modelBuilder.Entity<OrderItem>());
        new OrderTypeConfiguration().Configure(modelBuilder.Entity<Order>());
        new DeliveryMethodTypeConfiguration().Configure(modelBuilder.Entity<DeliveryMethod>());


	}
}
