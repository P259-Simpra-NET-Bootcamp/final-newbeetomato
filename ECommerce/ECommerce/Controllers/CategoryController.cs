using ECommerce.Base.Response;
using ECommerce.Operation.CategorySrvc;
using ECommerce.Schema.Category;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.Service.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public  ApiResponse<CategoryResponse> GetCategories()
        {
            return categoryService.GetCategories();
        }

        [HttpGet("{id}")]
        public  ApiResponse<CategoryResponse> GetCategoryById(int id)
        {
            var response =  categoryService.GetById(id);
            return response;
        }

        [HttpPost]
        public  ApiResponse CreateCategory([FromBody] CategoryRequest request)
        {
            var response =  categoryService.Insert(request);
            return response;
        }

        [HttpPut("{id}")]
        public  ApiResponse UpdateCategory(int id, [FromBody] CategoryRequest request)
        {
            var response =  categoryService.Update(id, request);
            return response;
        }

        [HttpDelete("{id}")]
        public  ApiResponse DeleteCategory(int id)
        {
            var response =  categoryService.Delete(id);
            return response;
        }

        [HttpGet("search")]
        public ApiResponse<CategoryResponse> SearchCategoryByName(string name)
        {
            var response = categoryService.FindByName(name);
            return response;
        }
    }
}
