using ECommerce.Base.Model;
using ECommerce.Data.Domain;
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
    public decimal CartTotalAmount { get; set; }
    public decimal UsedPoints { get; set; }
    public decimal CouponPoints { get; set; }
    public decimal TotalDiscount { get; set; }
    public decimal NetAmount { get; set; }
    public List<CartItemResponse> CartItems { get; set; }
    public virtual List<Data.Domain.Coupon> Coupons { get; set; }



}
