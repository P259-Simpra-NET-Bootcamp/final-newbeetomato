using ECommerce.Base.Response;
using ECommerce.Schema.Category;
using ECommerce.Schema.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Operation.ProductSrvc
{
    public interface IProductService
    {

        ApiResponse<IEnumerable<ProductResponse>> GetProductsByName(string name);
        ApiResponse<IEnumerable<CategoryResponse>> GetCategoriesForProduct(int productId);
        ApiResponse<int> GetProductCount();

    }
}
