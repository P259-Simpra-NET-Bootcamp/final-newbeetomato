using ECommerce.Base.Response;
using ECommerce.Operation.ProductSrvc;
using ECommerce.Schema.Category;
using ECommerce.Schema.Product;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;

namespace ECommerce.Service.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService productService;

        public ProductController(ProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("search")]
        public ActionResult<ApiResponse<IEnumerable<ProductResponse>>> GetProductsByName(string name)
        {
            try
            {
                var response = productService.GetProductsByName(name);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while getting products by name");
                return StatusCode(500, "An error occurred while getting products by name");
            }
        }

        [HttpGet("{productId}/categories")]
        public ActionResult<ApiResponse<IEnumerable<CategoryResponse>>> GetCategoriesForProduct(int productId)
        {
            try
            {
                var response = productService.GetCategoriesForProduct(productId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while getting categories for product");
                return StatusCode(500, "An error occurred while getting categories for product");
            }
        }

        [HttpGet("count")]
        public ActionResult<ApiResponse<int>> GetProductCount()
        {
            try
            {
                var response = productService.GetProductCount();
                return Ok(response);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while getting product count");
                return StatusCode(500, "An error occurred while getting product count");
            }
        }
        [HttpPost]
        public ActionResult<ApiResponse<ProductResponse>> CreateProduct(ProductRequest request)
        {
            try
            {
                
                var response = productService.Insert(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while creating product");
                return StatusCode(500, "An error occurred while creating product");
            }
        }

        [HttpPut("{productId}")]
        public ActionResult<ApiResponse<ProductResponse>> UpdateProduct(int productId, ProductRequest request)
        {
            try
            {
                var response = productService.Update(productId, request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while updating product");
                return StatusCode(500, "An error occurred while updating product");
            }
        }

        [HttpDelete("{productId}")]
        public ActionResult<ApiResponse> DeleteProduct(int productId)
        {
            try
            {
                productService.Delete(productId);
                return Ok(new ApiResponse());
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while deleting product");
                return StatusCode(500, "An error occurred while deleting product");
            }
        }
    }
}
