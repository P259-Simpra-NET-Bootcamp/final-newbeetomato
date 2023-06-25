using ECommerce.Base.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Domain;

[Table("Product", Schema = "dbo")]

public class Product:BaseModel
{
    public int? CategoryId { get; set; }
    public virtual Category Category { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public string Tag { get; set; }
    public string Details { get; set; }
    public decimal UnitPrice { get; set; }
    public virtual List<ProductCategory> ProductCategories { get; set; }

}
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.Id).IsRequired(true).UseIdentityColumn();
        builder.Property(x => x.CreatedAt).IsRequired(false);
        builder.Property(x => x.CreatedBy).IsRequired(false).HasMaxLength(30);
        builder.Property(x => x.UpdatedAt).IsRequired(false);
        builder.Property(x => x.UpdatedBy).IsRequired(false).HasMaxLength(30);

        builder.Property(x => x.Name).IsRequired(true).HasMaxLength(30);
        builder.Property(x => x.Url).IsRequired(true).HasMaxLength(30);
        builder.Property(x => x.Tag).IsRequired(true).HasMaxLength(100);
        builder.Property(x => x.Details).IsRequired(true).HasMaxLength(500);
        builder.Property(x => x.CategoryId).IsRequired(false);
        builder.Property(x => x.UnitPrice)
       .IsRequired(true)
       .HasPrecision(10, 2);

        builder.HasIndex(x => x.Name).IsUnique(true);

        builder.HasMany(p => p.ProductCategories)
                .WithOne(pc => pc.Product)
                .HasForeignKey(pc => pc.ProductId)
                .IsRequired(false).OnDelete(DeleteBehavior.Restrict);


    }
}