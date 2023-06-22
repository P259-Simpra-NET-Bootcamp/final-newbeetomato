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
        ApiResponse CreateCartWithItem(int userId, int CartItemId);
        ApiResponse DeleteCartWithItems(int CartItemId);
        ApiResponse<Decimal> CartTotalAmount(int CartId);
        ApiResponse<CartResponse> GetById(int id);
    }
}
