using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Domain;
using ECommerce.Data.UnitOfWork;
using ECommerce.Operation.BaseSrvc;
using ECommerce.Schema.Cart;
using Serilog;
using System;
using System.Collections.Generic;
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

    public ApiResponse CreateCartWithItem(int userId, int CartItemId)
    {
        try
        {
            unitOfWork.CartRepository().CreateCartWithCartItem(userId, CartItemId);
            return new ApiResponse();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "CreateCartWithItem Exception");
            return new ApiResponse(ex.Message);
        }
    }
    public ApiResponse DeleteCartWithItems(int CartItemId)
    {
        try
        {
            unitOfWork.CartRepository().DeleteCartWithItems(CartItemId);
            return new ApiResponse();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "DeleteCartWithItems Exception");
            return new ApiResponse(ex.Message);
        }
    }
    public ApiResponse<Decimal> CartTotalAmount(int CartId)
    {
        try
        {
            decimal totalAmount = unitOfWork.CartRepository().CartTotalAmount(CartId);
            return new ApiResponse<Decimal>(totalAmount);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "CartTotalAmount Exception");
            return new ApiResponse<Decimal>(ex.Message);
        }
    }

    public ApiResponse<CartResponse> GetById(int id)
    {
        try
        {
            var entity = unitOfWork.CartRepository().GetCartWithItemsById(id);
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
            Log.Error(ex, " GetById Exception");
            return new ApiResponse<CartResponse>(ex.Message);
        }

    }

}
