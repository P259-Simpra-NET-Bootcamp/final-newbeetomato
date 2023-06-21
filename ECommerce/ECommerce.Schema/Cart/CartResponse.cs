using ECommerce.Base.Model;
using ECommerce.Schema.CartItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Schema.Cart;

public class CartResponse:BaseResponse
{
    public int UserId { get; set; }
    public List<CartItemResponse> CartItems { get; set; }


}
