using ECommerce.Data.DbContext;
using ECommerce.Data.Domain;
using ECommerce.Data.Repository.Base;

namespace ECommerce.Data.Repository.Category;

public class CategoryRepository : GenericRepository<Domain.Category>, ICategoryRepository
{

    public CategoryRepository(EComDbContext context) : base(context)
    {

    }
    public IEnumerable<Domain.Category> FindByName(string name)
    {
        //harfleri küçültçenmi boşlukları silcenmi
        var list = dbContext.Set<Domain.Category>().Where(c => c.Name.Contains(name)).ToList();
        return list;
    }
   
    public int GetAllCount()
    {
        return dbContext.Set<Domain.Category>().Count();
    }
}
