using ECommerce.Base.Response;
using ECommerce.Operation.CartItemSrvc;
using ECommerce.Schema.CartItem;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace ECommerce.Service.Controllers
{
    [ApiController]
    [Route("api/cartitems")]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemService cartItemService;

        public CartItemController(ICartItemService cartItemService)
        {
            this.cartItemService = cartItemService;
        }

        [HttpPost("add")]
        public ApiResponse AddCartItem(CartItemRequest request)
        {
            try
            {
                var response = cartItemService.AddCartItem(request.CartId, request.ProductId, request.Quantity);
                return response;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error in adding cart item");
                return new ApiResponse(ex.Message);
            }
        }

        [HttpPut("increase/{cartItemId}")]
        public ApiResponse IncreaseOneCartItemQuantity(int cartItemId)
        {
            try
            {
                var response = cartItemService.IncreaseOneCartItemQuantity(cartItemId);
                return response;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error in increasing cart item quantity");
                return new ApiResponse(ex.Message);
            }
        }

        [HttpPut("decrease/{cartItemId}")]
        public ApiResponse DecreaseOneCartItemQuantity(int cartItemId)
        {
            try
            {
                var response = cartItemService.DecreaseOneCartItemQuantity(cartItemId);
                return response;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error in decreasing cart item quantity");
                return new ApiResponse(ex.Message);
            }
        }

        [HttpPut("update/{cartItemId}")]
        public ApiResponse UpdateCartItemQuantity(int cartItemId, int newQuantity)
        {
            try
            {
                var response = cartItemService.UpdateCartItemQuantity(cartItemId, newQuantity);
                return response;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error in updating cart item quantity");
                return new ApiResponse(ex.Message);
            }
        }
    }
}
