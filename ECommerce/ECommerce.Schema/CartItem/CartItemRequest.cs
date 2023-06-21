using ECommerce.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Schema.CartItem;

public class CartItemRequest:BaseRequest
{
    public int CartId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }

}
