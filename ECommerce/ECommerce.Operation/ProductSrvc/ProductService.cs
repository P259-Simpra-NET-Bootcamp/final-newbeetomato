using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Domain;
using ECommerce.Data.UnitOfWork;
using ECommerce.Operation.BaseSrvc;
using ECommerce.Schema.Category;
using ECommerce.Schema.Product;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Operation.ProductSrvc
{
    public class ProductService : BaseService<Product, ProductRequest, ProductResponse>, IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public ApiResponse<IEnumerable<ProductResponse>> GetProductsByName(string name)
        {
            try
            {
                var products = unitOfWork.ProductRepository().FindByName(name);
                var mappedProducts = mapper.Map<IEnumerable<ProductResponse>>(products);
                return new ApiResponse<IEnumerable<ProductResponse>>(mappedProducts);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GetProductsByName Exception");
                return new ApiResponse<IEnumerable<ProductResponse>>(ex.Message);
            }
        }

        public ApiResponse<IEnumerable<CategoryResponse>> GetCategoriesForProduct(int productId)
        {
            try
            {
                var categories = unitOfWork.ProductRepository().GetCategoriesForProduct(productId);
                var mappedCategories = mapper.Map< IEnumerable<CategoryResponse>>(categories);
                return new ApiResponse<IEnumerable<CategoryResponse>>(mappedCategories);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GetCategoriesForProduct Exception");
                return new ApiResponse<IEnumerable<CategoryResponse>>(ex.Message);
            }
        }

        public ApiResponse<int> GetProductCount()
        {
            try
            {
                var count = unitOfWork.ProductRepository().GetAllCount();
                return new ApiResponse<int>(count);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GetProductCount Exception");
                return new ApiResponse<int>(ex.Message);
            }
        }
    }
}