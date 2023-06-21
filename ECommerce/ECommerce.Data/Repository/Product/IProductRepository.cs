using ECommerce.Data.Repository.Base;


namespace ECommerce.Data.Repository.Product;

public interface IProductRepository : IGenericRepository<Domain.Product>
{
    IEnumerable<Domain.Product> FindByName(string name);
    public IEnumerable<Domain.Category> GetCategoriesForProduct(int productId);

    int GetAllCount();
}