using ECommerce.Data.Repository.Order;
using ECommerce.Data.Repository.Product;

namespace ECommerce.Service.RestExtension
{
    public static class RepositoryExtension
    {
        public static void AddRepositoryExtension(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
        }
    }
}
