using ECommerce.Data.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace ECommerce.Data.DbContext;

public class EComDbContext : IdentityDbContext<ApplicationUser>
{
    public EComDbContext(DbContextOptions<EComDbContext> options) : base(options)
    {

    }
    public DbSet<Cart> Cart { get; set; }
    public DbSet<CartItem> CartItem { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Coupon> Coupon { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<OrderItem> OrderItem { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<ProductCategory> ProductCategory { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CartConfiguration());
        modelBuilder.ApplyConfiguration(new CartItemConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new CouponConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());


        base.OnModelCreating(modelBuilder);
    }
}
