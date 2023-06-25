using ECommerce.Data.Context;

using ECommerce.Data.Domain;
using ECommerce.Data.Repository.Base;
using System.Xml.Linq;

namespace ECommerce.Data.Repository.Category;

public class CategoryRepository : GenericRepository<Domain.Category>, ICategoryRepository
{

    public CategoryRepository(EComDbContext context) : base(context)
    {

    }
    public IEnumerable<Domain.Category> FindByName(string name)
    {
        var list = dbContext.Set<Domain.Category>().Where(c => c.Name.Contains(name)).ToList();
        return list;
    }
    public IEnumerable<Domain.Category> FindByDisplayOrder(int DisplayOrder)
    {
        var list = dbContext.Set<Domain.Category>().Where(c => c.DisplayOrder==DisplayOrder).ToList();
        return list;
    }
    public int GetAllCount()
    {
        return dbContext.Set<Domain.Category>().Count();
    }
}
