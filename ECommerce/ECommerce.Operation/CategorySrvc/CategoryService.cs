using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Domain;
using ECommerce.Data.Repository.Category;
using ECommerce.Data.UnitOfWork;
using ECommerce.Operation.BaseSrvc;
using ECommerce.Schema.Category;
using ECommerce.Schema.Product;
using Serilog;


namespace ECommerce.Operation.CategorySrvc
{
    public class CategoryService : BaseService<Category, CategoryRequest, CategoryResponse>, ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public ApiResponse<CategoryResponse> GetCategories()
        {
            try
            {
                var entity = unitOfWork.CategoryRepository().GetAll();
                var mapped =mapper.Map<List<Category>,CategoryResponse>(entity);
                return new ApiResponse<CategoryResponse>(mapped);
            }
            catch (Exception ex)
            {

                Log.Error(ex, "GetCategories Exception");
                return new ApiResponse<CategoryResponse>(ex.Message);
            }
        }
        public ApiResponse<CategoryResponse> FindByName(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name)) { return new ApiResponse<CategoryResponse>("String NullorEmpty"); }

                var entities = unitOfWork.CategoryRepository().FindByName(name);
                var mapped = mapper.Map<CategoryResponse>(entities);
                return new ApiResponse<CategoryResponse>(mapped);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "FindByName Exception");
                return new ApiResponse<CategoryResponse>(ex.Message);
            }
        }
        public ApiResponse<int> GetAllCount()
        {
            int count = unitOfWork.CategoryRepository().GetAllCount();
            return new ApiResponse<int>(count);
        }

        public ApiResponse<IEnumerable<ProductResponse>> GetProductsByCategory(int categoryId)
        {
            try
            {
                var products = unitOfWork.Repository<Product>().WhereWithInclude(p => p.CategoryId == categoryId, "Category");

                var mappedProducts = mapper.Map<IEnumerable<Product>, IEnumerable<ProductResponse>>(products);

                return new ApiResponse<IEnumerable<ProductResponse>>(mappedProducts);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GetProductsByCategory Exception");
                return new ApiResponse<IEnumerable<ProductResponse>>(ex.Message);
            }
        }

        public ApiResponse<IEnumerable<int>> GetProductIdsByCategory(int categoryId)
        {
            try
            {
                var productIds = unitOfWork.Repository<ProductCategory>().Where(pc => pc.CategoryId == categoryId).Select(pc => pc.ProductId).ToList();


                return new ApiResponse<IEnumerable<int>>(productIds);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GetProductIdsByCategory Exception");
                return new ApiResponse<IEnumerable<int>>(ex.Message);
            }
        }
    }
}
