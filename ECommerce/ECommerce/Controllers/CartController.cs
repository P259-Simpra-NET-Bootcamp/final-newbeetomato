using AutoMapper;
using ECommerce.Base.Response;
using ECommerce.Operation.CartSrvc;
using ECommerce.Schema.Cart;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Service.Controllers
{

    [ApiController]
    [Route("api/carts")]
    public class CartController : ControllerBase
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        [HttpGet("{cartId}")]
        public ApiResponse<CartResponse> GetCartAndItemsById(int cartId)
        {
            return cartService.GetCartWithAllItems(cartId);
            
        }

        [HttpPost("{AddItemToCart}")]
        public ApiResponse<CartResponse> CreateCart([FromBody] CreateCartRequest request)
        {
            return cartService.CreateCart(request.UserId, request.ProductId, request.Quantity);
            
        }

        [HttpDelete("{cartItemId}")]
        public ApiResponse DeleteCartWithItems(int cartItemId)
        {
            return cartService.DeleteCartWithItems(cartItemId);
             
        }

        [HttpGet("{cartId}/total-amount")]
        public ApiResponse<CartResponse> GetCartTotalAmount(int cartId)
        {
            return  cartService.CartTotalAmount(cartId);
             
        }

        [HttpGet("{id}/items")]
        public ApiResponse<CartResponse> GetCartItemsById(int id)
        {
            return cartService.GetCardItemsById(id);
             
        }

        [HttpGet("{id}/coupons")]
        public ApiResponse<CartResponse> GetCartCouponsById(int id)
        {
            return cartService.GetCardCouponsById(id);
        }

        [HttpGet("{cartId}/total-discount")]
        public ApiResponse<CartResponse> GetTotalDiscountForCart(int cartId)
        {
            return cartService.GetTotalDiscountForCard(cartId);
        }

        [HttpGet("{cartId}/net-amount")]
        public ApiResponse<CartResponse> GetCartNetAmount(int cartId)
        {
            return cartService.NetAmount(cartId);
            
        }

        [HttpPost("{cartId}/use-points")]
        public ApiResponse<CartResponse> UsePoints(int cartId, [FromBody] UsePointsRequest request)
        {
            return cartService.UsePoint(cartId, request.UsedPoints);
             
        }

        [HttpPost("{cartId}/add-coupon")]
        public ApiResponse AddCouponToCart(int cartId, [FromBody] AddCouponRequest request)
        {
            return cartService.AddCouponToCart(cartId, request.Code);
             
        }

        [HttpDelete("{cartId}/remove-coupon/{couponId}")]
        public ApiResponse RemoveCouponFromCart(int cartId, int couponId)
        {
            return cartService.RemoveCouponFromCart(cartId, couponId);
             
        }

       
    }
}