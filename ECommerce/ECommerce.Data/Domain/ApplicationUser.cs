using ECommerce.Data.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Data.Domain
{
    [Table("ApplicationUser", Schema = "dbo")]
    public class ApplicationUser : IdentityUser<int>
    {
        public long NationalIdNumber { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string Address { get; set; }
        public int Status { get; set; }
        public decimal WalletBalance { get; set; }
        public decimal? PointBalance { get; set; }
        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(x => x.CreatedAt).IsRequired(false);
        builder.Property(x => x.CreatedBy).IsRequired(false).HasMaxLength(30);
        builder.Property(x => x.UpdatedAt).IsRequired(false);
        builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(30);

        builder.Property(x => x.UserName).IsRequired(true).HasMaxLength(30);
        builder.Property(x => x.Email).IsRequired(true).HasMaxLength(30);
        builder.Property(x => x.Address).IsRequired(true).HasMaxLength(500);
        builder.Property(x => x.FirstName).IsRequired(true).HasMaxLength(30);
        builder.Property(x => x.LastName).IsRequired(true).HasMaxLength(30);
        builder.Property(x => x.Role).IsRequired(true).HasMaxLength(10);
        builder.Property(x => x.Status).IsRequired(true);

        builder.HasIndex(x => x.UserName).IsUnique(true);

        builder.HasMany(x => x.Orders)
            .WithOne(x => x.ApplicationUser)
            .HasForeignKey(x => x.UserId)
            .IsRequired(true);
    }
}