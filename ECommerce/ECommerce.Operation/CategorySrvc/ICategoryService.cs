using ECommerce.Base.Response;
using ECommerce.Data.Domain;
using ECommerce.Operation.BaseSrvc;
using ECommerce.Schema.Category;
using ECommerce.Schema.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Operation.CategorySrvc
{
    public interface ICategoryService : IBaseService<Category, CategoryRequest, CategoryResponse>
    {
        ApiResponse<IEnumerable<ProductResponse>> GetProductsByCategory(int categoryId);
        ApiResponse<IEnumerable<int>> GetProductIdsByCategory(int categoryId);
    }
}
