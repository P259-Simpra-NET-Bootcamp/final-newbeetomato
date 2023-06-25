using ECommerce.Data.Context;
using ECommerce.Data.Repository.Base;
using ECommerce.Data.Repository.Category;

namespace ECommerce.Data.Repository.Product;

public class ProductRepository: GenericRepository<Domain.Product>, IProductRepository
{
    public ProductRepository(EComDbContext context) : base(context) { }
    public IEnumerable<Domain.Product> FindByName(string name)
    {
        var list = dbContext.Set<Domain.Product>().Where(c => c.Name.Contains(name)).ToList();
        return list;
    }
    public IEnumerable<Domain.Category> GetCategoriesForProduct(int productId)
    {
        return dbContext.Set<Domain.ProductCategory>()
            .Where(pc => pc.ProductId == productId)
            .Select(pc => pc.Category)
            .ToList();
    }
    public int GetAllCount()
    {
        return dbContext.Set<Domain.Product>().Count();
    }
}
