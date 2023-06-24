using ECommerce.Base.Response;
using ECommerce.Data.Domain;
using ECommerce.Operation.BaseSrvc;
using ECommerce.Schema.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Operation.CartSrvc
{
    public interface ICartService:IBaseService<Cart,CartRequest, CartResponse>
    {
        ApiResponse<CartResponse> GetCartWithAllItems(int cartId);
        ApiResponse<CartResponse> CreateCart(int userId, int ProductId, int quantitiy);
        ApiResponse DeleteCartWithItems(int CartItemId);
        ApiResponse<CartResponse> CartTotalAmount(int CartId);
        ApiResponse<CartResponse> GetCardItemsById(int id);
        ApiResponse<CartResponse> GetCardCouponsById(int id);
        ApiResponse<CartResponse> GetTotalDiscountForCard(int cartId);
        ApiResponse<CartResponse> NetAmount(int cartId);
        ApiResponse<CartResponse> UsePoint(int cartId, decimal point);
        ApiResponse AddCouponToCart(int cartId, string couponCode);
        ApiResponse RemoveCouponFromCart(int cartId, int couponId);
    }
}
