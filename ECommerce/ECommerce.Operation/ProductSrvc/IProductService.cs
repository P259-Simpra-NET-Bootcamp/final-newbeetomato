using ECommerce.Base.Response;
using ECommerce.Operation.BaseSrvc;
using ECommerce.Schema.Category;
using ECommerce.Schema.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Operation.ProductSrvc
{
    public interface IProductService:IBaseService<Data.Domain.Product,ProductRequest,ProductResponse>
    {

        ApiResponse<IEnumerable<ProductResponse>> GetProductsByName(string name);
        ApiResponse<IEnumerable<CategoryResponse>> GetCategoriesForProduct(int productId);
        ApiResponse<int> GetProductCount();

    }
}
