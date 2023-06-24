using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Domain;
using ECommerce.Data.UnitOfWork;
using ECommerce.Operation.BaseSrvc;
using ECommerce.Schema.Cart;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Operation.CartSrvc;

public class CartService : BaseService<Cart, CartRequest, CartResponse>, ICartService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public CartService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }


    public ApiResponse<CartResponse> GetCartWithAllItems(int cartId)
    {
        try
        {
            var entity = unitOfWork.CartRepository().GetCartWithAllItems(cartId);
            if (entity is null)
            {
                Log.Warning("Record not found for Id " + cartId);
                return new ApiResponse<CartResponse>("Record not found");
            }
            var mapped = mapper.Map<CartResponse>(entity);
            return new ApiResponse<CartResponse>(mapped);

        }
        catch (Exception ex)
        {
            Log.Error(ex, "CartTotalAmount Exception");
            return new ApiResponse<CartResponse>(ex.Message);
        }
    }

    public ApiResponse<CartResponse> CreateCart(int userId, int ProductId, int quantitiy)
    {
        try
        {
            var entity = unitOfWork.CartRepository().CreateCart(userId,ProductId);
            if (entity is null)
            {
                Log.Warning("Record not found for ProductID " + ProductId);
                return new ApiResponse<CartResponse>("Record not found");
            }
            unitOfWork.Complete();
            var cardEntity = unitOfWork.CartRepository().CreateCartFillInside(userId, ProductId, quantitiy);
            var mapped=mapper.Map<CartResponse>(cardEntity);
            unitOfWork.Complete();

            return new ApiResponse<CartResponse>(mapped);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "CreateCart Exception");
            return new ApiResponse<CartResponse>(ex.Message);
        }
    }
    public ApiResponse DeleteCartWithItems(int CartItemId)
    {
        try
        {
            unitOfWork.CartRepository().DeleteCartWithItems(CartItemId);
            unitOfWork.Complete();
            return new ApiResponse();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "DeleteCartWithItems Exception");
            return new ApiResponse(ex.Message);
        }
    }
    public ApiResponse<CartResponse> CartTotalAmount(int CartId)
    {
        try
        {
            var entity = unitOfWork.CartRepository().CartTotalAmount(CartId);
            if (entity is null)
            {
                Log.Warning("Record not found for Id " + CartId);
                return new ApiResponse<CartResponse>("Record not found");
            }
            unitOfWork.Complete();
            var mapped = mapper.Map<CartResponse>(entity);
            return new ApiResponse<CartResponse>(mapped);
            
        }
        catch (Exception ex)
        {
            Log.Error(ex, "CartTotalAmount Exception");
            return new ApiResponse<CartResponse>(ex.Message);
        }
    }

    public ApiResponse<CartResponse> GetCardItemsById(int id)
    {
        try
        {
            var entity = unitOfWork.CartRepository().GetCartItemsById(id);
            if (entity is null)
            {
                Log.Warning("Record not found for Id " + id);
                return new ApiResponse<CartResponse>("Record not found");
            }
            var mapped = mapper.Map<CartResponse>(entity);
            return new ApiResponse<CartResponse>(mapped);
        }
        catch (Exception ex)
        {
            Log.Error(ex, " GetCardItemsById Exception");
            return new ApiResponse<CartResponse>(ex.Message);
        }

    }
    public ApiResponse<CartResponse> GetCardCouponsById(int id)
    {
        try
        {
            var entity = unitOfWork.CartRepository().GetCardCouponsById(id);
            if (entity is null)
            {
                Log.Warning("Record not found for Id " + id);
                return new ApiResponse<CartResponse>("Record not found");
            }
            var mapped = mapper.Map<CartResponse>(entity);
            return new ApiResponse<CartResponse>(mapped);
        }
        catch (Exception ex)
        {
            Log.Error(ex, " GetCardCouponsById Exception");
            return new ApiResponse<CartResponse>(ex.Message);
        }

    }

    public ApiResponse<CartResponse> GetTotalDiscountForCard(int cartId) 
    {
        try
        {
            var entity = unitOfWork.CartRepository().CalculateTotalDiscount(cartId);
            if (entity is null)
            {
                Log.Warning("Record not found for Id " + cartId);
                return new ApiResponse<CartResponse>("Record not found");
            }
            unitOfWork.Complete();
            var mapped = mapper.Map<CartResponse>(entity);
            return new ApiResponse<CartResponse>(mapped);
        }
        catch (Exception ex)
        {
            Log.Error(ex, " GetTotalDiscountForCard Exception");
            return new ApiResponse<CartResponse>(ex.Message);
        }
    }
    public ApiResponse<CartResponse> NetAmount(int cartId) 
    {
        try
        {
            var entity = unitOfWork.CartRepository().CartNetAmount(cartId);
            if (entity is null)
            {
                Log.Warning("Record not found for Id " + cartId);
                return new ApiResponse<CartResponse>("Record not found");
            }
            unitOfWork.Complete();
            var mapped = mapper.Map<CartResponse>(entity);
            return new ApiResponse<CartResponse>(mapped);
        }
        catch (Exception ex)
        {
            Log.Error(ex, " NetAmount Exception");
            return new ApiResponse<CartResponse>(ex.Message);
        }
    }

    public ApiResponse<CartResponse> UsePoint(int cartId, decimal point)
    {
        try
        {

            var entity = unitOfWork.CartRepository().UsePoint(cartId, point);
            if (entity is null)
            {
                Log.Warning("Record not found for Id " + cartId);
                return new ApiResponse<CartResponse>("Record not found");
            }
            var mapped = mapper.Map<CartResponse>(entity);
            return new ApiResponse<CartResponse>(mapped);
        }
        catch (Exception ex)
        {
            Log.Error(ex, " UsePoint Exception");
            return new ApiResponse<CartResponse>(ex.Message);
        }
    }

    public ApiResponse AddCouponToCart(int cartId, string couponCode)
    {
        try
        {
            var entity = unitOfWork.CartRepository().AddCouponToCart(cartId, couponCode);
            if (entity is null)
            {
                Log.Warning("Record not found for CartId or Coupon code " );
                return new ApiResponse("Record not found");
            }
            unitOfWork.Complete();
            return new ApiResponse();
        }
        catch (Exception ex)
        {
            Log.Error(ex, " AddCouponToCart Exception");
            return new ApiResponse(ex.Message);
        }
    }
    
    public ApiResponse RemoveCouponFromCart(int cartId, int couponId)
    {
        try
        {
            var entity = unitOfWork.CartRepository().RemoveCouponFromCart(cartId, couponId);
            if (entity is null)
            {
                Log.Warning("Record not found for CartId or Coupon code");
                return new ApiResponse("Record not found");
            }
            unitOfWork.Complete();
            return new ApiResponse();
        }
        catch (Exception ex)
        {
            Log.Error(ex, " RemoveCouponFromCart Exception");
            return new ApiResponse(ex.Message);
        }
    }
}
