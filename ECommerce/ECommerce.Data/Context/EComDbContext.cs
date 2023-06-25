using ECommerce.Data.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Context;
public class EComDbContext : DbContext
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
    public DbSet<User> User { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CartConfiguration());
        modelBuilder.ApplyConfiguration(new CartItemConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new CouponConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
        modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());


        base.OnModelCreating(modelBuilder);
    }
}
