using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Base.Model;

namespace ECommerce.Data.Domain;

[Table("ProductCategory", Schema = "dbo")]

public class ProductCategory : BaseModel
{
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }


}
public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.HasKey(pc => new { pc.ProductId, pc.CategoryId });

        builder.HasOne(pc => pc.Product)
            .WithMany(p => p.ProductCategories)
            .HasForeignKey(pc => pc.ProductId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(pc => pc.Category)
            .WithMany(c => c.ProductCategories)
            .HasForeignKey(pc => pc.CategoryId).OnDelete(DeleteBehavior.Restrict);


    }
}