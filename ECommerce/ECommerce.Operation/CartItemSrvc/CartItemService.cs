using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Data.Domain;
using ECommerce.Data.UnitOfWork;
using ECommerce.Operation.BaseSrvc;
using ECommerce.Operation.CartSrvc;
using ECommerce.Schema.CartItem;
using ECommerce.Schema.Product;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Operation.CartItemSrvc;

public class CartItemService : BaseService<CartItem, CartItemRequest, CartItemResponse>, ICartItemService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public CartItemService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public virtual ApiResponse AddCartItem(int cartId, int productId, int quantity)
    {

        try
        {
            var entity = unitOfWork.CartItemRepository().AddCartItemToCart(cartId, productId, quantity);

            if (entity is null)
            {
                Log.Warning("Record not found for Id " + cartId);
                return new ApiResponse("Record not found");
            }
            unitOfWork.Complete();
            return new ApiResponse();

        }
        catch (Exception ex)
        {

            Log.Error(ex, "AddCartItem Exception");
            return new ApiResponse(ex.Message);
        }

    }
    public virtual ApiResponse IncreaseOneCartItemQuantity(int cartItemId)
    {

        try
        {
            var entity = unitOfWork.CartItemRepository().IncreaseOneCartItemQuantity(cartItemId);
            if (entity is null)
            {
                Log.Warning("Record not found for Id " + cartItemId);
                return new ApiResponse("Record not found ");
            }
            unitOfWork.Complete();
            return new ApiResponse();

        }
        catch (Exception ex)
        {

            Log.Error(ex, "IncreaseCartItemQuantity Exception");
            return new ApiResponse(ex.Message);
        }
    }

    public virtual ApiResponse DecreaseOneCartItemQuantity(int cartItemId)
    {

        try
        {
            var entity = unitOfWork.CartItemRepository().DecreaseOneCartItemQuantity(cartItemId);
            if (entity is null)
            {
                Log.Warning("Record not found for Id  " + cartItemId);
                return new ApiResponse("Record not found ");
            }
            unitOfWork.Complete();
            return new ApiResponse();

        }
        catch (Exception ex)
        {

            Log.Error(ex, "DecreaseCartItemQuantity Exception");
            return new ApiResponse(ex.Message);
        }
    }

    public virtual ApiResponse UpdateCartItemQuantity(int cartItemId, int newQuantity)
    {

        try
        {
            var entity = unitOfWork.CartItemRepository().UpdateCartItemQuantity(cartItemId, newQuantity);
            if (entity is null)
            {
                Log.Warning("Record not found for Id or unwanted quantity number" + cartItemId);
                return new ApiResponse("Record not found ");
            }
            unitOfWork.Complete();
            return new ApiResponse();

        }
        catch (Exception ex)
        {

            Log.Error(ex, "UpdateCartItemQuantity Exception");
            return new ApiResponse(ex.Message);
        }
    }

}
