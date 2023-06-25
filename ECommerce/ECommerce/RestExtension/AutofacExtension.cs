using Autofac;
using Autofac.Core;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Data.Repository.Base;
using ECommerce.Data.Repository.Cart;
using ECommerce.Data.Repository.CartItem;
using ECommerce.Data.Repository.Category;
using ECommerce.Data.Repository.Coupon;
using ECommerce.Data.Repository.Order;
using ECommerce.Data.Repository.OrderItem;
using ECommerce.Data.Repository.Product;
using ECommerce.Data.Repository.User;
using ECommerce.Data.UnitOfWork;
using ECommerce.Operation.BaseSrvc;
using ECommerce.Operation.CartItemSrvc;
using ECommerce.Operation.CartSrvc;
using ECommerce.Operation.CategorySrvc;
using ECommerce.Operation.CouponSrvc;
using ECommerce.Operation.OrderItemSrvc;
using ECommerce.Operation.OrderSrvc;
using ECommerce.Operation.ProductSrvc;
using ECommerce.Operation.UserSrvc;
using ECommerce.Schema.Cart;
using ECommerce.Schema.CartItem;
using ECommerce.Schema.Category;
using ECommerce.Schema.Coupon;
using ECommerce.Schema.Order;
using ECommerce.Schema.OrderItem;
using ECommerce.Schema.Product;
using ECommerce.Schema.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Configuration;

namespace ECommerce.Service.RestExtension
{
    public class AutofacExtension : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<UserService>().As<IUserService>();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            //builder.RegisterType<ProductService>().As<IProductService>();


            //builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            //builder.RegisterType<UserService>().As<IUserService>();
            //builder.RegisterType<CartItemService>().As<ICartItemService>();
            //builder.RegisterType<CartService>().As<ICartService>();
            //builder.RegisterType<CategoryService>().As<ICategoryService>();
            //builder.RegisterType<CouponService>().As<ICouponService>();
            //builder.RegisterType<OrderService>().As<IOrderService>();
            //builder.RegisterType<OrderItemService>().As<IOrderItemService>();



            //builder.RegisterType<UserRepository>().As<IUserRepository>();
            //builder.RegisterType<CartItemRepository>().As<ICartItemRepository>();
            //builder.RegisterType<CartRepository>().As<ICartRepository>();
            //builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            //builder.RegisterType<CouponRepository>().As<ICouponRepository>();
            //builder.RegisterType<OrderItemRepository>().As<IOrderItemRepository>();
            //builder.RegisterType<OrderRepository>().As<IOrderRepository>();
            //builder.RegisterType<ProductRepository>().As<IProductRepository>();





            //builder.RegisterType<BaseService<Product, ProductRequest, ProductResponse>>().As<IBaseService<Product, ProductRequest, ProductResponse>>();
            //builder.RegisterType<BaseService<Cart, CartRequest, CartResponse>>().As<IBaseService<Cart, CartRequest, CartResponse>>();
            //builder.RegisterType<BaseService<CartItem, CartItemRequest, CartItemResponse>>().As<IBaseService<CartItem, CartItemRequest, CartItemResponse>>();
            //builder.RegisterType<BaseService<Category, CategoryRequest, CategoryResponse>>().As<IBaseService<Category, CategoryRequest, CategoryResponse>>();
            //builder.RegisterType<BaseService<Coupon, CouponRequest, CouponResponse>>().As<IBaseService<Coupon, CouponRequest, CouponResponse>>();
            //builder.RegisterType<BaseService<Order, OrderRequest, OrderResponse>>().As<IBaseService<Order, OrderRequest, OrderResponse>>();
            //builder.RegisterType<BaseService<OrderItem, OrderItemRequest, OrderItemResponse>>().As<IBaseService<OrderItem, OrderItemRequest, OrderItemResponse>>();

            //builder.RegisterType<GenericRepository<Cart>>().As<IGenericRepository<Cart>>();
            //builder.RegisterType<GenericRepository<CartItem>>().As<IGenericRepository<CartItem>>();
            //builder.RegisterType<GenericRepository<Category>>().As<IGenericRepository<Category>>();
            //builder.RegisterType<GenericRepository<Coupon>>().As<IGenericRepository<Coupon>>();
            //builder.RegisterType<GenericRepository<Order>>().As<IGenericRepository<Order>>();
            //builder.RegisterType<GenericRepository<OrderItem>>().As<IGenericRepository<OrderItem>>();
            //builder.RegisterType<GenericRepository<Product>>().As<IGenericRepository<Product>>();


        }
    }

}
