using ECommerce.Base.Model;
using ECommerce.Data.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Data.Domain
{
    [Table("User", Schema = "dbo")]
    public class User : BaseModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public decimal? WalletBalance { get; set; }
        public decimal? PointBalance { get; set; }
        public int? CartId { get; set; }
        public virtual Cart cart { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}

public class ApplicationUserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Id).IsRequired(true).UseIdentityColumn();
        builder.Property(x => x.CreatedAt).IsRequired(false);
        builder.Property(x => x.CreatedBy).IsRequired(false).HasMaxLength(30);
        builder.Property(x => x.UpdatedAt).IsRequired(false);
        builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(30);

        builder.Property(x => x.UserName).IsRequired(true).HasMaxLength(30);
        builder.Property(x => x.Password).IsRequired(true).HasMaxLength(30);
        builder.Property(x => x.Email).IsRequired(true).HasMaxLength(30);
        builder.Property(x => x.Address).IsRequired(true).HasMaxLength(500);
        builder.Property(x => x.FirstName).IsRequired(true).HasMaxLength(30);
        builder.Property(x => x.LastName).IsRequired(true).HasMaxLength(30);
        builder.Property(x => x.IsAdmin).IsRequired(true);

        builder.HasIndex(x => x.UserName).IsUnique(true);

        builder.HasOne(u => u.cart) // Configure the one-to-one relationship
            .WithOne(c => c.user)
            .HasForeignKey<Cart>(c => c.UserId)
            .IsRequired(false);

        builder.HasMany(x => x.Orders)
            .WithOne(x => x.user)
            .HasForeignKey(x => x.UserId)
            .IsRequired(true);
    }
}