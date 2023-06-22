using ECommerce.Base.Response;
using ECommerce.Data.Domain;
using ECommerce.Operation.BaseSrvc;
using ECommerce.Schema.CartItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Operation.CartItemSrvc
{
    public interface ICartItemService : IBaseService<CartItem, CartItemRequest, CartItemResponse>
    {
         ApiResponse AddCartItem(int cartId, int productId, int quantity);
         ApiResponse IncreaseOneCartItemQuantity(int cartItemId);
         ApiResponse DecreaseOneCartItemQuantity(int cartItemId);
         ApiResponse UpdateCartItemQuantity(int cartItemId, int newQuantity);
    }
}
