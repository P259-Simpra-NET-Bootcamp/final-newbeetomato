
using ECommerce.Base.Model;
using ECommerce.Schema.Product;

namespace ECommerce.Schema.Category;

public class CategoryResponse:BaseResponse
{
    public string Name { get; set; }
    public int DisplayOrder { get; set; }
    public List<ProductResponse> Products { get; set; }
}
