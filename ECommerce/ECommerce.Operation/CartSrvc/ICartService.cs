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
        ApiResponse CreateCart(int userId, int ProductId, int quantitiy);
        ApiResponse DeleteCartWithItems(int CartItemId);
        ApiResponse<decimal> CartTotalAmount(int CartId);
        ApiResponse<CartResponse> GetCardItemsById(int id);
        ApiResponse<CartResponse> GetCardCouponsById(int id);
        ApiResponse<decimal> GetTotalDiscountForCard(int cartId);
        ApiResponse<decimal> NetAmount(int cartId);
        ApiResponse<decimal> UsePoint(int cartId, decimal point);
        ApiResponse AddCouponToCart(int cartId, string couponCode);
        ApiResponse RemoveCouponFromCart(int cartId, int couponId);
    }
}
