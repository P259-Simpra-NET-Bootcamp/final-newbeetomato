using ECommerce.Data.UnitOfWork;
using ECommerce.Operation.CartItemSrvc;
using ECommerce.Operation.CartSrvc;
using ECommerce.Operation.CategorySrvc;
using ECommerce.Operation.CouponSrvc;
using ECommerce.Operation.OrderItemSrvc;
using ECommerce.Operation.OrderSrvc;
using ECommerce.Operation.ProductSrvc;
using ECommerce.Operation.UserSrvc;
using Microsoft.AspNetCore.Authentication;

namespace ECommerce.Service.RestExtension;

public static class ServiceExtension
{
    public static void AddServiceExtension(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICartItemService, CartItemService>();
        services.AddScoped<ICartService, CartService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICouponService, CouponService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IOrderItemService, OrderItemService>();
    }
}
