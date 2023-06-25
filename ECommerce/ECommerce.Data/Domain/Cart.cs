using ECommerce.Base.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Domain;

public class Cart : BaseModel
{
    public int UserId { get; set; }
    public virtual User user { get; set; }
    public virtual List<CartItem> CartItems { get; set; }
    public decimal? CartTotalAmount { get; set; }
    public decimal? UsedPoints { get; set; }
    public decimal? CouponPoints { get; set; }
    public decimal? TotalDiscount { get; set; }
    public decimal? NetAmount { get; set; }
    public virtual List<Coupon> Coupons { get; set; }

}
public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.Property(x => x.Id).IsRequired(true).UseIdentityColumn();
        builder.Property(x => x.CreatedAt).IsRequired(false);
        builder.Property(x => x.CreatedBy).IsRequired(false).HasMaxLength(30);
        builder.Property(x => x.UpdatedAt).IsRequired(false);
        builder.Property(x => x.CartTotalAmount).IsRequired(false);
        builder.Property(x => x.TotalDiscount).IsRequired(false);
        builder.Property(x => x.NetAmount).IsRequired(false);

        builder.Property(x => x.UsedPoints).IsRequired(false);
        builder.Property(x => x.TotalDiscount).IsRequired(false);
        builder.Property(x => x.CouponPoints).IsRequired(false);
       

        builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(30);
        builder.Property(x => x.UserId).IsRequired(true);

        builder.HasMany(x => x.Coupons)
            .WithOne(x => x.Cart)
            .HasForeignKey(x => x.CartId)
            .IsRequired(false);
    }
}
