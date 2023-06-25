using AutoMapper;
using ECommerce.Data.Domain;
using ECommerce.Schema.Cart;
using ECommerce.Schema.CartItem;
using ECommerce.Schema.Category;
using ECommerce.Schema.Coupon;
using ECommerce.Schema.Order;
using ECommerce.Schema.Product;
using ECommerce.Schema.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Schema.Mapper;

public class MapperProfile:Profile
{
    public MapperProfile()
    {
        CreateMap<Data.Domain.Cart, CartResponse>();
        CreateMap<CreateCartRequest, Data.Domain.Cart>();
        CreateMap<CartRequest, Data.Domain.Cart>();

        CreateMap<Data.Domain.Category, CategoryResponse>();
        CreateMap<CategoryRequest, Data.Domain.Category > ();

        CreateMap<CartItemRequest, CategoryResponse>();
        CreateMap<CartItemResponse, Data.Domain.CartItem>();

        CreateMap<CouponRequest, Data.Domain.Coupon>();
        CreateMap<Data.Domain.Coupon, CouponResponse>();
        
        CreateMap<ProductRequest, Data.Domain.Product>();
        CreateMap<Data.Domain.Product, ProductResponse>();
        
        CreateMap<OrderRequest, Data.Domain.Order>();
        CreateMap<Data.Domain.Order, OrderResponse>();

        CreateMap<ApplicationUserRequest, ApplicationUser>();
        CreateMap<ApplicationUser, ApplicationUserResponse>();

    }


}
