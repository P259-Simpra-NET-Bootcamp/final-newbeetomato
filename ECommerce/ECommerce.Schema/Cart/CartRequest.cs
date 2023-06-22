using ECommerce.Base.Model;
using ECommerce.Schema.CartItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Schema.Cart;

public class CartRequest:BaseRequest
{
    public int UserId { get; set; }
    public decimal CartTotalAmount { get; set; }
    public List<CartItemRequest> CartItems { get; set; }
}
