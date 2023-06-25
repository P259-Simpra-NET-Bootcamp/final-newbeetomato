using ECommerce.Base.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Data.Domain;

[Table("Coupon", Schema = "dbo")]

public class Coupon:BaseModel 
{
    public int? OrderId { get; set; }
    public virtual Order Order { get; set; }
    public int? CartId { get; set; } 
    public virtual Cart Cart { get; set; }
    public string Code { get; set; }
    public bool DiscountAmount100 { get; set; } 
    public bool DiscountAmount50 { get; set; } 
    public bool DiscountAmount20 { get; set; } 
    public bool DiscountAmount10 { get; set; } 
    public DateTime ExpirationDate { get; set; }
    public bool IsActive { get; set; }
    public bool IsUsed { get; set; }
    public DateTime CreatedDate { get; set; }
}
public class CouponConfiguration : IEntityTypeConfiguration<Coupon>
{
    public void Configure(EntityTypeBuilder<Coupon> builder)
    {
        builder.Property(x => x.Id).IsRequired(true).UseIdentityColumn();
        builder.Property(x => x.CreatedAt).IsRequired(false);
        builder.Property(x => x.CreatedBy).IsRequired(false).HasMaxLength(30);
        builder.Property(x => x.UpdatedAt).IsRequired(false);
        builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(30);

        builder.Property(x => x.OrderId).IsRequired(false);
        builder.Property(x => x.CartId).IsRequired(false);
        builder.Property(x => x.Code).IsRequired(true).HasMaxLength(10).IsUnicode(true);
        builder.HasIndex(x => x.Code).IsUnique();
        builder.Property(x => x.DiscountAmount100).IsRequired(true);
        builder.Property(x => x.DiscountAmount50).IsRequired(true);
        builder.Property(x => x.DiscountAmount20).IsRequired(true);
        builder.Property(x => x.DiscountAmount10).IsRequired(true);
        builder.Property(x => x.IsActive).IsRequired(true);
        builder.Property(x => x.IsUsed).IsRequired(true);
        builder.Property(x => x.ExpirationDate).IsRequired(true);
        builder.Property(x => x.CreatedDate).IsRequired(true);
        builder.HasOne(x => x.Cart)
       .WithMany()
       .HasForeignKey(x => x.CartId)
       .OnDelete(DeleteBehavior.Restrict);
    }
}