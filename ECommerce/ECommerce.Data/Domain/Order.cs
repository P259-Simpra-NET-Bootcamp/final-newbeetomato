using ECommerce.Base.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Domain;

public class Order:BaseModel
{
    public int UserId { get; set; }
    public int? CardNo { get; set; }
    public virtual User user { get; set; }
    public virtual List<OrderItem> OrderItems { get; set; }
    public decimal? TotalAmount { get; set; }
    public decimal? UsedPoints { get; set; }
    public decimal? CouponPoints { get; set; }
    public decimal? TotalDiscount { get; set; }
    public decimal? GainedPoints { get; set; }
    public decimal? NetAmount { get; set; }
    public bool? IsCanceled { get; set; }
    public bool? IsMoneyDeliveredBack { get; set; }
    public bool? IsDelivered { get; set; }
    public virtual List<Coupon> Coupons { get; set; }
}
public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(x => x.Id).IsRequired(true).UseIdentityColumn();
        builder.Property(x => x.UserId).IsRequired(true);
        builder.Property(x => x.CreatedAt).IsRequired(false);
        builder.Property(x => x.CreatedBy).IsRequired(false).HasMaxLength(30);
        builder.Property(x => x.UpdatedAt).IsRequired(false);
        builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(30);
        builder.Property(x => x.UsedPoints).IsRequired(false);
        builder.Property(x => x.TotalDiscount).IsRequired(false);
        builder.Property(x => x.CouponPoints).IsRequired(false);
        builder.Property(x => x.GainedPoints).IsRequired(false);
        builder.Property(x => x.IsCanceled).IsRequired(false);
        builder.Property(x => x.IsMoneyDeliveredBack).IsRequired(false);
        builder.Property(x => x.IsDelivered).IsRequired(false);


        builder.HasMany(x => x.OrderItems)
            .WithOne(x => x.Order)
            .HasForeignKey(x => x.OrderId)
            .IsRequired(false); 

        builder.HasMany(x => x.Coupons)
            .WithOne(x => x.Order)
            .HasForeignKey(x => x.OrderId)
            .IsRequired(false);
    }
}